using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.ML.OnnxRuntime;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCBVison.Models;

namespace PCBVison
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Force loading the correct onnxruntime.dll by targeting the correct assembly
            NativeLibrary.SetDllImportResolver(typeof(InferenceSession).Assembly, DllImportResolver);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static IntPtr DllImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            if (libraryName == "onnxruntime")
            {
                string rid = "win-x64";
                string nativeLibraryPath = Path.Combine(AppContext.BaseDirectory, "runtimes", rid, "native", "onnxruntime.dll");
                if (File.Exists(nativeLibraryPath))
                {
                    return NativeLibrary.Load(nativeLibraryPath);
                }
            }
            return IntPtr.Zero;
        }
    }
}

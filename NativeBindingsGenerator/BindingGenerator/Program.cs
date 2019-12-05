using System;
using System.IO;
using System.Linq;
using CppAst;
using CppAst.CodeGen.Common;
using CppAst.CodeGen.CSharp;
using Zio.FileSystems;

namespace BindingGenerator
{
    public class Program
    {
        private const string OutputFolder = @"..\..\..\..\XRTK.Lumin\Packages\com.xrtk.lumin\NativeBindings";
        private const string LuminSdkVersion = "v0.22.0";

        static void Main(string[] args)
        {
            var program = new Program();
            program.CppCodeGen();
        }

        private void CppCodeGen()
        {
            if (!Directory.Exists(OutputFolder))
            {
                Directory.CreateDirectory(OutputFolder);
            }

            var mlsdkPathRoot = Environment.ExpandEnvironmentVariables("%mlsdk%");
            var headerPath = $"{mlsdkPathRoot}\\{LuminSdkVersion}\\include\\";
            var headers = Directory.GetFiles(headerPath, "*.h", SearchOption.TopDirectoryOnly).ToList();

            var parserOptions = new CSharpConverterOptions
            {
                ParseMacros = true,
                ParseComments = true,
                GenerateAsInternal = true,
                DefaultClassLib = "Interop",
                AllowFixedSizeBuffers = false,
                DispatchOutputPerInclude = true,
                GenerateEnumItemAsFields = true,
                TargetCpu = CppTargetCpu.X86_64,
                DefaultNamespace = "XRTK.Lumin.Native.Bindings",
                SystemIncludeFolders = { "C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Enterprise\\VC\\Tools\\MSVC\\14.23.28105\\include" }
            };

            var compilation = CSharpConverter.Convert(headers, parserOptions);

            if (compilation.HasErrors)
            {
                foreach (var message in compilation.Diagnostics.Messages)
                {
                    Console.Error.WriteLine(message);
                }

                do { while (!Console.KeyAvailable) { /*Nothing*/ } }
                while (Console.ReadKey(true).Key != ConsoleKey.Escape);

                Environment.Exit(1);
            }

            var fileSystem = new PhysicalFileSystem();
            {
                var folder = fileSystem.ConvertPathFromInternal(
                    Path.GetFullPath(
                        Path.Combine(Environment.CurrentDirectory, OutputFolder)));
                compilation.DumpTo(
                    new CodeWriter(
                        new CodeWriterOptions(
                            new SubFileSystem(fileSystem, folder))));
            }
        }
    }
}

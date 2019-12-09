using System;
using System.Collections.Generic;
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

        static void Main(string[] _)
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
                DefaultOutputFilePath = "Interop.cs",
                AllowFixedSizeBuffers = false,
                DispatchOutputPerInclude = true,
                GenerateEnumItemAsFields = false,
                DefaultDllImportNameAndArguments = "NotFound", // Debug to find missing header/dll mappings
                TargetCpu = CppTargetCpu.X86_64,
                DefaultNamespace = "XRTK.Lumin.Native.Bindings",
                SystemIncludeFolders = { "C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Enterprise\\VC\\Tools\\MSVC\\14.23.28105\\include" },
                MappingRules =
                {
                    e => e.MapAll<CppElement>().CppAction(ProcessHeaders),

                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_audio\"", "ml_audio.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_input\"", "ml_input.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_camera\"", "ml_camera.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_locale\"", "ml_locale.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_remote\"", "ml_remote.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_screens\"", "ml_screens.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_contacts\"", "ml_contacts.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_dispatch\"", "ml_dispatch.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_graphics\"", "ml_graphics.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_identity\"", "ml_identity.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_location\"", "ml_location.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_platform\"", "ml_platform.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_purchase\"", "ml_purchase.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_mediadrm\"", "ml_media_drm.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_ext_logging\"", "ml_logging.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_networking\"", "ml_networking.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_sharedfile\"", "ml_sharedfile.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_mediaerror\"", "ml_media_error.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_mediacrypto\"", "ml_media_crypto.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_mediaformat\"", "ml_media_format.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_mediaplayer\"", "ml_media_player.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_musicservice\"", "ml_music_service.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_app_analytics\"", "ml_app_analytics.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_graphics_utils\"", "ml_graphics_utils.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_secure_storage\"", "ml_secure_storage.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_mediacodeclist\"", "ml_media_codeclist.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_mediaextractor\"", "ml_media_extractor.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_privileges\"", "ml_privilege_functions.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_camera_metadata\"", "ml_camera_metadata.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_media_ccparser\"", "ml_media_cea608_caption.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_media_data_source\"", "ml_media_data_source.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_mediastream_source\"", "ml_media_stream_source.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_musicservice_provider\"", "ml_music_service_provider.h"),

                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_lifecycle\"", "ml_fileinfo.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_lifecycle\"", "ml_lifecycle.h"),

                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_mediacodec\"", "ml_media_codec.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_mediacodec\"", "ml_media_surface_texture.h"),

                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_perception_client\"", "ml_planes.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_perception_client\"", "ml_raycast.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_perception_client\"", "ml_meshing2.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_perception_client\"", "ml_snapshot.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_perception_client\"", "ml_cv_camera.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_perception_client\"", "ml_controller.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_perception_client\"", "ml_data_array.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_perception_client\"", "ml_perception.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_perception_client\"", "ml_eye_tracking.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_perception_client\"", "ml_found_object.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_perception_client\"", "ml_hand_meshing.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_perception_client\"", "ml_hand_tracking.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_perception_client\"", "ml_head_tracking.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_perception_client\"", "ml_image_tracking.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_perception_client\"", "ml_lighting_tracking.h"),
                    e => e.MapAll<CppElement>().DllImportLibrary("\"ml_perception_client\"", "ml_persistent_coordinate_frames.h"),
                }
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
            var folder = fileSystem.ConvertPathFromInternal(
                Path.GetFullPath(
                    Path.Combine(Environment.CurrentDirectory, OutputFolder)));
            compilation.DumpTo(
                            new CodeWriter(
                                new CodeWriterOptions(
                                    new SubFileSystem(fileSystem, folder))));
        }

        private static void ProcessHeaders(CSharpConverter converter, CppElement cppElement)
        {
            if (Path.GetFileName(cppElement.SourceFile) == "ml_token_agent.h")
            {
                converter.Discard(cppElement);
            }
        }
    }
}
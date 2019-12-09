//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

namespace XRTK.Lumin.Native.Bindings
{
    using System.Runtime.InteropServices;

    internal static class MlSharedfile
    {
        /// <summary>
        ///  SharedFile Shared File
        ///  SharedFile
        /// APIs for the Shared File system
        /// This interface provides access to files made available by the user to be shared
        /// among applications Access to these files is provided through the MLFileInfo structure
        /// </summary>
        /// <remarks>
        /// \
        /// {
        /// Applications can obtain file descriptors from MLFileInfo to read and/or write to the
        /// shared files
        /// Applications only get access to those shared files that the user has selected through
        /// MLSharedFilePick The application can store the names of the files that the user
        /// has selected and can subsequently use those file names in the MLSharedFilesRead API
        /// Notes For Current API Version:
        /// - Applications cannot append/write to existing files
        /// - MLSharedFilePick API will let the user select files for the app to access
        /// - Currently only media files will be shown to the user to pick from
        /// - They can only write new files and read only from files that the user has selected previously
        /// or the ones that the app itself has written
        /// </remarks>
        public const int MLResultAPIPrefix_SharedFile = unchecked((int)0xC20D << 16);

        /// <summary>
        /// Return values for Shared File API calls
        /// </summary>
        public enum MLSharedFileResult : int
        {
            /// <summary>
            /// File not found
            /// </summary>
            MLSharedFileResult_NoFilesFound = unchecked((int)MLResultAPIPrefix_SharedFile),

            /// <summary>
            /// Invalid file name
            /// </summary>
            MLSharedFileResult_InvalidFileName,

            /// <summary>
            /// File open failure
            /// </summary>
            MLSharedFileResult_FileOpenFailure,

            /// <summary>
            /// Unidentified caller
            /// </summary>
            MLSharedFileResult_UnidentifiedCaller,

            /// <summary>
            /// Ensure enum is represented as 32 bits
            /// </summary>
            MLSharedFileResult_Ensure32Bits = unchecked((int)0x7FFFFFFF),
        }

        /// <summary>
        /// Opaque structure containing array of MLFileInfo structures
        /// Functions below can be used to access things like the number of MLFileInfo objects
        /// and the objects themselves given the index
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public readonly struct MLSharedFileList : IEquatable<MLSharedFileList>
        {
            private readonly IntPtr _handle;

            public MLSharedFileList(IntPtr handle) => _handle = handle;

            public IntPtr Handle => _handle;

            public bool Equals(MLSharedFileList other) => _handle.Equals(other._handle);

            public override bool Equals(object obj) => obj is MLSharedFileList other && Equals(other);

            public override int GetHashCode() => _handle.GetHashCode();

            public override string ToString() => "0x" + (IntPtr.Size == 8 ? _handle.ToString("X16") : _handle.ToString("X8"));

            public static bool operator ==(MLSharedFileList left, MLSharedFileList right) => left.Equals(right);

            public static bool operator !=(MLSharedFileList left, MLSharedFileList right) => !left.Equals(right);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void onFilesPickedCb(MlSharedfile.MLSharedFileList list, IntPtr context);

        /// <summary>
        /// Return an MLSharedFileList struct with MLFileInfo objects for the
        /// files that the application requests in the file_name_list
        /// </summary>
        /// <param name="file_name_list">List of the filenames that the application wants to read</param>
        /// <param name="file_name_list_length">Length of the list of filenames</param>
        /// <param name="out_shared_file_list">pointer to the pointer to MLSharedFileList struct,
        /// This pointer should be freed by calling MLSharedFileListRelease</param>
        /// <returns>
        /// MLResult_InvalidParam If a function parameter is not valid
        /// MLResult_Ok If files are read successfully
        /// MLSharedFileResult Shared File specific error occurred
        /// </returns>
        /// <remarks>
        /// If the application does not have user permission to access a file,
        /// that file will not be returned
        /// @priv None
        /// </remarks>
        [DllImport("ml_sharedfile", CallingConvention = CallingConvention.Cdecl)]
        public static extern MlApi.MLResult MLSharedFileRead(out string file_name_list, uint file_name_list_length, out MlSharedfile.MLSharedFileList out_shared_file_list);

        /// <summary>
        /// Return an MLSharedFileList struct with MLFileInfo objects for the
        /// files that the application wants to write to
        /// </summary>
        /// <param name="file_name_list">List of the file names that the application wants to write
        /// File names to write cannot be a path They must be just the file's name</param>
        /// <param name="file_name_list_length">Length of the list of file names</param>
        /// <param name="out_shared_file_list">pointer to the pointer to MLSharedFileList struct,
        /// This pointer should be freed by calling MLSharedFileListRelease</param>
        /// <returns>
        /// MLResult_InvalidParam If a function parameter is not valid
        /// MLResult_Ok If files are written successfully
        /// MLSharedFileResult Shared File specific error occurred
        /// </returns>
        /// <remarks>
        /// @priv None
        /// </remarks>
        [DllImport("ml_sharedfile", CallingConvention = CallingConvention.Cdecl)]
        public static extern MlApi.MLResult MLSharedFileWrite(out string file_name_list, uint file_name_list_length, out MlSharedfile.MLSharedFileList out_shared_file_list);

        /// <summary>
        /// Return an MLSharedFileList struct with MLFileInfo objects containing
        /// only the names of the files that the application has access to The application
        /// can then use the file names and read the files with the MLReadSharedFiles API
        /// </summary>
        /// <param name="out_shared_file_list">pointer to the pointer MLSharedFileList struct,
        /// This pointer should be freed by calling MLSharedFileListRelease</param>
        /// <returns>
        /// MLResult_Ok If files can be listed successfully
        /// MLSharedFileResult Shared File specific error occurred
        /// </returns>
        /// <remarks>
        /// @priv None
        /// </remarks>
        [DllImport("ml_sharedfile", CallingConvention = CallingConvention.Cdecl)]
        public static extern MlApi.MLResult MLSharedFileListAccessibleFiles(out MlSharedfile.MLSharedFileList out_shared_file_list);

        /// <summary>
        /// Let the app get access to the user's shared files from the
        /// common storage location
        /// </summary>
        /// <param name="cb">onFilesPickedCb callback function that will be called to give the app
        /// access to the files that the user has picked</param>
        /// <param name="context">The caller can pass in a context that will be returned in the callback</param>
        /// <returns>
        /// MLResult_Ok If operation is successful
        /// MLSharedFileResult Shared File specific error occurred
        /// </returns>
        /// <remarks>
        /// This API will pop up a System UI dialogue box with a file picker
        /// through which the user can pick files she wants to let the app have access to
        /// The list of selected files will be returned to the app as MLSharedFileList
        /// @priv None
        /// </remarks>
        [DllImport("ml_sharedfile", CallingConvention = CallingConvention.Cdecl)]
        public static extern MlApi.MLResult MLSharedFilePick(MlSharedfile.onFilesPickedCb cb, IntPtr context);

        /// <summary>
        /// Retrieve the length of the MLFileInfo array from MLSharedFileList
        /// </summary>
        /// <param name="shared_file_list">Pointer to the MLSharedFileList structure</param>
        /// <param name="out_shared_file_list_length">pointer to length of MLFileInfo array</param>
        /// <returns>
        /// MLResult_InvalidParam If a function parameter is not valid
        /// MLResult_Ok If operation is succesful
        /// </returns>
        /// <remarks>
        /// This function can return length of 0 which implies that there are no files in the list
        /// @priv None
        /// </remarks>
        [DllImport("ml_sharedfile", CallingConvention = CallingConvention.Cdecl)]
        public static extern MlApi.MLResult MLSharedFileGetListLength(MlSharedfile.MLSharedFileList shared_file_list, ref ulong out_shared_file_list_length);

        /// <summary>
        /// Retrieve the MLFileInfo structure from MLSharedFileList for the given index
        /// </summary>
        /// <param name="shared_file_list">Pointer to the MLSharedFileList structure</param>
        /// <param name="index">Index of the MLFileInfoArray</param>
        /// <param name="out_file_info">pointer to the pointer to MLFileInfo struct
        /// The caller should not free the pointer returned
        /// The memory will be released in the call to MLSharedFileListRelease</param>
        /// <returns>
        /// MLResult_InvalidParam If a function parameter is not valid
        /// MLResult_Ok If operation is succesful
        /// </returns>
        /// <remarks>
        /// @priv None
        /// </remarks>
        [DllImport("ml_sharedfile", CallingConvention = CallingConvention.Cdecl)]
        public static extern MlApi.MLResult MLSharedFileGetMLFileInfoByIndex(MlSharedfile.MLSharedFileList shared_file_list, ulong index, out MlFileinfo.MLFileInfo out_file_info);

        /// <summary>
        /// Return the error code from the MLSharedFileList structure
        /// </summary>
        /// <param name="shared_file_list">Pointer to the MLSharedFileList structure</param>
        /// <returns>
        /// MLResult_InvalidParam If a function parameter is not valid
        /// MLResult_Ok If operation is succesful
        /// </returns>
        /// <remarks>
        /// @priv None
        /// </remarks>
        [DllImport("ml_sharedfile", CallingConvention = CallingConvention.Cdecl)]
        public static extern MlApi.MLResult MLSharedFileGetErrorCode(MlSharedfile.MLSharedFileList shared_file_list);

        /// <summary>
        /// Release memory for the MLSharedFileList struct returned by APIs in this interface
        /// </summary>
        /// <param name="shared_file_list">Pointer to the pointer to the MLSharedFileList struct
        /// that needs to be freed</param>
        /// <returns>
        /// MLResult_InvalidParam If a function parameter is not valid
        /// MLResult_Ok If operation is succesful
        /// </returns>
        /// <remarks>
        /// @priv None
        /// </remarks>
        [DllImport("ml_sharedfile", CallingConvention = CallingConvention.Cdecl)]
        public static extern MlApi.MLResult MLSharedFileListRelease(out MlSharedfile.MLSharedFileList shared_file_list);

        /// <summary>
        /// Returns an ASCII string for MLSharedFileResult and MLResultGlobal codes
        /// </summary>
        /// <param name="result_code">The input MLResult enum from MLSharedFile functions</param>
        /// <returns>
        /// ASCII string containing readable version of result code
        /// </returns>
        /// <remarks>
        /// @priv None
        /// </remarks>
        [DllImport("ml_sharedfile", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string MLSharedFileGetResultString(MlApi.MLResult result_code);
    }
}
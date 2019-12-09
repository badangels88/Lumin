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

    internal static class MlMediaStreamSource
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void MLMediaStreamSourceOnBufferAvailable(MlApi.MLHandle media_stream_source, IntPtr context);

        /// <summary>
        /// Create a new MediaStreamSource object
        /// </summary>
        /// <param name="on_buffer_available">MLMediaStreamSourceOnBufferAvailable callback</param>
        /// <param name="context">User data to be passed to callbacks</param>
        /// <param name="out_handle">The MLHandle to the new source object created Only valid if result is MLResult_Ok</param>
        /// <returns>
        /// MLResult_InvalidParam One of the parameters is invalid
        /// MLResult_Ok If operation was successful
        /// MLResult_UnspecifiedFailure The operation failed with an unspecified error
        /// </returns>
        /// <remarks>
        /// @priv None
        /// </remarks>
        [DllImport("ml_mediastream_source", CallingConvention = CallingConvention.Cdecl)]
        public static extern MlApi.MLResult MLMediaStreamSourceCreate(MlMediaStreamSource.MLMediaStreamSourceOnBufferAvailable on_buffer_available, IntPtr context, ref MlApi.MLHandle out_handle);

        /// <summary>
        /// Destroy a MediaStreamSource object
        /// </summary>
        /// <param name="media_stream_source">MLHandle to the MediaStreamSource object to destroy</param>
        /// <returns>
        /// MLResult_InvalidParam One of the parameters is invalid
        /// MLResult_Ok If operation was successful
        /// MLResult_UnspecifiedFailure The operation failed with an unspecified error
        /// </returns>
        /// <remarks>
        /// @priv None
        /// </remarks>
        [DllImport("ml_mediastream_source", CallingConvention = CallingConvention.Cdecl)]
        public static extern MlApi.MLResult MLMediaStreamSourceDestroy(MlApi.MLHandle media_stream_source);

        /// <summary>
        /// Get a buffer where data can be written
        /// </summary>
        /// <param name="media_stream_source">MLHandle as returned by MLMediaStreamSourceCreate</param>
        /// <param name="out_id">An opaque ID that should be passed to MLMediaStreamSourcePushBuffer</param>
        /// <param name="out_ptr">The location where to write data</param>
        /// <param name="out_size">Maximum bytes that can be written in @c out_ptr</param>
        /// <returns>
        /// MLResult_Ok If operation was successful
        /// MLResult_InvalidParam One of the parameters is invalid
        /// MLResult_UnspecifiedFailure The operation failed with an unspecified error
        /// </returns>
        /// <remarks>
        /// If a buffer is available, true is returned and @c out_id, @c out_ptr and @c out_size are set Application can then write up to @c out_size bytes into @c out_ptr and
        /// push that data using MLMediaStreamSourcePushBuffer
        /// If no buffer is available, false is returned and application should wait
        /// for MLMediaStreamSourceOnBufferAvailable to be called before retrying
        /// @priv None
        /// </remarks>
        [DllImport("ml_mediastream_source", CallingConvention = CallingConvention.Cdecl)]
        public static extern MlApi.MLResult MLMediaStreamSourceGetBuffer(MlApi.MLHandle media_stream_source, ref Interop.size_t out_id, out IntPtr out_ptr, ref Interop.size_t out_size);

        /// <summary>
        /// Push a buffer
        /// </summary>
        /// <param name="media_stream_source">MLHandle as returned by MLMediaStreamSourceCreate</param>
        /// <param name="id">The ID of the buffer as given by MLMediaStreamSourceGetBuffer</param>
        /// <param name="size">The number of bytes actually written in the buffer</param>
        /// <returns>
        /// MLResult_InvalidParam One of the parameters is invalid
        /// MLResult_Ok If operation was successful
        /// MLResult_UnspecifiedFailure The operation failed with an unspecified error
        /// </returns>
        /// <remarks>
        /// Queue a buffer acquired from MLMediaStreamSourceGetBuffer once data has been written
        /// @priv None
        /// </remarks>
        [DllImport("ml_mediastream_source", CallingConvention = CallingConvention.Cdecl)]
        public static extern MlApi.MLResult MLMediaStreamSourcePushBuffer(MlApi.MLHandle media_stream_source, Interop.size_t id, Interop.size_t size);

        /// <summary>
        /// Push End-Of-Stream event
        /// </summary>
        /// <param name="media_stream_source">MLHandle as returned by MLMediaStreamSourceCreate</param>
        /// <returns>
        /// MLResult_InvalidParam One of the parameters is invalid
        /// MLResult_Ok If operation was successful
        /// MLResult_UnspecifiedFailure The operation failed with an unspecified error
        /// </returns>
        /// <remarks>
        /// Signal that the end of stream is reached and no more data will be pushed
        /// @priv None
        /// </remarks>
        [DllImport("ml_mediastream_source", CallingConvention = CallingConvention.Cdecl)]
        public static extern MlApi.MLResult MLMediaStreamSourcePushEOS(MlApi.MLHandle media_stream_source);
    }
}
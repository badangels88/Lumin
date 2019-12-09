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

    internal static class MlImage
    {
        /// <summary>
        /// Information about the data contained inside the image
        /// </summary>
        public enum MLImageType : int
        {
            /// <summary>
            /// Bit mask storing 8-bit unsigned int per pixel
            /// </summary>
            MLImageType_BitMask,

            /// <summary>
            /// RGB format (linear color space)
            /// </summary>
            MLImageType_RGB24,

            /// <summary>
            /// RGBA format (linear color space)
            /// </summary>
            MLImageType_RGBA32,

            /// <summary>
            /// Ensure enum is represented as 32 bits
            /// </summary>
            MLImageType_Ensure32Bits = unchecked((int)0x7FFFFFFF),
        }

        /// <summary>
        /// Image and its meta-data
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct MLImage
        {
            /// <summary>
            /// Image width in pixels
            /// </summary>
            public uint width;

            /// <summary>
            /// Image height in pixels
            /// </summary>
            public uint height;

            /// <summary>
            /// Type of image
            /// </summary>
            public MlImage.MLImageType image_type;

            /// <summary>
            /// Row alignment (in bytes)
            /// </summary>
            /// <remarks>
            /// It defines the amount of extra bytes to be used as padding,
            /// such that the stride must be a multiple of this alignment
            /// The accepted values are 1, 2, 4, 8 or 16 (1 means no padding)
            /// The stride of the image should be considered as:
            /// stride = width * numberOfChannels * bytesPerChannel + padding
            /// Example:
            /// Let's say we have an RGB image (3 channels) of width 111 and alignment 4, then:
            /// stride = 111 * 3 * 1 + 3 = 336
            /// The padding is 3 and the stride is 336, multiple of the alignment 4
            /// </remarks>
            public byte alignment;

            /// <summary>
            /// The image data stored without compression in row major order
            /// Image origin is the upper left corner
            /// </summary>
            public IntPtr data;
        }
    }
}
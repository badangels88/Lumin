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

    internal static class MlCoordinateFrameUid
    {
        /// <summary>
        /// A unique identifier which represents a coordinate frame
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct MLCoordinateFrameUID
        {
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 2)]
            public ulong[] data;
        }
    }
}
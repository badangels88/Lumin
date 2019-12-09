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

    internal static class MlMediaWebvtt
    {
        /// <summary>
        /// Cue orientation setting
        /// @apilevel 4
        /// </summary>
        public enum MLWebVTTOrientation : int
        {
            MLWebVTTOrientation_Horizontal = unchecked((int)0),

            MLWebVTTOrientation_Vertical = unchecked((int)1),

            /// <summary>
            /// Ensure enum is represented as 32 bits
            /// </summary>
            MLWebVTTOrientation_Ensure32Bits = unchecked((int)0x7FFFFFFF),
        }

        /// <summary>
        /// Cue direction setting
        /// @apilevel 4
        /// </summary>
        public enum MLWebVTTDirection : int
        {
            MLWebVTTDirection_Default = unchecked((int)0),

            MLWebVTTDirection_LeftToRight = unchecked((int)1),

            MLWebVTTDirection_RightToLeft = unchecked((int)2),

            /// <summary>
            /// Ensure enum is represented as 32 bits
            /// </summary>
            MLWebVTTDirection_Ensure32Bits = unchecked((int)0x7FFFFFFF),
        }

        /// <summary>
        /// Cue aligment setting
        /// @apilevel 4
        /// </summary>
        public enum MLWebVTTAlign : int
        {
            MLWebVTTAlign_Start = unchecked((int)0),

            MLWebVTTAlign_Middle = unchecked((int)1),

            MLWebVTTAlign_End = unchecked((int)2),

            MLWebVTTAlign_Left = unchecked((int)3),

            MLWebVTTAlign_Right = unchecked((int)4),

            /// <summary>
            /// Ensure enum is represented as 32 bits
            /// </summary>
            MLWebVTTAlign_Ensure32Bits = unchecked((int)0x7FFFFFFF),
        }

        /// <summary>
        /// WebVTT data structure
        /// @apilevel 4
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct MLWebVTTData
        {
            /// <summary>
            /// Track cue start time
            /// </summary>
            public long start_time_us;

            /// <summary>
            /// Track cue end time
            /// </summary>
            public long end_time_us;

            /// <summary>
            /// WebVTT file body encoded as UTF-8
            /// </summary>
            public IntPtr body;

            /// <summary>
            /// A sequence of characters unique amongst all the WebVTT cue identifiers
            /// </summary>
            public IntPtr id;

            /// <summary>
            /// A boolean indicating whether the line is an integer number of lines
            /// </summary>
            [MarshalAs(UnmanagedType.U1)]
            public bool snap_to_lines;

            /// <summary>
            /// Orientation of the cue
            /// </summary>
            public MlMediaWebvtt.MLWebVTTOrientation orientation;

            /// <summary>
            /// The writing direction
            /// </summary>
            public MlMediaWebvtt.MLWebVTTDirection direction;

            /// <summary>
            /// Relative cue line position
            /// </summary>
            public float relative_line_position;

            /// <summary>
            /// WebVTT cue line number
            /// </summary>
            public int line_number;

            /// <summary>
            /// The indent of the cue box in the direction defined by the writing direction
            /// </summary>
            public float text_position;

            /// <summary>
            /// WebVTT cue size
            /// </summary>
            public float size;

            /// <summary>
            /// WebVTT cue text alignment
            /// </summary>
            public MlMediaWebvtt.MLWebVTTAlign align;
        }
    }
}
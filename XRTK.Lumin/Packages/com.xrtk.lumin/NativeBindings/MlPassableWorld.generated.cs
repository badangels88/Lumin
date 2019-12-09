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
    internal static class MlPassableWorld
    {
        /// <summary>
        ///  PassableWorld Passable World
        /// The MLResults for the Passable World trackers
        ///  FoundObject
        ///  PersistentCoordinateFrames
        /// </summary>
        /// <remarks>
        /// -
        /// -
        /// \
        /// {
        /// </remarks>
        public const int MLResultAPIPrefix_PassableWorld = unchecked((int)0x41c7 << 16);

        /// <summary>
        /// Return values for Passable World API calls
        /// </summary>
        public enum MLPassableWorldResult : int
        {
            /// <summary>
            /// Low map quality
            /// </summary>
            MLPassableWorldResult_LowMapQuality = unchecked((int)MLResultAPIPrefix_PassableWorld),

            /// <summary>
            /// Unable to localize
            /// </summary>
            MLPassableWorldResult_UnableToLocalize,

            /// <summary>
            /// Server unavailable
            /// </summary>
            MLPassableWorldResult_ServerUnavailable,

            /// <summary>
            /// Not found
            /// </summary>
            MLPassableWorldResult_NotFound,
        }
    }
}
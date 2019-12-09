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

    internal static class MlPerception
    {
        /// <summary>
        /// Settings for initializing the perception system
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct MLPerceptionSettings
        {
            public ushort override_port;
        }

        /// <summary>
        /// Initialize the perception system with the passed in settings
        /// </summary>
        /// <param name="settings">Initializes the perception system with these settings</param>
        /// <returns>
        /// MLResult_InvalidParam If settings pointer was null
        /// MLResult_Ok If settings was initialized successfully
        /// MLResult_UnspecifiedFailure If operation failed for unspecified reason
        /// </returns>
        /// <remarks>
        /// @priv None
        /// </remarks>
        [DllImport("ml_perception_client", CallingConvention = CallingConvention.Cdecl)]
        public static extern MlApi.MLResult MLPerceptionInitSettings(ref MlPerception.MLPerceptionSettings settings);

        /// <summary>
        /// Start the perception system
        /// </summary>
        /// <param name="settings">The perception system starts with these settings</param>
        /// <returns>
        /// MLResult_Ok Perception system started up properly
        /// MLResult_UnspecifiedFailure Perception system failed to start properly
        /// </returns>
        /// <remarks>
        /// This function should be called before any perception functions are called
        /// @priv None
        /// </remarks>
        [DllImport("ml_perception_client", CallingConvention = CallingConvention.Cdecl)]
        public static extern MlApi.MLResult MLPerceptionStartup(ref MlPerception.MLPerceptionSettings settings);

        /// <summary>
        /// Shut down and clean up all resources used by the perception system
        /// </summary>
        /// <returns>
        /// MLResult_Ok Perception system shutdown successfully
        /// MLResult_UnspecifiedFailure Perception system failed to shutdown
        /// </returns>
        /// <remarks>
        /// This function should be called prior to exiting the program
        /// if a call to MLPerceptionStartup was called
        /// @priv None
        /// </remarks>
        [DllImport("ml_perception_client", CallingConvention = CallingConvention.Cdecl)]
        public static extern MlApi.MLResult MLPerceptionShutdown();

        /// <summary>
        /// Pull in the latest state of all persistent transforms and all
        /// enabled trackers extrapolated to the next frame time
        /// </summary>
        /// <param name="out_snapshot">Pointer to a pointer containing an MLSnapshot on success</param>
        /// <returns>
        /// MLResult_Ok Snapshot was created successfully
        /// MLResult_UnspecifiedFailure Snasphot was not created successfully
        /// </returns>
        /// <remarks>
        /// Return a MLSnapshot with this latest state This snap should be
        /// used for the duration of the frame being constructed and then
        /// released with a call to MLPerceptionReleaseSnapshot
        /// @priv None
        /// </remarks>
        [DllImport("ml_perception_client", CallingConvention = CallingConvention.Cdecl)]
        public static extern MlApi.MLResult MLPerceptionGetSnapshot(out MlSnapshot.MLSnapshot out_snapshot);

        /// <summary>
        /// Release specified MLSnapshot object
        /// </summary>
        /// <param name="snap">Pointer to a valid snap object</param>
        /// <returns>
        /// MLResult_Ok Snapshot was successfully released
        /// MLResult_UnspecifiedFailure Snapshot was not successfully released
        /// </returns>
        /// <remarks>
        /// To be called exactly once for each call to MLPerceptionGetSnapshot
        /// @priv None
        /// </remarks>
        [DllImport("ml_perception_client", CallingConvention = CallingConvention.Cdecl)]
        public static extern MlApi.MLResult MLPerceptionReleaseSnapshot(MlSnapshot.MLSnapshot snap);
    }
}
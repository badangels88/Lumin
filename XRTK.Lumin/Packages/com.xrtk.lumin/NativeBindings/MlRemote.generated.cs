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

    internal static class MlRemote
    {
        /// <summary>
        /// Checks to see if ML Remote server is running
        /// </summary>
        /// <param name="out_is_configured">Pointer to a bool indicating whether the remote
        /// server is running and is configured properly</param>
        /// <returns>
        /// MLResult_InvalidParam is_configured parameter is not valid (null)
        /// MLResult_Ok If query was successful
        /// MLResult_Timeout The ML Remote server could not be reached
        /// MLResult_UnspecifiedFailure There was an unknown error submitting the query
        /// </returns>
        /// <remarks>
        /// @priv None
        /// </remarks>
        [DllImport("ml_remote", CallingConvention = CallingConvention.Cdecl)]
        public static extern MlApi.MLResult MLRemoteIsServerConfigured(ref bool out_is_configured);
    }
}
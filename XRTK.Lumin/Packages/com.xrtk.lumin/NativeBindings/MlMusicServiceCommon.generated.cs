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

    internal static class MlMusicServiceCommon
    {
        /// <summary>
        /// MusicService errors
        /// </summary>
        public enum MLMusicServiceError : int
        {
            /// <summary>
            /// No error
            /// </summary>
            MLMusicServiceError_None = unchecked((int)0),

            /// <summary>
            /// Connectivity error
            /// </summary>
            MLMusicServiceError_Connectivity,

            /// <summary>
            /// Timeout error
            /// </summary>
            MLMusicServiceError_Timeout,

            /// <summary>
            /// General playback error
            /// </summary>
            MLMusicServiceError_GeneralPlayback,

            /// <summary>
            /// Privilege error
            /// </summary>
            MLMusicServiceError_Privilege,

            /// <summary>
            /// Service specific error
            /// </summary>
            MLMusicServiceError_ServiceSpecific,

            /// <summary>
            /// No memory error
            /// </summary>
            MLMusicServiceError_NoMemory,

            /// <summary>
            /// Unspecified error
            /// </summary>
            MLMusicServiceError_Unspecified,

            /// <summary>
            /// Ensure enum is represented as 32 bits
            /// </summary>
            MLMusicServiceError_Ensure32Bits = unchecked((int)0x7FFFFFFF),
        }

        /// <summary>
        /// MusicService info
        /// </summary>
        public enum MLMusicServiceStatus : int
        {
            /// <summary>
            /// Context changed
            /// </summary>
            MLMusicServiceStatus_ContextChanged = unchecked((int)0),

            /// <summary>
            /// Created
            /// </summary>
            MLMusicServiceStatus_Created,

            /// <summary>
            /// Logged in
            /// </summary>
            MLMusicServiceStatus_LoggedIn,

            /// <summary>
            /// Logged out
            /// </summary>
            MLMusicServiceStatus_LoggedOut,

            /// <summary>
            /// Next track
            /// </summary>
            MLMusicServiceStatus_NextTrack,

            /// <summary>
            /// Previous track
            /// </summary>
            MLMusicServiceStatus_PrevTrack,

            /// <summary>
            /// Track changed
            /// </summary>
            MLMusicServiceStatus_TrackChanged,

            /// <summary>
            /// Unknown
            /// </summary>
            MLMusicServiceStatus_Unknown,

            /// <summary>
            /// Ensure enum is represented as 32 bits
            /// </summary>
            MLMusicServiceStatus_Ensure32Bits = unchecked((int)0x7FFFFFFF),
        }

        /// <summary>
        /// MusicService playback options
        /// </summary>
        public enum MLMusicServicePlaybackOption : int
        {
            /// <summary>
            /// Playback
            /// </summary>
            MLMusicServicePlaybackOptions_Playback = unchecked((int)0),

            /// <summary>
            /// Repeat
            /// </summary>
            MLMusicServicePlaybackOptions_Repeat,

            /// <summary>
            /// Shuffle
            /// </summary>
            MLMusicServicePlaybackOptions_Shuffle,

            /// <summary>
            /// Unknown
            /// </summary>
            MLMusicServicePlaybackOptions_Unknown,

            /// <summary>
            /// Ensure enum is represented as 32 bits
            /// </summary>
            MLMusicServicePlaybackOptions_Ensure32Bits = unchecked((int)0x7FFFFFFF),
        }

        /// <summary>
        /// MusicService playback states
        /// </summary>
        public enum MLMusicServicePlaybackState : int
        {
            /// <summary>
            /// Playing
            /// </summary>
            MLMusicServicePlaybackState_Playing = unchecked((int)0),

            /// <summary>
            /// Paused
            /// </summary>
            MLMusicServicePlaybackState_Paused,

            /// <summary>
            /// Stopped
            /// </summary>
            MLMusicServicePlaybackState_Stopped,

            /// <summary>
            /// Error
            /// </summary>
            MLMusicServicePlaybackState_Error,

            /// <summary>
            /// Unknown
            /// </summary>
            MLMusicServicePlaybackState_Unknown,

            /// <summary>
            /// Ensure enum is represented as 32 bits
            /// </summary>
            MLMusicServicePlaybackState_Ensure32Bits = unchecked((int)0x7FFFFFFF),
        }

        /// <summary>
        /// MusicService repeat settings
        /// </summary>
        public enum MLMusicServiceRepeatState : int
        {
            /// <summary>
            /// Off
            /// </summary>
            MLMusicServiceRepeatState_Off = unchecked((int)0),

            /// <summary>
            /// Song
            /// </summary>
            MLMusicServiceRepeatState_Song,

            /// <summary>
            /// Album
            /// </summary>
            MLMusicServiceRepeatState_Album,

            /// <summary>
            /// Unknown
            /// </summary>
            MLMusicServiceRepeatState_Unknown,

            /// <summary>
            /// Ensure enum is represented as 32 bits
            /// </summary>
            MLMusicServiceRepeatState_Ensure32Bits = unchecked((int)0x7FFFFFFF),
        }

        /// <summary>
        /// MusicService shuffle settings
        /// </summary>
        public enum MLMusicServiceShuffleState : int
        {
            /// <summary>
            /// On
            /// </summary>
            MLMusicServiceShuffleState_On = unchecked((int)0),

            /// <summary>
            /// Off
            /// </summary>
            MLMusicServiceShuffleState_Off,

            /// <summary>
            /// Unknown
            /// </summary>
            MLMusicServiceShuffleState_Unknown,

            /// <summary>
            /// Ensure enum is represented as 32 bits
            /// </summary>
            MLMusicServiceShuffleState_Ensure32Bits = unchecked((int)0x7FFFFFFF),
        }

        /// <summary>
        /// Enumerations used to get the Metadata information of a track
        /// </summary>
        public enum MLMusicServiceTrackType : int
        {
            /// <summary>
            /// Previous track
            /// </summary>
            MLMusicServiceTrackType_Previous = unchecked((int)0),

            /// <summary>
            /// Current track
            /// </summary>
            MLMusicServiceTrackType_Current,

            /// <summary>
            /// Next track
            /// </summary>
            MLMusicServiceTrackType_Next,

            /// <summary>
            /// Ensure enum is represented as 32 bits
            /// </summary>
            MLMusicServiceTrackType_Ensure32Bits = unchecked((int)0x7FFFFFFF),
        }

        /// <summary>
        /// MusicService Metadata
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct MLMusicServiceMetadata
        {
            /// <summary>
            /// Track name/title
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string track_title;

            /// <summary>
            /// Album name
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string album_name;

            /// <summary>
            /// Album URL
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string album_url;

            /// <summary>
            /// Album cover URL
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string album_cover_url;

            /// <summary>
            /// Artist name
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string artist_name;

            /// <summary>
            /// Artist URL
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string artist_url;

            /// <summary>
            /// Length/Duration of the track in seconds
            /// </summary>
            public uint length;
        }

        /// <summary>
        /// MusicService playback options
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public readonly struct MLMusicServicePlaybackOptions : IEquatable<MLMusicServicePlaybackOptions>
        {
            public MLMusicServicePlaybackOptions(MlMusicServiceCommon.MLMusicServicePlaybackOption value) => this.Value = value;

            public readonly MlMusicServiceCommon.MLMusicServicePlaybackOption Value;

            public bool Equals(MLMusicServicePlaybackOptions other) => Value.Equals(other.Value);

            public override bool Equals(object obj) => obj is MLMusicServicePlaybackOptions other && Equals(other);

            public override int GetHashCode() => Value.GetHashCode();

            public override string ToString() => Value.ToString();

            public static implicit operator MlMusicServiceCommon.MLMusicServicePlaybackOption(MLMusicServicePlaybackOptions from) => from.Value;

            public static implicit operator MLMusicServicePlaybackOptions(MlMusicServiceCommon.MLMusicServicePlaybackOption from) => new MLMusicServicePlaybackOptions(from);

            public static bool operator ==(MLMusicServicePlaybackOptions left, MLMusicServicePlaybackOptions right) => left.Equals(right);

            public static bool operator !=(MLMusicServicePlaybackOptions left, MLMusicServicePlaybackOptions right) => !left.Equals(right);
        }
    }
}
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

    internal static class MlLocale
    {
        /// <summary>
        /// Reads the language code of the system locale
        /// </summary>
        /// <param name="out_language">Language code defined in ISO 639 It is a pointer to
        /// a string literal, and should not be freed
        /// Valid only if MLResult_Ok is returned</param>
        /// <returns>
        /// MLResult_Ok The language code was retrieved successfully
        /// MLResult_UnspecifiedFailure Failed with an unspecified error
        /// </returns>
        /// <remarks>
        /// Example : "en" and "fr"
        /// @apilevel 6
        /// @priv None
        /// </remarks>
        [DllImport("ml_locale", CallingConvention = CallingConvention.Cdecl)]
        public static extern MlApi.MLResult MLLocaleGetSystemLanguage(out string out_language);

        /// <summary>
        /// Reads the country code of the system locale
        /// </summary>
        /// <param name="out_country">Country code defined in ISO 3166, or an empty string
        /// It is a pointer to a string literal, and should not be freed
        /// Valid only if MLResult_Ok is returned</param>
        /// <returns>
        /// MLResult_Ok The country code was retrieved successfully
        /// MLResult_UnspecifiedFailure Failed with an unspecified error
        /// </returns>
        /// <remarks>
        /// Example : "us", "gb", and "fr"
        /// @apilevel 6
        /// @priv None
        /// </remarks>
        [DllImport("ml_locale", CallingConvention = CallingConvention.Cdecl)]
        public static extern MlApi.MLResult MLLocaleGetSystemCountry(out string out_country);
    }
}

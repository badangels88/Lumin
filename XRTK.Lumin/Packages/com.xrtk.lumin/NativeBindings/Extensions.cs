// Copyright (c) XRTK. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using UnityEngine;

namespace XRTK.Lumin.Native.Bindings
{
    internal static class Extensions
    {
        #region MLResult

        /// <summary>
        /// Converts the <see cref="MlApi.MLResult"/> to the specified result enum.
        /// </summary>
        /// <param name="result">The <see cref="MlApi.MLResult"/> to convert.</param>
        public static T As<T>(this MlApi.MLResult result) where T : struct, IConvertible
        {
            return (T)Enum.ToObject(typeof(T), result);
        }

        #endregion MLResult

        #region MLHandle

        /// <summary>
        /// Checks if the handle is valid.
        /// </summary>
        /// <param name="handle"></param>
        public static bool IsValid(this MlApi.MLHandle handle)
        {
            return handle.Value != ulong.MaxValue;
        }

        #endregion MLHandle

        #region MLVec3f

        /// <summary>
        /// Converts a <see cref="MlTypes.MLVec3f"/> to a <see cref="Vector3"/>.
        /// </summary>
        /// <param name="mlVec3"></param>
        /// <param name="vector3"></param>
        public static void ToUnity(this MlTypes.MLVec3f mlVec3, ref Vector3 vector3)
        {
            vector3.x = mlVec3.x;
            vector3.y = mlVec3.y;
            vector3.z = -mlVec3.z;
        }

        /// <summary>
        /// Converts a <see cref="MlTypes.MLVec3f"/> from a <see cref="Vector3"/>.
        /// </summary>
        /// <param name="mlVec3"></param>
        /// <param name="vector3"></param>
        public static void FromUnity(this ref MlTypes.MLVec3f mlVec3, Vector3 vector3)
        {
            mlVec3.x = vector3.x;
            mlVec3.y = vector3.y;
            mlVec3.z = -vector3.z;
        }

        #endregion MLVec3f

        #region MLQuaternionf

        /// <summary>
        /// Converts a <see cref="MlTypes.MLQuaternionf"/> to a <see cref="Quaternion"/>.
        /// </summary>
        /// <param name="mlQuaternion"></param>
        /// <param name="quaternion"></param>
        public static void ToUnity(this MlTypes.MLQuaternionf mlQuaternion, ref Quaternion quaternion)
        {
            quaternion.w = -mlQuaternion.w;
            quaternion.x = mlQuaternion.x;
            quaternion.y = mlQuaternion.y;
            quaternion.z = -mlQuaternion.z;
        }

        /// <summary>
        /// Converts a <see cref="Quaternion"/> to a <see cref="MlTypes.MLQuaternionf"/>.
        /// </summary>
        /// <param name="mlQuaternion"></param>
        /// <param name="quaternion"></param>
        public static void FromUnity(this ref MlTypes.MLQuaternionf mlQuaternion, Quaternion quaternion)
        {
            mlQuaternion.w = -quaternion.w;
            mlQuaternion.x = quaternion.x;
            mlQuaternion.y = quaternion.y;
            mlQuaternion.z = -quaternion.z;
        }

        #endregion MLQuaternionf
    }
}
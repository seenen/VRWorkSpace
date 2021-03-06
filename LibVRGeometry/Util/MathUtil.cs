﻿using System;

namespace LibVRGeometry.Util
{
    public sealed class MathUtil
    {
        /// <summary>
        /// 角度转换成弧度
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        /// <summary>
        /// 弧度转换成角度
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static double ConvertToAngle(double radians)
        {
            return (180 / Math.PI) * radians;
        }

    }
}

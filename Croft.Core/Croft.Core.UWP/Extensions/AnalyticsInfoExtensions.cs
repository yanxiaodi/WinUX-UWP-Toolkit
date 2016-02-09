// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnalyticsInfoExtensions.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Extensions
{
    using Windows.System.Profile;

    using WinUX.Enums;

    public static class AnalyticsInfoExtensions
    {
        /// <summary>
        /// Gets the <see cref="DeviceType"/> from the given <see cref="AnalyticsVersionInfo"/>.
        /// </summary>
        /// <param name="versionInfo">
        /// The <see cref="AnalyticsVersionInfo"/>. 
        /// </param>
        /// <returns>
        /// Returns the <see cref="DeviceType"/>.
        /// </returns>
        public static DeviceType GetDeviceType(this AnalyticsVersionInfo versionInfo)
        {
            var deviceFamily = versionInfo.DeviceFamily;

            switch (deviceFamily)
            {
                case "Windows.Desktop":
                    return DeviceType.Desktop;
                case "Windows.Mobile":
                    return DeviceType.Mobile;
                case "Windows.Team":
                    return DeviceType.SurfaceHub;
                case "Windows.IoT":
                    return DeviceType.IoT;
                case "Windows.Xbox":
                    return DeviceType.Xbox;
                default:
                    return DeviceType.Unknown;
            }
        }
    }
}
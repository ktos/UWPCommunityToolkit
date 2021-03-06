﻿// ******************************************************************
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THE CODE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE CODE OR THE USE OR OTHER DEALINGS IN THE CODE.
// ******************************************************************

using Windows.System.Profile;
using Windows.UI.ViewManagement;

namespace Microsoft.Toolkit.Uwp.SampleApp.Common
{
    /// <summary>
    /// Extension to provide DeviceForm lookup from <see cref="AnalyticsVersionInfo.DeviceFamily"/>.
    /// </summary>
    public static class AnalyticsVersionInfoExtensions
    {
        /// <summary>
        /// Retrieves the current <see cref="DeviceFormFactor"/> for the current device.
        /// </summary>
        /// <param name="versionInfo">Extended class.</param>
        /// <returns><see cref="DeviceFormFactor"/> value representing the current device type.</returns>
        public static DeviceFormFactor GetDeviceFormFactor(this AnalyticsVersionInfo versionInfo)
        {
            // TODO: If we have better ways of detecting specific platforms we should put them in here too,
            // but should still expose on AnalyticsVersionInfo as that's where most people are currently looking for this.
            switch (versionInfo.DeviceFamily)
            {
                case "Windows.Desktop":
                    return UIViewSettings.GetForCurrentView()?.UserInteractionMode == UserInteractionMode.Mouse
                        ? DeviceFormFactor.Desktop
                        : DeviceFormFactor.Tablet;

                case "Windows.Mobile":
                    return DeviceFormFactor.Mobile;

                case "Windows.Xbox":
                    return DeviceFormFactor.Xbox;

                case "Windows.Holographic":
                    return DeviceFormFactor.Holographic;

                case "Windows.Universal":
                    return DeviceFormFactor.IoT;

                case "Windows.Team":
                    return DeviceFormFactor.SurfaceHub;

                default:
                    return DeviceFormFactor.Other;
            }
        }
    }

    public enum DeviceFormFactor
    {
        Desktop,
        Holographic,
        IoT,
        Mobile,
        SurfaceHub,
        Tablet,
        Xbox,
        Other
    }
}

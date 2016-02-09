// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GeolocationHelper.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the GeolocationHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Location
{
    using System;

    using Windows.Devices.Geolocation;

    using WinUX.Diagnostics;

    /// <summary>
    /// The geolocation helper.
    /// </summary>
    public class GeolocationHelper
    {
        private Geolocator _locator;

        /// <summary>
        /// Initializes a new instance of the <see cref="GeolocationHelper"/> class.
        /// </summary>
        public GeolocationHelper()
        {
            this._locator = new Geolocator();
        }

        /// <summary>
        /// Gets the current position recorded by the locator.
        /// </summary>
        public Geoposition CurrentPosition { get; private set; }

        /// <summary>
        /// Gets or sets the on position changed action.
        /// </summary>
        public Action<Geoposition> OnPositionChanged { get; set; }

        /// <summary>
        /// Initializes the GeolocationHelper.
        /// </summary>
        public void Initialize()
        {
            if (this._locator == null)
            {
                this._locator = new Geolocator();
            }

            this._locator.PositionChanged += this.OnLocationChanged;

            this.CurrentPosition = this._locator.GetGeopositionAsync().AsTask().Result;
        }

        private void OnLocationChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            this.CurrentPosition = args.Position;

            if (this.OnPositionChanged != null)
            {
                try
                {
                    this.OnPositionChanged(this.CurrentPosition);
                }
                catch (Exception ex)
                {
                    Logger.Log.Debug(ex.Message);
                }
            }
        }
    }
}
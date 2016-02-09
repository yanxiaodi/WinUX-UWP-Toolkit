// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StorageFileExtensions.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Windows.Storage;
    using Windows.Storage.FileProperties;

    using WinUX.Storage;

    /// <summary>
    /// A collection of StorageFile extensions.
    /// </summary>
    public static class StorageFileExtensions
    {
        /// <summary>
        /// Gets a collection of basic properties from a StorageFile.
        /// </summary>
        /// <param name="file">
        /// The file.
        /// </param>
        /// <returns>
        /// Returns a collection of StorageFileProperty.
        /// </returns>
        public static async Task<IEnumerable<StorageFileProperty>> GetPropertiesAsync(this StorageFile file)
        {
            var properties = new List<StorageFileProperty>();

            GetDocumentProperties(properties, await file.Properties.GetDocumentPropertiesAsync());
            GetImageProperties(properties, await file.Properties.GetImagePropertiesAsync());
            GetMusicProperties(properties, await file.Properties.GetMusicPropertiesAsync());
            GetVideoProperties(properties, await file.Properties.GetVideoPropertiesAsync());

            return properties;
        }

        /// <summary>
        /// The get extended properties.
        /// </summary>
        /// <param name="file">
        /// The file.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<IEnumerable<StorageFileProperty>> GetExtendedPropertiesAsync(this StorageFile file)
        {
            var properties = new List<StorageFileProperty>();

            var fileProps = await file.Properties.RetrievePropertiesAsync(null); // Gets all available properties for the file.

            ProcessExtendedProperties(properties, fileProps);

            return properties;
        }

        private static void ProcessExtendedProperties(ICollection<StorageFileProperty> results, IDictionary<string, object> props)
        {
            if (props.ContainsKey("System.ItemName"))
            {
                var fileNameObj = props["System.ItemName"];
                if (fileNameObj != null)
                {
                    var fileName = fileNameObj.ToString();
                    if (!fileName.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "File name") == null)
                        {
                            results.Add(new StorageFileProperty("File name", fileName));
                        }
                    }
                }
            }

            if (props.ContainsKey("System.FileOwner"))
            {
                var fileOwnerObj = props["System.FileOwner"];
                if (fileOwnerObj != null)
                {
                    var fileOwner = fileOwnerObj.ToString();
                    if (!fileOwner.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "File owner") == null)
                        {
                            results.Add(new StorageFileProperty("File owner", fileOwner));
                        }
                    }
                }
            }

            if (props.ContainsKey("System.Size"))
            {
                var fileSizeObj = props["System.Size"];
                if (fileSizeObj != null)
                {
                    var fileSize = fileSizeObj.ToString();
                    if (!fileSize.IsEmpty())
                    {
                        double fileSizeDouble;
                        var parsed = double.TryParse(fileSize, out fileSizeDouble);

                        if (parsed)
                        {
                            if (results.FirstOrDefault(x => x.Name == "File size") == null)
                            {
                                results.Add(new StorageFileProperty("File size", fileSizeDouble.ToFileSize()));
                            }
                        }
                    }
                }
            }

            if (props.ContainsKey("System.DateCreated"))
            {
                var dateCreatedObj = props["System.DateCreated"];
                if (dateCreatedObj != null)
                {
                    var dateCreated = dateCreatedObj.ToString();
                    if (!dateCreated.IsEmpty())
                    {
                        if (dateCreated.IsValidDate())
                        {
                            if (results.FirstOrDefault(x => x.Name == "Date created") == null)
                            {
                                results.Add(new StorageFileProperty("Date created", dateCreated));
                            }
                        }
                    }
                }
            }

            if (props.ContainsKey("System.Photo.DateTaken"))
            {
                var dateTakenObj = props["System.Photo.DateTaken"];
                if (dateTakenObj != null)
                {
                    var dateTaken = dateTakenObj.ToString();
                    if (!dateTaken.IsEmpty())
                    {
                        if (dateTaken.IsValidDate())
                        {
                            if (results.FirstOrDefault(x => x.Name == "Date taken") == null)
                            {
                                results.Add(new StorageFileProperty("Date taken", dateTaken));
                            }
                        }
                    }
                }
            }

            if (props.ContainsKey("System.ItemTypeText"))
            {
                var itemTypeObj = props["System.ItemTypeText"];
                if (itemTypeObj != null)
                {
                    var itemType = itemTypeObj.ToString();
                    if (!itemType.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "Item type") == null)
                        {
                            results.Add(new StorageFileProperty("Item type", itemType));
                        }
                    }
                }
            }

            if (props.ContainsKey("System.MIMEType"))
            {
                var mimeTypeObj = props["System.MIMEType"];
                if (mimeTypeObj != null)
                {
                    var mimeType = mimeTypeObj.ToString();
                    if (!mimeType.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "MIME type") == null)
                        {
                            results.Add(new StorageFileProperty("MIME type", mimeType));
                        }
                    }
                }
            }

            ProcessPhotoProperties(results, props);
            ProcessVideoProperties(results, props);
            ProcessAudioProperties(results, props);

            if (props.ContainsKey("System.ApplicationName"))
            {
                var applicationNameObj = props["System.ApplicationName"];
                if (applicationNameObj != null)
                {
                    var applicationName = applicationNameObj.ToString();
                    if (!applicationName.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "Application name") == null)
                        {
                            results.Add(new StorageFileProperty("Application name", applicationName));
                        }
                    }
                }
            }

            if (props.ContainsKey("System.DRM.IsProtected"))
            {
                var drmProtectedObj = props["System.DRM.IsProtected"];
                if (drmProtectedObj != null)
                {
                    var drmProtected = drmProtectedObj.ToString();
                    if (!drmProtected.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "DRM protected") == null)
                        {
                            results.Add(new StorageFileProperty("DRM protected", drmProtected));
                        }
                    }
                }
            }

            if (props.ContainsKey("System.ComputerName"))
            {
                var computerNameObj = props["System.ComputerName"];
                if (computerNameObj != null)
                {
                    var computerName = computerNameObj.ToString();
                    if (!computerName.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "Originating PC") == null)
                        {
                            results.Add(new StorageFileProperty("Originating PC", computerName));
                        }
                    }
                }
            }

            ProcessGpsProperties(results, props);
        }

        private static void ProcessPhotoProperties(ICollection<StorageFileProperty> results, IDictionary<string, object> props)
        {
            if (props.ContainsKey("System.Image.Dimensions"))
            {
                var imageDimensionsObj = props["System.Image.Dimensions"];
                if (imageDimensionsObj != null)
                {
                    var imageDimensions = imageDimensionsObj.ToString();
                    if (!imageDimensions.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "Image dimensions") == null)
                        {
                            results.Add(new StorageFileProperty("Image dimensions", imageDimensions));
                        }
                    }
                }
            }

            if (props.ContainsKey("System.Photo.CameraManufacturer"))
            {
                var cameraManufacturerObj = props["System.Photo.CameraManufacturer"];
                if (cameraManufacturerObj != null)
                {
                    var cameraManufacturer = cameraManufacturerObj.ToString();
                    if (!cameraManufacturer.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "Camera manufacturer") == null)
                        {
                            results.Add(new StorageFileProperty("Camera manufacturer", cameraManufacturer));
                        }
                    }
                }
            }

            if (props.ContainsKey("System.Photo.CameraModel"))
            {
                var cameraModelObj = props["System.Photo.CameraModel"];
                if (cameraModelObj != null)
                {
                    var cameraModel = cameraModelObj.ToString();
                    if (!cameraModel.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "Camera model") == null)
                        {
                            results.Add(new StorageFileProperty("Camera model", cameraModel));
                        }
                    }
                }
            }

            if (props.ContainsKey("System.Photo.FlashText"))
            {
                var cameraFlashObj = props["System.Photo.FlashText"];
                if (cameraFlashObj != null)
                {
                    var cameraFlash = cameraFlashObj.ToString();
                    if (!cameraFlash.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "Camera flash") == null)
                        {
                            results.Add(new StorageFileProperty("Camera flash", cameraFlash));
                        }
                    }
                }
            }

            if (props.ContainsKey("System.Photo.ISOSpeed"))
            {
                var cameraIsoObj = props["System.Photo.ISOSpeed"];
                if (cameraIsoObj != null)
                {
                    var cameraIso = cameraIsoObj.ToString();
                    if (!cameraIso.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "Camera ISO") == null)
                        {
                            results.Add(new StorageFileProperty("Camera ISO", cameraIso));
                        }
                    }
                }
            }

            if (props.ContainsKey("System.Photo.ShutterSpeed"))
            {
                var cameraShutterSpeedObj = props["System.Photo.ShutterSpeed"];
                if (cameraShutterSpeedObj != null)
                {
                    var cameraShutterSpeed = cameraShutterSpeedObj.ToString();
                    if (!cameraShutterSpeed.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "Camera shutter speed") == null)
                        {
                            results.Add(new StorageFileProperty("Camera shutter speed", cameraShutterSpeed));
                        }
                    }
                }
            }

            if (props.ContainsKey("System.Photo.Aperture"))
            {
                var cameraApertureObj = props["System.Photo.Aperture"];
                if (cameraApertureObj != null)
                {
                    var cameraAperture = cameraApertureObj.ToString();
                    if (!cameraAperture.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "Camera aperture") == null)
                        {
                            results.Add(new StorageFileProperty("Camera aperture", cameraAperture));
                        }
                    }
                }
            }

            if (props.ContainsKey("System.Photo.ExposureTime"))
            {
                var cameraExposureObj = props["System.Photo.ExposureTime"];
                if (cameraExposureObj != null)
                {
                    var cameraExposure = cameraExposureObj.ToString();
                    if (!cameraExposure.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "Camera exposure time") == null)
                        {
                            results.Add(new StorageFileProperty("Camera exposure time", cameraExposure));
                        }
                    }
                }
            }

            if (props.ContainsKey("System.Photo.WhiteBalanceText"))
            {
                var cameraWhiteBalanceObj = props["System.Photo.WhiteBalanceText"];
                if (cameraWhiteBalanceObj != null)
                {
                    var cameraWhiteBalance = cameraWhiteBalanceObj.ToString();
                    if (!cameraWhiteBalance.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "Camera white balance") == null)
                        {
                            results.Add(new StorageFileProperty("Camera white balance", cameraWhiteBalance));
                        }
                    }
                }
            }

            if (props.ContainsKey("System.Photo.DigitalZoom"))
            {
                var cameraDigitalZoomObj = props["System.Photo.DigitalZoom"];
                if (cameraDigitalZoomObj != null)
                {
                    var cameraDigitalZoom = cameraDigitalZoomObj.ToString();
                    if (!cameraDigitalZoom.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "Camera digital zoom level") == null)
                        {
                            results.Add(new StorageFileProperty("Camera digital zoom level", cameraDigitalZoom));
                        }
                    }
                }
            }
        }

        private static void ProcessVideoProperties(ICollection<StorageFileProperty> results, IDictionary<string, object> props)
        {
            if (props.ContainsKey("System.Video.FrameWidth") && props.ContainsKey("System.Video.FrameHeight"))
            {
                var frameWidthObj = props["System.Video.FrameWidth"];
                var frameHeightObj = props["System.Video.FrameHeight"];

                if (frameWidthObj != null && frameHeightObj != null)
                {
                    var frameWidth = frameWidthObj.ToString();
                    var frameHeight = frameHeightObj.ToString();

                    if (!frameWidth.IsEmpty() || !frameHeight.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "Video dimensions") == null)
                        {
                            results.Add(
                                new StorageFileProperty("Video dimensions", string.Format("{0} x {1}", frameWidth, frameHeight)));
                        }
                    }
                }
            }

            if (props.ContainsKey("System.Media.Duration"))
            {
                var mediaDurationObj = props["System.Media.Duration"];
                if (mediaDurationObj != null)
                {
                    var mediaDuration = mediaDurationObj.ToString();
                    if (!mediaDuration.IsEmpty())
                    {
                        double durationDouble;
                        var parsed = double.TryParse(mediaDuration, out durationDouble);

                        if (parsed)
                        {
                            var duration = TimeSpan.FromSeconds(durationDouble);

                            if (results.FirstOrDefault(x => x.Name == "Media duration") == null)
                            {
                                results.Add(new StorageFileProperty("Media duration", duration.ToString("g")));
                            }
                        }
                    }
                }
            }
        }

        private static void ProcessAudioProperties(ICollection<StorageFileProperty> results, IDictionary<string, object> props)
        {
            if (props.ContainsKey("System.Music.DisplayArtist"))
            {
                var audioArtistObj = props["System.Music.DisplayArtist"];
                if (audioArtistObj != null)
                {
                    var audioArtist = audioArtistObj.ToString();
                    if (!audioArtist.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "Audio artist") == null)
                        {
                            results.Add(new StorageFileProperty("Audio artist", audioArtist));
                        }
                    }
                }
            }

            if (props.ContainsKey("System.Media.Year"))
            {
                var mediaYearObj = props["System.Media.Year"];
                if (mediaYearObj != null)
                {
                    var mediaYear = mediaYearObj.ToString();
                    if (!mediaYear.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "Media year") == null)
                        {
                            results.Add(new StorageFileProperty("Media year", mediaYear));
                        }
                    }
                }
            }
        }

        private static void ProcessGpsProperties(ICollection<StorageFileProperty> results, IDictionary<string, object> props)
        {
            if (props.ContainsKey("System.GPS.LatitudeDecimal") && props.ContainsKey("System.GPS.LongitudeDecimal"))
            {
                var latitudeObj = props["System.GPS.LatitudeDecimal"];
                var longitudeObj = props["System.GPS.LongitudeDecimal"];

                if (latitudeObj != null && longitudeObj != null)
                {
                    var latitude = latitudeObj.ToString();
                    var longitude = longitudeObj.ToString();

                    if (!latitude.IsEmpty() || !longitude.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "GPS latitude") == null)
                        {
                            results.Add(new StorageFileProperty("GPS latitude", latitude));
                        }

                        if (results.FirstOrDefault(x => x.Name == "GPS longitude") == null)
                        {
                            results.Add(new StorageFileProperty("GPS longitude", longitude));
                        }
                    }
                }
            }

            if (props.ContainsKey("System.GPS.Altitude"))
            {
                var gpsAltitudeObj = props["System.GPS.Altitude"];
                if (gpsAltitudeObj != null)
                {
                    var gpsAltitude = gpsAltitudeObj.ToString();
                    if (!gpsAltitude.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "GPS altitude") == null)
                        {
                            results.Add(new StorageFileProperty("GPS altitude", gpsAltitude));
                        }
                    }
                }
            }

            if (props.ContainsKey("System.GPS.DOP"))
            {
                var gpsDopObj = props["System.GPS.DOP"];
                if (gpsDopObj != null)
                {
                    var gpsDop = gpsDopObj.ToString();
                    if (!gpsDop.IsEmpty())
                    {
                        if (results.FirstOrDefault(x => x.Name == "GPS dilution of precision") == null)
                        {
                            results.Add(new StorageFileProperty("GPS dilution of precision", gpsDop));
                        }
                    }
                }
            }
        }

        private static void GetDocumentProperties(ICollection<StorageFileProperty> results, DocumentProperties props)
        {
            var title = props.Title;
            var authors = props.Author;
            var comment = props.Comment;

            if (!title.IsEmpty())
            {
                if (results.FirstOrDefault(x => x.Name == "Title") == null)
                {
                    results.Add(new StorageFileProperty("Title", title));
                }
            }

            if (authors != null)
            {
                if (results.FirstOrDefault(x => x.Name == "Author") == null)
                {
                    foreach (var author in authors.Where(author => !author.IsEmpty()))
                    {
                        results.Add(new StorageFileProperty("Author", author));
                    }
                }
            }

            if (!comment.IsEmpty())
            {
                if (results.FirstOrDefault(x => x.Name == "Comment") == null)
                {
                    results.Add(new StorageFileProperty("Comment", comment));
                }
            }
        }

        private static void GetImageProperties(ICollection<StorageFileProperty> results, ImageProperties props)
        {
            var title = props.Title;
            var dateTaken = props.DateTaken.ToString("G");

            var manufacturer = props.CameraManufacturer;
            var model = props.CameraModel;

            var height = props.Height;
            var width = props.Width;

            var latitude = props.Latitude.ToString();
            var longitude = props.Longitude.ToString();

            if (!title.IsEmpty())
            {
                if (results.FirstOrDefault(x => x.Name == "Title") == null)
                {
                    results.Add(new StorageFileProperty("Title", title));
                }
            }

            if (!dateTaken.IsEmpty())
            {
                if (dateTaken.IsValidDate())
                {
                    if (results.FirstOrDefault(x => x.Name == "Date Taken") == null)
                    {
                        results.Add(new StorageFileProperty("Date Taken", dateTaken));
                    }
                }
            }

            if (!manufacturer.IsEmpty())
            {
                if (results.FirstOrDefault(x => x.Name == "Manufacturer") == null)
                {
                    results.Add(new StorageFileProperty("Manufacturer", manufacturer));
                }
            }

            if (!model.IsEmpty())
            {
                if (results.FirstOrDefault(x => x.Name == "Model") == null)
                {
                    results.Add(new StorageFileProperty("Model", model));
                }
            }

            if (height != 0 || width != 0)
            {
                if (results.FirstOrDefault(x => x.Name == "Height") == null)
                {
                    results.Add(new StorageFileProperty("Height", height));
                }

                if (results.FirstOrDefault(x => x.Name == "Width") == null)
                {
                    results.Add(new StorageFileProperty("Width", width));
                }
            }


            if (!latitude.IsEmpty())
            {
                if (results.FirstOrDefault(x => x.Name == "GPS latitude") == null)
                {
                    results.Add(new StorageFileProperty("GPS latitude", latitude));
                }
            }

            if (!longitude.IsEmpty())
            {
                if (results.FirstOrDefault(x => x.Name == "GPS longitude") == null)
                {
                    results.Add(new StorageFileProperty("GPS longitude", longitude));
                }
            }
        }

        private static void GetMusicProperties(ICollection<StorageFileProperty> results, MusicProperties props)
        {
            var title = props.Title;
            var artist = props.Artist;
            var duration = props.Duration;
            var bitRate = props.Bitrate;

            if (!title.IsEmpty())
            {
                if (results.FirstOrDefault(x => x.Name == "Title") == null)
                {
                    results.Add(new StorageFileProperty("Title", title));
                }
            }

            if (!artist.IsEmpty())
            {
                if (results.FirstOrDefault(x => x.Name == "Artist") == null)
                {
                    results.Add(new StorageFileProperty("Artist", artist));
                }
            }

            if (duration != TimeSpan.FromSeconds(0))
            {
                var val = duration.ToString("G");
                if (!val.IsEmpty())
                {
                    if (results.FirstOrDefault(x => x.Name == "Duration") == null)
                    {
                        results.Add(new StorageFileProperty("Duration", val));
                    }
                }
            }

            if (bitRate != 0)
            {
                if (results.FirstOrDefault(x => x.Name == "Bitrate") == null)
                {
                    results.Add(new StorageFileProperty("Bitrate", bitRate));
                }
            }
        }

        private static void GetVideoProperties(ICollection<StorageFileProperty> results, VideoProperties props)
        {
            var title = props.Title;
            var subTitle = props.Subtitle;
            var duration = props.Duration;
            var bitRate = props.Bitrate;
            var height = props.Height;
            var width = props.Width;

            var latitude = props.Latitude.ToString();
            var longitude = props.Longitude.ToString();

            if (!title.IsEmpty())
            {
                if (results.FirstOrDefault(x => x.Name == "Title") == null)
                {
                    results.Add(new StorageFileProperty("Title", title));
                }
            }

            if (!subTitle.IsEmpty())
            {
                if (results.FirstOrDefault(x => x.Name == "Subtitle") == null)
                {
                    results.Add(new StorageFileProperty("Subtitle", subTitle));
                }
            }

            if (duration != TimeSpan.FromSeconds(0))
            {
                var val = duration.ToString("G");
                if (!val.IsEmpty())
                {
                    if (results.FirstOrDefault(x => x.Name == "Duration") == null)
                    {
                        results.Add(new StorageFileProperty("Duration", val));
                    }
                }
            }

            if (bitRate != 0)
            {
                if (results.FirstOrDefault(x => x.Name == "Bitrate") == null)
                {
                    results.Add(new StorageFileProperty("Bitrate", bitRate));
                }
            }

            if (height != 0 || width != 0)
            {
                if (results.FirstOrDefault(x => x.Name == "Height") == null)
                {
                    results.Add(new StorageFileProperty("Height", height));
                }

                if (results.FirstOrDefault(x => x.Name == "Width") == null)
                {
                    results.Add(new StorageFileProperty("Width", width));
                }
            }

            if (!latitude.IsEmpty())
            {
                if (results.FirstOrDefault(x => x.Name == "GPS latitude") == null)
                {
                    results.Add(new StorageFileProperty("GPS latitude", latitude));
                }
            }

            if (!longitude.IsEmpty())
            {
                if (results.FirstOrDefault(x => x.Name == "GPS longitude") == null)
                {
                    results.Add(new StorageFileProperty("GPS longitude", longitude));
                }
            }
        }
    }
}

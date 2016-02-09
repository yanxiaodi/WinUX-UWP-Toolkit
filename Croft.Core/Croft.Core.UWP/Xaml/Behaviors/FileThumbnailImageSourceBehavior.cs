// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileThumbnailImageSourceBehavior.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Xaml.Behaviors
{
    using System;

    using Windows.Storage;
    using Windows.Storage.FileProperties;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Imaging;

    using Microsoft.Xaml.Interactivity;

    /// <summary>
    /// The file thumbnail image source behavior.
    /// </summary>
    public class FileThumbnailImageSourceBehavior : Behavior
    {
        public static readonly DependencyProperty FileProperty = DependencyProperty.Register(
            "File",
            typeof(StorageFile),
            typeof(FileThumbnailImageSourceBehavior),
            new PropertyMetadata(null, OnFileChanged));

        private static async void OnFileChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
            {
                return;
            }

            var behavior = d as FileThumbnailImageSourceBehavior;
            if (behavior?.Parent == null)
            {
                return;
            }

            var thumb =
                await behavior.File.GetThumbnailAsync(ThumbnailMode.SingleItem, 32, ThumbnailOptions.ResizeThumbnail);

            if (thumb == null)
            {
                return;
            }

            var bitmapImage = new BitmapImage();
            bitmapImage.SetSource(thumb.CloneStream());

            behavior.Parent.Source = bitmapImage;
        }

        public StorageFile File
        {
            get
            {
                return (StorageFile)this.GetValue(FileProperty);
            }
            set
            {
                this.SetValue(FileProperty, value);
            }
        }

        public Image Parent => this.AssociatedObject as Image;
    }
}
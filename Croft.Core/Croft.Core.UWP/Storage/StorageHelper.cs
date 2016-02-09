// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StorageHelper.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Storage
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Windows.Storage;
    using Windows.Storage.Streams;

    using WinUX.Enums;

    /// <summary>
    /// The storage helper.
    /// </summary>
    public class StorageHelper
    {
        private const string LogsStorageFolderName = "Logs";
        private const string UserStorageFolderName = "User";

        /// <summary>
        /// Saves a byte array to a StorageFile in the TemporaryFolder with a given file extension, e.g. .jpg
        /// </summary>
        /// <param name="bytes">
        /// The byte array to save.
        /// </param>
        /// <param name="extension">
        /// The file extension. For example, .jpg
        /// </param>
        /// <returns>
        /// Returns the temporarily stored file.
        /// </returns>
        public async Task<StorageFile> SaveBytesToTempFolderAsync(byte[] bytes, string extension)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            var fileName = $"{Guid.NewGuid()}{extension}";
            var folder = ApplicationData.Current.TemporaryFolder;
            var tempFile = await folder.CreateFileAsync(fileName);
            await FileIO.WriteBytesAsync(tempFile, bytes);

            return tempFile;
        }

        /// <summary>
        /// Saves a string value to a StorageFile in the TemporaryFolder with a given file extension, e.g. .txt
        /// </summary>
        /// <param name="content">
        /// The string value to save.
        /// </param>
        /// <param name="extension">
        /// The file extension. For example, .txt
        /// </param>
        /// <returns>
        /// Returns the temporarily stored file.
        /// </returns>
        public async Task<StorageFile> SaveTextToTempFolderAsync(string content, string extension)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException(nameof(content));
            }

            var fileName = $"{Guid.NewGuid()}{extension}";
            var folder = ApplicationData.Current.TemporaryFolder;
            var tempFile = await folder.CreateFileAsync(fileName);
            await FileIO.WriteTextAsync(tempFile, content);

            return tempFile;
        }

        /// <summary>
        /// Saves a byte array to a StorageFile in the given StorageFolder with a given file name, e.g. image.jpg
        /// </summary>
        /// <param name="folder">
        /// The StorageFolder to save the file to.
        /// </param>
        /// <param name="bytes">
        /// The byte array to save.
        /// </param>
        /// <param name="fileName">
        /// The file name. For example, image.jpg
        /// </param>
        /// <returns>
        /// Returns the stored file.
        /// </returns>
        public async Task<StorageFile> SaveBytesToFolderAsync(StorageFolder folder, byte[] bytes, string fileName)
        {
            if (folder == null)
            {
                throw new ArgumentNullException(nameof(folder));
            }

            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            var file = await folder.CreateFileAsync(fileName);
            await FileIO.WriteBytesAsync(file, bytes);

            return file;
        }

        /// <summary>
        /// Saves a string value to a StorageFile in the given StorageFolder with a given file name, e.g. text.txt
        /// </summary>
        /// <param name="folder">
        /// The StorageFolder to save the file to.
        /// </param>
        /// <param name="text">
        /// The string value to save.
        /// </param>
        /// <param name="fileName">
        /// The file name. For example, text.txt
        /// </param>
        /// <returns>
        /// Returns the stored file.
        /// </returns>
        public async Task<StorageFile> SaveTextToFolderAsync(StorageFolder folder, string text, string fileName)
        {
            if (folder == null)
            {
                throw new ArgumentNullException(nameof(folder));
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            var file = await folder.CreateFileAsync(fileName);
            await FileIO.WriteTextAsync(file, text);

            return file;
        }

        /// <summary>
        /// Retrieves a StorageFile from a given StorageFolderLocation with a given file name. Optional parameter to create the file if it doesn't exist.
        /// </summary>
        /// <param name="location">
        /// The StorageFolderLocation.
        /// </param>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <param name="createIfNotExists">
        /// Whether to create the file if it doesn't exist.
        /// </param>
        /// <returns>
        /// Returns the StorageFile, if exists.
        /// </returns>
        public async Task<StorageFile> RetrieveStorageFileAsync(StorageFolderLocation location, string fileName, bool createIfNotExists)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            var folder = await this.RetrieveStorageFolderAsync(location);

            var file = await GetFileAsync(folder, fileName);
            if (file != null || !createIfNotExists)
            {
                return file;
            }

            file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);

            return file;
        }

        /// <summary>
        /// Retrieves a StorageFolder for a given StorageFolderLocation.
        /// </summary>
        /// <param name="location">
        /// The StorageFolderLocation to find.
        /// </param>
        /// <returns>
        /// Returns the StorageFolder.
        /// </returns>
        public async Task<StorageFolder> RetrieveStorageFolderAsync(StorageFolderLocation location)
        {
            var folder = ApplicationData.Current.LocalFolder;
            switch (location)
            {
                case StorageFolderLocation.Root:
                    break;
                case StorageFolderLocation.User:
                    folder = await folder.CreateFolderAsync(UserStorageFolderName, CreationCollisionOption.OpenIfExists);
                    break;
                case StorageFolderLocation.Logs:
                    folder = await folder.CreateFolderAsync(LogsStorageFolderName, CreationCollisionOption.OpenIfExists);
                    break;
                case StorageFolderLocation.Temp:
                    folder = ApplicationData.Current.TemporaryFolder;
                    break;
            }

            return folder;
        }

        /// <summary>
        /// Retrieves a string value from a StorageFile by the given file path.
        /// </summary>
        /// <param name="filePath">
        /// The file path to the destined StorageFile.
        /// </param>
        /// <returns>
        /// Returns the stored string value of the StorageFile located at the given file path.
        /// </returns>
        public async Task<string> GetTextFromFileAsync(string filePath)
        {
            if (string.IsNullOrWhiteSpace("filePath"))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            var file = await StorageFile.GetFileFromPathAsync(filePath);
            var textContent = await FileIO.ReadTextAsync(file);

            return textContent;
        }

        /// <summary>
        /// Retrieves a byte array from a StorageFile by the given file path.
        /// </summary>
        /// <param name="filePath">
        /// The file path to the destined StorageFile.
        /// </param>
        /// <returns>
        /// Returns the stored byte array of the StorageFile located at the given file path.
        /// </returns>
        public async Task<byte[]> GetByteArrayFromFileAsync(string filePath)
        {
            filePath = filePath.Replace('/', '\\');
            var file = await StorageFile.GetFileFromPathAsync(filePath);

            if (file == null)
            {
                throw new FileNotFoundException($"Unable to find file at {filePath}");
            }

            using (IRandomAccessStream stream = await file.OpenReadAsync())
            {
                using (var reader = new DataReader(stream.GetInputStreamAt(0)))
                {
                    await reader.LoadAsync((uint)stream.Size);
                    var bytes = new byte[stream.Size];
                    reader.ReadBytes(bytes);
                    return bytes;
                }
            }
        }

        private static async Task<StorageFile> GetFileAsync(StorageFolder folder, string fileName)
        {
            var files = await folder.GetFilesAsync();
            var file = files.FirstOrDefault(x => x.Name == fileName);
            return file;
        }
    }
}

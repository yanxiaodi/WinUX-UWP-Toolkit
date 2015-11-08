// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageDialogHelper.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the MessageDialogHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Croft.Core.Helpers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Windows.ApplicationModel.Core;
    using Windows.UI.Core;
    using Windows.UI.Popups;

    public class MessageDialogHelper : IDisposable
    {
        private SemaphoreSlim _semaphore = new SemaphoreSlim(1);

        public void Show(string message)
        {
            this.ShowAsync(message).ConfigureAwait(false);
        }

        public void Show(string title, string message)
        {
            this.ShowAsync(title, message).ConfigureAwait(false);
        }

        public void Show(string message, params IUICommand[] commands)
        {
            this.ShowAsync(message, commands).ConfigureAwait(false);
        }

        public void Show(string title, string message, params IUICommand[] commands)
        {
            this.ShowAsync(title, message, commands).ConfigureAwait(false);
        }

        public async Task ShowAsync(string message)
        {
            await this.ShowAsync(null, message, null);
        }

        public async Task ShowAsync(string title, string message)
        {
            await this.ShowAsync(title, message, null);
        }

        public async Task ShowAsync(string message, params IUICommand[] commands)
        {
            await this.ShowAsync(null, message, commands);
        }

        public async Task ShowAsync(string title, string message, IUICommand[] commands)
        {
            var tcs = new TaskCompletionSource<bool>();

            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                async () =>
                    {
                        await this._semaphore.WaitAsync();

                        var dialog = new MessageDialog(message)
                                         {
                                             Title =
                                                 string.IsNullOrWhiteSpace(title)
                                                     ? "Alert!"
                                                     : title
                                         };

                        if (commands != null)
                        {
                            foreach (var command in commands)
                            {
                                dialog.Commands.Add(command);
                            }
                        }

                        await dialog.ShowAsync();
                        this._semaphore.Release();
                        tcs.SetResult(true);
                    });

            await tcs.Task;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || this._semaphore == null)
            {
                return;
            }

            this._semaphore.Dispose();
            this._semaphore = null;
        }
    }
}

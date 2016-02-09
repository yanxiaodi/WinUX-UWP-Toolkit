namespace WinUX.Xaml.StateTriggers
{
    using System;

    using Windows.Networking.Connectivity;
    using Windows.UI.Core;
    using Windows.UI.Xaml;

    using WinUX.Common;
    using WinUX.Enums;

    public class NetworkConnectionTrigger : StateTriggerBase
    {
        public event EventHandler IsActiveChanged;

        private bool _isActive;

        public static readonly DependencyProperty ConnectionModeProperty = DependencyProperty.Register(
            "ConnectionMode",
            typeof(NetworkConnectionMode),
            typeof(NetworkConnectionTrigger),
            new PropertyMetadata(NetworkConnectionMode.Unknown, OnConnectionModeChanged));

        private static void OnConnectionModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var trigger = d as NetworkConnectionTrigger;
            trigger?.UpdateState();
        }

        public NetworkConnectionMode ConnectionMode
        {
            get
            {
                return (NetworkConnectionMode)this.GetValue(ConnectionModeProperty);
            }
            set
            {
                this.SetValue(ConnectionModeProperty, value);
            }
        }

        public NetworkConnectionTrigger()
        {
            var wel = new WeakEventListener<NetworkConnectionTrigger, object>(this)
                          {
                              OnEventAction =
                                  (trigger, o) =>
                                  this.OnNetworkStatusChanged(
                                      ),
                              OnDetachAction =
                                  (trigger, listener) =>
                                  NetworkInformation
                                      .NetworkStatusChanged -=
                                  listener.OnEvent
                          };

            NetworkInformation.NetworkStatusChanged += wel.OnEvent;
            this.UpdateState();
        }

        public bool IsActive
        {
            get
            {
                return this._isActive;
            }
            private set
            {
                if (this._isActive == value)
                {
                    return;
                }

                this._isActive = value;
                this.SetActive(value); // Sets the trigger as active causing the UI to update

                this.IsActiveChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void OnNetworkStatusChanged()
        {
            var asyncAction = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, this.UpdateState);
        }

        private void UpdateState()
        {
            var connectionProfile = NetworkInformation.GetInternetConnectionProfile();

            if (connectionProfile == null)
            {
                this.IsActive = this.ConnectionMode == NetworkConnectionMode.Disconnected;
            }
            else
            {
                var connectionState = connectionProfile.GetNetworkConnectivityLevel();

                if (connectionState != NetworkConnectivityLevel.InternetAccess)
                {
                    this.IsActive = this.ConnectionMode == NetworkConnectionMode.Disconnected;
                }
                else
                {
                    if (connectionProfile.NetworkAdapter.IanaInterfaceType.Equals(6))
                    {
                        this.IsActive = this.ConnectionMode == NetworkConnectionMode.Ethernet;
                    }
                    else if (connectionProfile.IsWlanConnectionProfile)
                    {
                        this.IsActive = this.ConnectionMode == NetworkConnectionMode.WiFi;
                    }
                    else if (connectionProfile.IsWwanConnectionProfile)
                    {
                        this.IsActive = this.ConnectionMode == NetworkConnectionMode.Mobile;
                    }
                }
            }
        }
    }
}
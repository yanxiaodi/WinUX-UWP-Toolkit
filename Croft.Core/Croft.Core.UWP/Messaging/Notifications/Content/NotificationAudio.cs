namespace WinUX.Messaging.Notifications.Content
{
    using System;

    using WinUX.Messaging.Notifications.XmlParts;

    public sealed class NotificationAudio
    {
        public Uri SourceUri { get; set; }

        public bool Loop { get; set; } = NotificationAudioPart.DefaultLoop;

        public bool Silent { get; set; } = NotificationAudioPart.DefaultSilent;

        internal NotificationAudioPart ToXmlPart()
        {
            return new NotificationAudioPart { SourceUri = this.SourceUri, Loop = this.Loop, Silent = this.Silent };
        }
    }
}
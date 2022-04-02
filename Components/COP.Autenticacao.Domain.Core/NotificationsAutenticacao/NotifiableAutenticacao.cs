using Flunt.Notifications;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace COP.Autenticacao.Domain.Core.NotificationsAutenticacao
{
    public class NotifiableAutenticacao
    {
        public List<Notificacao> Notifications { get; set; } = new List<Notificacao>();
        [JsonIgnore]
        public bool Invalid { get { return Notifications != null && Notifications.Count > 0; } }
        [JsonIgnore]
        public bool Valid { get { return Notifications == null || Notifications.Count == 0; } }

        public void AddNotification(string property, string message)
        {
            if (Notifications == null)
                Notifications = new List<Notificacao>();

            Notifications.Add(new Notificacao(property, message));

        }

        public void AddNotification(Notificacao notification)
        {
            if (notification == null) return;
            if (Notifications == null)
                Notifications = new List<Notificacao>();

            Notifications.Add(notification);
        }

        public void AddNotifications(IReadOnlyCollection<Notificacao> notifications)
        {
            if (notifications == null) return;
            if (Notifications == null)
                Notifications = new List<Notificacao>();

            Notifications.AddRange(notifications);
        }

        public void AddNotifications(IList<Notificacao> notifications)
        {
            if (notifications == null) return;

            if (Notifications == null)
                Notifications = new List<Notificacao>();

            Notifications.AddRange(notifications);
        }

        public void AddNotifications(ICollection<Notificacao> notifications)
        {
            if (notifications != null) return;

            if (Notifications == null)
                Notifications = new List<Notificacao>();

            Notifications.AddRange(notifications);
        }

        public void AddNotifications(NotifiableAutenticacao item)
        {
            if (item == null) return;

            if (Notifications == null)
                Notifications = new List<Notificacao>();

            if (item.Notifications != null)
                Notifications.AddRange(item.Notifications);
        }

        public void AddNotifications(params NotifiableAutenticacao[] items)
        {
            if (items == null) return;

            if (Notifications == null)
                Notifications = new List<Notificacao>();

            foreach (var item in items)
                if (item.Notifications != null)
                    Notifications.AddRange(item.Notifications);
        }

        public override string ToString()
        {
            var mensagem = new StringBuilder();

            Notifications.ForEach(notificacao =>
            {
                mensagem.Append($"{notificacao.Message}. ");
            });

            return mensagem.ToString();
        }

        #region Flunt     

        public void AddNotification(Notification notification)
        {
            if (notification == null) return;

            if (Notifications == null)
                Notifications = new List<Notificacao>();

            Notifications.Add(new Notificacao(notification.Property, notification.Message));
        }

        public void AddNotifications(IReadOnlyCollection<Notification> notifications)
        {
            if (notifications == null) return;

            if (Notifications == null)
                Notifications = new List<Notificacao>();

            foreach (var notification in notifications)
                Notifications.Add(new Notificacao(notification.Property, notification.Message));
        }

        public void AddNotifications(IList<Notification> notifications)
        {
            if (notifications == null) return;

            if (Notifications == null)
                Notifications = new List<Notificacao>();

            foreach (var notification in notifications)
                Notifications.Add(new Notificacao(notification.Property, notification.Message));
        }

        public void AddNotifications(ICollection<Notification> notifications)
        {
            if (notifications == null) return;

            if (Notifications == null)
                Notifications = new List<Notificacao>();

            foreach (var notification in notifications)
                Notifications.Add(new Notificacao(notification.Property, notification.Message));
        }

        public void AddNotifications(Notifiable item)
        {
            if (item == null) return;

            if (Notifications == null)
                Notifications = new List<Notificacao>();

            if (item.Notifications != null)
                foreach (var notification in item.Notifications)
                    Notifications.Add(new Notificacao(notification.Property, notification.Message));
        }

        public void AddNotifications(params Notifiable[] items)
        {
            if (items == null) return;

            if (Notifications == null)
                Notifications = new List<Notificacao>();

            foreach (var item in items)
                if (item.Notifications != null)
                    foreach (var notification in item.Notifications)
                        Notifications.Add(new Notificacao(notification.Property, notification.Message));
        }

        #endregion
    }
}

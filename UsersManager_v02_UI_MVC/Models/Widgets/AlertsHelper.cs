namespace UsersManager_v02_UI_MVC.Models.Widgets
{
    public enum NotificationType
    {
        SUCCESS,
        INFO,
        WARNING,
        ERROR
    }

    public static class AlertMessage
    {
        public static string StringAlert = "Alert";
    }

    public class Alert
    {
        public string Type { get; set; }
        public string Message { get; set; }
    }

    public static class AlertHelper
    {
        public static Alert GenerateAlert(NotificationType Type, string Message)
        {
            Alert Alert = new Alert();

            Alert.Type = GetNotificationType(Type);
            Alert.Message = Message;

            return Alert;
        }

        public static string GetNotificationType(NotificationType type)
        {
            string style = string.Empty;

            switch (type)
            {
                case NotificationType.SUCCESS:
                    style = "success";
                    break;
                case NotificationType.INFO:
                    style = "info";
                    break;
                case NotificationType.WARNING:
                    style = "warning";
                    break;
                case NotificationType.ERROR:
                    style = "danger";
                    break;
            }

            return style;
        }
    }
}

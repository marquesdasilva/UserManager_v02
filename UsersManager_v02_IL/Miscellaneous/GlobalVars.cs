namespace UserManager_v02_IL.Miscellaneous
{
    public enum NotificationType
    {
        SUCCESS,
        INFO,
        WARNING,
        ERROR
    }
    
    public class GlobalVars
    {
        public static string GetNotificationTypeStyle(NotificationType type)
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
                    style = "Error";
                    break;
            }

            return style;
        }

        public static int PageSize = 10;

        //public static Logger LoggerHelper
        //{
        //    get
        //    {
        //        return HttpContext.Current.Application["Logger"] as Logger;
        //    }
        //    set
        //    {
        //        HttpContext.Current.Application["Logger"] = value;
        //    }
        //}

        //public static object CurrentUser
        //{
        //    get
        //    {
        //        return HttpContext.Current.Session["User"] as User;
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["User"] = value;
        //    }
        //}

    }
}
namespace UserManager_v02_IL.Miscellaneous
{
    public class SnackBar
    {
        public const string Key = "SnackBarKey";

        public NotificationType Type { get; set; }
        public string Style { get; set; }
        public string Message { get; set; }
        public int Timeout { get; set; }
        public bool HtmlAllowed { get; set; }
    }
}
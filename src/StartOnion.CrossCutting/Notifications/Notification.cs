namespace StartOnion.CrossCutting.Notifications
{
    public class Notification
    {
        public int Code { get; }
        public string Message { get; }

        public Notification(int code)
        {
            Code = code;
            Message = string.Empty;
        }

        public Notification(string message)
        {
            Code = int.MinValue;
            Message = message;
        }

        public Notification(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}

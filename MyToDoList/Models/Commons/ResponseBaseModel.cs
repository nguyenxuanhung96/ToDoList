namespace MyToDoList.Models.Commons
{
    public class ResponseBaseModel
    {
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public static ResponseBaseModel Success(string message = null)
        {
            return new ResponseBaseModel
            {
                isSuccess = true,
                message = message
            };
        }
        public static ResponseBaseModel Failed(string message)
        {
            return new ResponseBaseModel
            {
                isSuccess = false,
                message = message,
            };
        }
    }
}

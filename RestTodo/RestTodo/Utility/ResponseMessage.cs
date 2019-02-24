namespace RestTodo.Utility
{
    public class ResponseMessage
    {
        public string Response { get; set; }

        public ResponseMessage(string response)
        {
            Response = response;
        }
    }
}

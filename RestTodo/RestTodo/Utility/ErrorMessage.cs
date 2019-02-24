namespace RestTodo.Utility
{
    public class ErrorMessage
    {
        public string Error { get; }

        public ErrorMessage(string error)
        {
            this.Error = error;
        }
    }
}

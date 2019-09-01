namespace Hardy.Common
{
    public class Result<T>
    {
        public T Content { get; set; }
        public string ErrorMessage { get; set; }
        public bool Failed { get; set; }
        public bool Succeeded { get; set; }

        public Result(T content)
        {
            Content = content;
            Failed = false;
            Succeeded = true;
        }

        public Result(string errorMessage)
        {
            ErrorMessage = errorMessage;
            Failed = true;
            Succeeded = false;
        }
    }
}

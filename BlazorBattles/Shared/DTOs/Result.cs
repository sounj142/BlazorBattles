namespace BlazorBattles.Shared.DTOs
{
    public class Result<T>
    {
        public T Value { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public static Result<T> Fail(string message)
        {
            return new Result<T> { Succeeded = false, Message = message };
        }

        public static Result<T> Success(T value, string message = null)
        {
            return new Result<T> { Succeeded = true, Message = message, Value = value };
        }
    }
}

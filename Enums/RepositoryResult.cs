namespace VisionStore.Enums
{
    public class RepositoryResult<T>
    {
        public T? Data { get; set; }
        public ErrorType? Error { get; set; }

        public RepositoryResult(T value, ErrorType? validationError)
        {
            Data = value;
            Error = validationError;
        }

    }
}

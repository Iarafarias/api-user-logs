namespace api_rest.Communication
{
    public class GenericResponse<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Resource { get; private set; }

        public GenericResponse(T resource)
        {
            Success = true;
            Message = string.Empty;
            Resource = resource;
        }

        public GenericResponse(string message)
        {
            Success = false;
            Message = message;
        }
    }
}

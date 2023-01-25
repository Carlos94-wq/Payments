namespace Payments.Api.Responses
{
    public class ApiResponse<T>
    {
        public Metada metadata { get; set; }
        public T data { get; set; }

        public ApiResponse(T data)
        {
            this.data = data;
        }
    }
}

namespace Projeto_SCFII.Infrastructure.Application.DTO.Shared
{
    public class ResponseDTO<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

        public ResponseDTO(bool success, string message, T? data = default)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public static ResponseDTO<T> CreateSuccess(string message, T? data = default)
        {
            return new ResponseDTO<T>(true, message, data);
        }

        public static ResponseDTO<T> CreateError(string message)
        {
            return new ResponseDTO<T>(false, message);
        }
    }
}

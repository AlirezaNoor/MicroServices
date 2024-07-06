namespace IdentityServices.Common.Responce;

public class BaseResponse<T>
{
    public bool IsSuccess { get; set; }
    public  string Message { get; set; }
    public List<string> Error { get; set; }
    public T  Response { get; set; }
    
}
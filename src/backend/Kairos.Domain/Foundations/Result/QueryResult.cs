namespace Kairos.Domain.Foundations.Result;
public class QueryResult<TData>
{
    public int Code { get; set; } = StatusCode.DefaultStatusCode;
    public string? Message { get; set; }
    public TData? Data { get; set; }

    [JsonIgnore]
    public bool IsSuccess => Code is > 200 and <= 299;

    [JsonConstructor]
    public QueryResult() => Code = StatusCode.DefaultStatusCode;
    public QueryResult(TData? data, int code = StatusCode.DefaultStatusCode, string? message = null)
    {
        Code = code;
        Message = message;
        Data = data;
    }
}

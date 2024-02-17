namespace FreelaDev.MsProjects.Core.Primitives.Result;

/// <summary>
/// Represents a common result for layers.
/// </summary>
public class Result
{
    public Result(bool isSuccess, Error error)
    {
        Error = error;
        IsSuccess = isSuccess;
    }
    public bool IsSuccess { get; set; }
    public Error Error { get; set; }
    public bool IsFailure => !IsSuccess;
    
    public static Result Ok() => new Result(true, Error.None);
    public static Result<TData> Ok<TData>(TData data) => new Result<TData>(true, Error.None, data);
    public static Result Fail(Error error) => new Result(false, error);
    public static Result<TData> Fail<TData>(Error error) => new Result<TData>(false, error, default!);
}

/// <summary>
/// Represents a generic result.
/// </summary>
/// <typeparam name="TData"></typeparam>
public class Result<TData> : Result
{
    public Result(bool isSuccess, Error error, TData data) : base(isSuccess, error)
    {
        Data = data;
    }
    public TData Data { get; set; }
}
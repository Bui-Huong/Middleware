using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class LoginMidleware
{
    private readonly RequestDelegate _next;
    public LoginMidleware(RequestDelegate next)
    {
        this._next = next;
    }
    public async Task Invoke(HttpContext context){
        using var buffer = new MemoryStream();
        var request = context.Request;
        var respose = context.Response;
        var stream = respose.Body;
        respose.Body = buffer;
        await _next(context);
        Debug.WriteLine("Request content type: Scheme {0} Host {1} QueryString {2} Body {3} Path {4}", request.Scheme, request.Host, request.QueryString, request.Body, request.Path);
        buffer.Position = 0;
        await buffer.CopyToAsync(stream);
    }
}
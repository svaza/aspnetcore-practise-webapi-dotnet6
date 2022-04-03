using System.Diagnostics;

namespace practise_api.Middlewares;

public class SampleMiddleware
{
  private readonly RequestDelegate _next;
  private readonly Guid _id = Guid.NewGuid();
  public SampleMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext cntx)
  {
    Console.WriteLine("-------Start of custom middleware, id : " + _id);
    var startDate = Stopwatch.StartNew();
    await _next(cntx);
    startDate.Stop();
    Console.WriteLine("    End of custom middleware - time taken : " + startDate.ElapsedMilliseconds + "ms");
  }
}
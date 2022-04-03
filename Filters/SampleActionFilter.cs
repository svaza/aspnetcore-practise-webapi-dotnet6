using Microsoft.AspNetCore.Mvc.Filters;

namespace practise_api.Filters;

public class SampleActionFilter : IActionFilter
{
  private readonly Guid _id = Guid.NewGuid();

  public void OnActionExecuting(ActionExecutingContext context)
  {
    Console.WriteLine($"    {_id} : Before action executing");
  }

  public void OnActionExecuted(ActionExecutedContext context)
  {
    Console.WriteLine($"    {_id} : After action executed");
  }
}
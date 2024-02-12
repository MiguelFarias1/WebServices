using Microsoft.AspNetCore.Mvc.Filters;

namespace APICatalogo.Filters;

public class ApiLoggerFilter(ILogger<ApiLoggerFilter> logger) : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        logger.LogInformation($"### Executando -> OnActionExecuted");
        logger.LogInformation("#########################################################");
        logger.LogInformation($"{DateTime.Now}");
        logger.LogInformation($"StatusCode: {context.HttpContext.Response.StatusCode}");
        logger.LogInformation("#########################################################");
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        logger.LogInformation($"### Executando -> OnActionExecuting");
        logger.LogInformation("#########################################################");
        logger.LogInformation($"{DateTime.Now}");
        logger.LogInformation($"ModelState: {context.ModelState.IsValid}");
        logger.LogInformation("#########################################################");
    }
}

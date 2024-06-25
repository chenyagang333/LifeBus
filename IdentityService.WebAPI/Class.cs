using Microsoft.AspNetCore.Mvc.Filters;

namespace IdentityService.WebAPI
{
    public class Class : IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}

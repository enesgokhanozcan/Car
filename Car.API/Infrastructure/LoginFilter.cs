using Car.Model.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Car.API.Infrastructure
{
    public class LoginFilter : Attribute,IActionFilter
    {
        private readonly IMemoryCache memoryCache;
        public LoginFilter(IMemoryCache _memoryCache)
        {
            memoryCache = _memoryCache;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(!memoryCache.TryGetValue(key: $"LoginUser", out UserViewModel loginuser))
            {
                context.Result = new BadRequestObjectResult("User not found...");
            }
            return;
        }
    }
}

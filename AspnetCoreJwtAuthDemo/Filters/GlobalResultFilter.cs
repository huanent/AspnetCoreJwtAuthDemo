using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AspnetCoreJwtAuthDemo.Filters
{
    public class GlobalResultFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.HttpContext.Response.Headers.TryAdd("Authorization-token", JwtHandler.GetToken(Constants.jwtKey, context.HttpContext.User.Claims, DateTime.UtcNow.AddSeconds(100)));
            }

            await next();
        }
    }
}

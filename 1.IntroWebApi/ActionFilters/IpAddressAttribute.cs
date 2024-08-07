using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _1.IntroWebApi.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class IpAddressAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var ip = context.HttpContext.Connection.RemoteIpAddress?.ToString();

            if (ip == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var ipAddresses = appSettings["WhiteListedIps"]?.Split(";");

            for (int i = 0; i < ipAddresses.Length; i++)
            {
                ipAddresses[i] = CutIp(ipAddresses[i]);
            }
            ip = CutIp(ip);

            if (!ipAddresses.Contains(ip))
            {
                context.Result = new UnauthorizedResult();
                return;
            }



            next();
        }

        private string CutIp(string ip)
        {
            var splits = ip.Split(".");
            if (splits.Length == 4)
            {
                return $"{splits[0]}.{splits[1]}.{splits[2]}";
            }
            if (splits.Length == 3)
            {
                return ip;
            }

            return null;
        }
    }
}

using Microsoft.AspNetCore.Mvc.Filters;

namespace XXLY.CarFinancingRentSystem._2004A.API
{
    public class ExceptionHandling : IExceptionFilter
    {
        //异常过滤器
        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
                log.Error(context.Exception);
            }
            context.ExceptionHandled = true;
        }
    }
}

using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;
using log4net;

namespace Services.LogService.Implementation
{
    [ExcludeFromCodeCoverage]
    public class ExceptionLoggingFilter : IExceptionFilter
    {
        private readonly ILog _logger;
        public ExceptionLoggingFilter(ILog logger)
        {
            _logger = logger;
        }

        public virtual void OnException(ExceptionContext filterContext)
        {
            _logger.Error(filterContext.Exception);
        }
    }
}
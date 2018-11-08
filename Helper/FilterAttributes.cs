using System;
using System.Linq;
using System.Web.Http.Filters;
using static CompressedContent;


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class CompressContent : System.Web.Http.Filters.ActionFilterAttribute
{
    public override void OnActionExecuted(HttpActionExecutedContext context)
    {
        var acceptedEncoding = context.Response.RequestMessage.Headers.AcceptEncoding.First().Value;

        if (!acceptedEncoding.Equals("gzip", StringComparison.InvariantCultureIgnoreCase)
            && !acceptedEncoding.Equals("deflate", StringComparison.InvariantCultureIgnoreCase))
        {
            return;
        }

        context.Response.Content = new CompressedContent(context.Response.Content, acceptedEncoding);
    }
}

using System;
namespace ThinkBridgeShop.Middlewares
{
	public static class MiddlewareExtension
	{
		public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<ErrorHandlerMiddleware>();
		}
	}
}


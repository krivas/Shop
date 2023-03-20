using System;
namespace ThinkBridgeShop.Application.Exceptions
{
	public class UnAuthorizedException: Exception
	{
		public UnAuthorizedException() : base("Username or password incorrect")
		{
		}
	}
}


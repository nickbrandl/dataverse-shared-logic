using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace Dataverse.Shared.Handlers
{
	public static class ExceptionHandler
	{
		public static void HandleException(Exception ex, ITracingService tracing = null)
		{
			if (ex != null && tracing != null) tracing.Trace(ex.ToString());

			if (ex is InvalidPluginExecutionException)
			{
				throw ex;
			}
			else if (ex is NullReferenceException)
			{
				throw new InvalidPluginExecutionException(
					$"Someone forgot to check whether an object could be accesed. Target: {ex.TargetSite}. If you contact your system administrator, please share this message.");
			}
			else if (ex is ArgumentNullException)
			{
				throw new InvalidPluginExecutionException(
					$"Someone forgot to pass a non-null argument. Target: {ex.TargetSite}. If you contact your system administrator, please share this message.");
			}
			else
			{
				throw new InvalidPluginExecutionException(GetGenericErrorMessage(ex));
			}
		}
		static private string GetFaultMessage(OrganizationServiceFault fault)
		{
			return fault?.InnerFault?.Message ?? fault?.Message ?? string.Empty;
		}
		static private string GetGenericErrorMessage(Exception e)
		{
			if (e != null) return $"Something went wrong while processing your request. The original exception message is: {e.Message}";
			else return "Something went wrong while processing your request. Try again later or contact your system administrator.";
		}
	}
}

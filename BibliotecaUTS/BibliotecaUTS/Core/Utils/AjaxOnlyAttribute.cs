using System;
using System.Reflection;
using System.Web.Mvc;

namespace Lab.Web.Filters
{
	/// <summary>
	/// Represents an attribute that is used to restrict an action method so that the method handles only AJAX requests.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
	{
		/// <summary>
		/// Determines whether the action method selection is valid for the specified controller context.
		/// </summary>
		/// <param name="controllerContext">The controller context.</param>
		/// <param name="methodInfo">Information about the action method.</param>
		/// <returns>
		/// true if the action method selection is valid for the specified controller context; otherwise, false.
		/// </returns>
		public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
		{
			return controllerContext.HttpContext.Request.IsAjaxRequest();
		}
	}
}
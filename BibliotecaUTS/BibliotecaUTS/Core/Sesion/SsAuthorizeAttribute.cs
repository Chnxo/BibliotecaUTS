using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Lab.Web.Filters
{
	/// <summary>
	/// Represents an attribute that is used to restrict access by callers to an action method base on their role.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public class SsAuthorizeAttribute : AuthorizeAttribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SsAuthorizeAttribute"/> class.
		/// </summary>
		/// <param name="allowedRoles">The allowed roles.</param>
		public SsAuthorizeAttribute(params string[] allowedRoles)
		{
			if (allowedRoles != null && allowedRoles.Length > 0)
				Roles = string.Join(",", allowedRoles);
		}

		/// <summary>
		/// Handles the unauthorized request.
		/// </summary>
		/// <param name="context">The context.</param>
		protected override void HandleUnauthorizedRequest(AuthorizationContext context)
		{
			if (context.HttpContext.Request.IsAjaxRequest())
			{
				var urlHelper = new UrlHelper(context.RequestContext);
				context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
				context.Result = new JsonResult
				{
					Data = new JResult
					{
						Message = "Unauthorized",
						Redirect = urlHelper.Action("LogIn", "Account")
					},
					JsonRequestBehavior = JsonRequestBehavior.AllowGet
				};
			}
			else
			{
				base.HandleUnauthorizedRequest(context);
			}
		}
	}
}
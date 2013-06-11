using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Dominio;

namespace Lab.Code.Services
{
    /// <summary>
    /// Defines methods to authenticate users and maintain an identity ticket.
    /// </summary>
    public interface IMembershipProvider
    {
        /// <summary>
        /// Authenticates a user's credentials and returns the user's role if the authentication was successful.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="remember"><c>true</c> to remember the user, otherwise <c>false</c>.</param>
        /// <returns>The user's role or None if the authentication failed.</returns>
        bool AuthenticateUser(string userName, string password, bool remember);

        /// <summary>
        /// Gets the object User from the UserName and Password prvided
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>The user or None if no matches are found.</returns>
        Usuario GetUser(string userName, string password);

        /// <summary>
        /// Gets the user currently logged in.
        /// </summary>
        SsPrincipal User { get; }

        /// <summary>
        /// Initializes the user identity using the specified context.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Removes the current user's identity.
        /// </summary>
        void ClearIdentity();
    }
}

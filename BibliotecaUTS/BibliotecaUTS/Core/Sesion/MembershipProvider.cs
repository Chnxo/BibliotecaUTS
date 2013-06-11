using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Autofac.Features.Indexed;
using SS.Caching;
using Dominio;

namespace Lab.Code.Services
{
    public class MembershipProvider : IMembershipProvider
    {
        private bool _isInitialized;
        private SsPrincipal _user;

        public MembershipProvider()
        {
            
        }

        /// <summary>
        /// Gets the user currently logged in.
        /// </summary>
        public virtual SsPrincipal User
        {
            get
            {
                if (!_isInitialized)
                {
                    Initialize();
                }
                return _user;
            }
        }

        /// <summary>
        /// Authenticates a user's credentials and returns the user's role if the authentication was successful.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="remember"><c>true</c> to remember the user, otherwise <c>false</c>.</param>
        /// <returns>The user's role or None if the authentication failed.</returns>
        public bool AuthenticateUser(string userName, string password, bool remember)
        {
            try
            {
                // var hash = "123456".GetHashCode().ToString();
                var user = GetUser(userName, password);

                if (user == null) return false;
                //string dbPassword = _database.Single<string>("SELECT Password FROM users WHERE UserID = @0", user.ID);

                // Perform case-sensitive password and access check
                //if (dbPassword != password || user.IsLoginEnabled == false)
                //{
                //    return false;
                //}

                SetIdentity(user, remember);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the object User from the UserName and Password prvided
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>The user or None if no matches are found.</returns>
        public Usuario GetUser(string userName, string password)
        {
            try
            {
                //return _database.Single<User>("WHERE UserName=@0 AND Password=@1", userName, password);
                return new Usuario();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Initializes the user identity using the specified context.
        /// </summary>
        public void Initialize()
        {
            var context = HttpContext.Current;
            var authCookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (!authTicket.Expired)
                {
                    SetPrincipal(context, authTicket.UserData);
                }
            }

            _isInitialized = true;
        }

        /// <summary>
        /// Removes the current user's identity.
        /// </summary>
        public void ClearIdentity()
        {
            FormsAuthentication.SignOut();
        }

        /// <summary>
        /// Sets the current user identity.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="remember"><c>true</c> to remember the user, otherwise <c>false</c>.</param>
        protected virtual void SetIdentity(Usuario user, bool remember)
        {
            var context = HttpContext.Current;
            string userData = string.Join(",", user.IdUsuario, user.NombreUsuario, user.Correo /*, user.Role*/);
            var authTicket = new FormsAuthenticationTicket(1,
                user.NombreUsuario,
                DateTime.Now,
                DateTime.Now.Add(FormsAuthentication.Timeout),
                remember,
                userData);

            var cookieContents = FormsAuthentication.Encrypt(authTicket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
            {
                Expires = authTicket.Expiration
            };
            context.Response.Cookies.Add(cookie);

            SetPrincipal(context, userData);
        }

        protected virtual void SetPrincipal(HttpContext context, string userData)
        {
            _user = CreatePrincipal(userData);
            context.User = _user;
        }

        protected virtual SsPrincipal CreatePrincipal(string userData)
        {
            var split = userData.Split(',');
            return new SsPrincipal(
                Convert.ToInt64(split[0]),
                split[1],
                split[2],
                split[3]
            );
        }
    }
}
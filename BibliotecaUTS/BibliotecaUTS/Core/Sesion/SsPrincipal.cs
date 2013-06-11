using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Lab.Code.Services
{
    public class SsPrincipal : IPrincipal
    {
        /// <summary>
        /// Gets the identity of the current principal.
        /// </summary>
        /// <returns>The <see cref="T:System.Security.Principal.IIdentity"/> object associated with the current principal.</returns>
        /// <remarks></remarks>
        public IIdentity Identity { get; private set; }

        /// <summary>
        /// Determines whether the current principal belongs to the specified role.
        /// </summary>
        /// <param name="role">The name of the role for which to check membership.</param>
        /// <returns>true if the current principal is a member of the specified role; otherwise, false.</returns>
        /// <remarks></remarks>
        public bool IsInRole(string role)
        {
            return string.Equals(Role, role, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SsPrincipal"/> class.
        /// </summary>
        /// <param name="id"> </param>
        /// <param name="name">The name.</param>
        /// <param name="email">The email.</param>
        /// <param name="role">The role.</param>
        /// <remarks></remarks>
        public SsPrincipal(long id, string name, string email, string role)
        {
            Identity = new GenericIdentity(name);

            Id = id;
            Name = name;
            Role = role;
            EmailAddress = email;
        }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks></remarks>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>The email address.</value>
        /// <remarks></remarks>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>The role.</value>
        /// <remarks></remarks>
        public string Role { get; set; }
    }
}
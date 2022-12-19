using System;
using System.Linq;
using System.Web.Security;
using SoftwareSerial.DataModel;

namespace SoftwareSerial.Web.Membership
{
    public sealed class UserRoleProvider : RoleProvider
    {

        #region No Usage

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion

        public override string[] GetRolesForUser(string username)
        {
            var user = UnitOfWork.Shared.UserRepository.GetAll().FirstOrDefault(
                x => x.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
            if(user == null)
            {
                FormsAuthentication.SignOut();
                return new string[]{""};
            }
            return new[] {user.Role};
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return
                UnitOfWork.Shared.UserRepository.GetAll().Any(
                    x =>
                    x.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                    x.Role.Equals(roleName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
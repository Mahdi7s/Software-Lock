using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using SabaSoftwareLock.Web.Models;
using SoftwareSerial.Model;

namespace SabaSoftwareLock.Model
{
    public class Member
    {
        public Member()
        {
            IsOnline = false;
        }

        public int MemberId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsOnline { get; set; }

        public string Role { get; set; }

        public decimal Charge { get; set; }

        public virtual List<SoftwareInfo> SoftwareInfoes { get; set; }

        [NotMapped]
        public RoleKind RoleEnum
        {
            get
            {
                RoleKind ret = RoleKind.None;
                Enum.TryParse(Role, out ret);
                return ret;
            }
            set
            {
                Role = value.ToString();
            }
        }

        public bool IsInRole(string role)
        {
            if(string.IsNullOrEmpty(role))
                throw new ArgumentNullException("role");

            return role.Equals(Role, StringComparison.OrdinalIgnoreCase);
        }

        public bool IsPasswordEqualsTo(string plainPassword)
        {
            return Password.Equals(plainPassword.ToSha());
        }
    }
}

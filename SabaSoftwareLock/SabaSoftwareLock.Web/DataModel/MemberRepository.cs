using System;
using System.Linq;
using SabaSoftwareLock.Model;
using Mvc7S;
using SabaSoftwareLock.DataModel;
using System.Web;
using SabaSoftwareLock.Web.DataModel;
using SoftwareSerial.Model;
using System.Collections.Generic;
using SoftwareSerial.Server;

namespace SabaSoftwareLock.Web
{
    public class MemberRepository : Repository<Member>
    {
        public MemberRepository(LockWebDbContext dbContext)
            : base(dbContext)
        {
        }

        public Member GetByUserName(string username, bool includeSoftInfoes = false)
        {
            if(string.IsNullOrEmpty(username))
                throw new ArgumentNullException("username");

            if(includeSoftInfoes)
                return _dbSet.Include("SoftwareInfoes").FirstOrDefault(x => x.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
            return _dbSet.FirstOrDefault(x => x.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public Member GetCurrent()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated && !string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
            {
                var username = HttpContext.Current.User.Identity.Name;
                var user = GetByUserName(username);
                if (user != null)
                {
                    LoadCollectionProperty(user, x => x.SoftwareInfoes);
                }
                return user;
            } return null;
        }

        public override void Insert(Member entity)
        {
            if (!_dbSet.Any(x => x.UserName.Equals(entity.UserName, StringComparison.OrdinalIgnoreCase)))
            {
                entity.Password = entity.Password.ToSha();
                base.Insert(entity);
            }
            else throw new Exception("این نام کاربری قبلا ثبت شده است.");
        }

        public bool IsInRole(string username, string roleName)
        {
            var mem = GetByUserName(username);
            return (mem != null && mem.Role.Equals(roleName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using SoftwareSerial.Model;

namespace SoftwareSerial.DataModel
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(DbContext dbContext) : base(dbContext){}
    }
}

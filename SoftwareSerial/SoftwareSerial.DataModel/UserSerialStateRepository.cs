using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using SoftwareSerial.Model;

namespace SoftwareSerial.DataModel
{
    public class UserSerialStateRepository : Repository<UserSerialState>
    {
        public UserSerialStateRepository(DbContext dbContext):base(dbContext){}
    }
}

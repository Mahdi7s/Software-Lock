using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using SoftwareSerial.Model;

namespace SoftwareSerial.DataModel
{
    internal sealed class SerialDbDevelopmentInitializer : DropCreateDatabaseIfModelChanges<SerialDbContext>
    {
        protected override void Seed(SerialDbContext context)
        {
            InitializationSeed.Seed(context);
            base.Seed(context);
        }
    }

    internal sealed class SerialDbDeploymentInitializer : CreateDatabaseIfNotExists<SerialDbContext>
    {
        protected override void Seed(SerialDbContext context)
        {
            InitializationSeed.Seed(context);
            base.Seed(context);
        }
    }

    //---------------------------------------------------------------------------------

    internal static class InitializationSeed
    {
        public static void Seed(SerialDbContext context)
        {
            var admin = new User
                            {
                                Role = "Admin",
                                UserName = "kamankamanusermname",
                                Password = "userkamanpassname"
                            };
            context.Users.Add(admin);

            context.SaveChanges();
        }
    }
}

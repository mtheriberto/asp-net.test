using AspNet.Test.Data.PostgreSql;
using AspNet.Test.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Test.Business
{
    public class UserBusiness
    {
        private readonly UserData _userData;

        public UserBusiness()
        {
            // TODO: Implements Dependency Injection
            this._userData = new UserData();
        }

        public User GetByName(string name)
            => this._userData.GetByName(name);
    }
}

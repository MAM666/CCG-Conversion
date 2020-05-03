using CCGConversion.DatabaseInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGConversion.Domain.DatabaseInfrastructure
{
    public class DbFactory : IDbFactory
    {
        DatabaseContext dbContext;

        //TODO: replace this with a DisposableObject class to inherit
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public DatabaseContext Init()
        {
            return dbContext ?? (dbContext = new DatabaseContext());
        }
    }
}

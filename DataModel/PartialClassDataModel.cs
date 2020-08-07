using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public partial class WebApiDbEntities : DbContext
    {
        public WebApiDbEntities(string connectionString)
        {
            this.Database.Connection.ConnectionString = connectionString;
        }

    }
}

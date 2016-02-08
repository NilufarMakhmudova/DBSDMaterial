using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace ChinookMusic.DAL
{
    public abstract class Repository
    {
        public static string ConnectionStr
        {
            get
            {
                return WebConfigurationManager
                    .ConnectionStrings["ConnStr"]
                    .ConnectionString;
            }
        }


    }
}

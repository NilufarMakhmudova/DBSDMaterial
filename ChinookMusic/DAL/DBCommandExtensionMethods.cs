﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookMusic.DAL
{
    public static class DbCommandExtensionMethods
    {
        public static IDbDataParameter AddParameter(this IDbCommand cmd, string name, System.Data.DbType type, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            var p = cmd.CreateParameter();
            p.ParameterName = name;
            p.Direction = direction;
            if (value == null)
            {
                p.Value = DBNull.Value;
            }
            else
            {
                p.DbType = type;
                p.Value = value;
            }

            cmd.Parameters.Add(p);
            return p;
        }
    }

}

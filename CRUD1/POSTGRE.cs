using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace CRUD1
{
    internal class POSTGRE
    {
        private NpgsqlConnection connection;
        public POSTGRE()
        {
            connection = new NpgsqlConnection();
            string constr = "Server=localhost;Port=5432;User Id=postgres;Password=QWERTY12;Database=crud;";
            connection.ConnectionString = constr;
        }
    }
}

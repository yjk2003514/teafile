using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XXLY.CarFinancingRentSystem._2004A.Domain;

namespace XXLY.CarFinancingRentSystem._2004A.Dapper
{
    public class DapperDbContext
    {
        string _context;//数据库连接
        Sql _sql;//数据库类型
        public DapperDbContext(string context, Sql sql)
        {
            _context = context;
            _sql = sql;
        }
        private IDbConnection _dbConnection;
        public IDbConnection _IContext()
        {
            if (_sql == Sql.SqlServer)
            {
                return new SqlConnection(_context);
            }
            else
            {
                return new MySqlConnection(_context);
            }
        }
    }
}

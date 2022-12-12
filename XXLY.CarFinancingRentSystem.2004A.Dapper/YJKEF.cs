using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XXLY.CarFinancingRentSystem._2004A.Domain.Table;

namespace XXLY.CarFinancingRentSystem._2004A.Dapper
{
    public class YJKEF : DbContext
    {
        public YJKEF(DbContextOptions options) : base(options)
        {

        }

        
        public DbSet<VehicleBrand>? VehicleBrand { get; set; }
    }
}

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

        public DbSet<CarDealer>? CarDealer { get; set; }
        public DbSet<CarDealerRelationUploadLnfo>? CarDealerRelationUploadLnfo { get; set; }
        public DbSet<Relation>? Relation { get; set; }
        public DbSet<UploadLnfo>? UploadLnfo { get; set; }

    }
}

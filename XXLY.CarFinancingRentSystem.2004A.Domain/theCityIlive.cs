using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXLY.CarFinancingRentSystem._2004A.Domain
{
    [Table("theCityIlive")]
    public class theCityIlive
    {
        [Key]
        public int Id { get; set; }

        public string? theCityIliveName { get; set; }

        public int theCityIliveFid { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXLY.CarFinancingRentSystem._2004A.Domain.Table
{/// <summary>
/// 车商表和车商联系表和车商资料表关系表
/// </summary>
    [Table("CarDealerRelationUploadLnfo")]
    public class CarDealerRelationUploadLnfo
    {
        [Key]

        public Guid Id { get; set; }//关系表主键

        public Guid CarDealerId { get; set; }//车商表外键

        public Guid RelationId { get; set; }//车商联系表外键

        public Guid UploadLnfoId { get; set; }//车商资料表外键

    }
}

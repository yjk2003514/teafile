using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXLY.CarFinancingRentSystem._2004A.Domain.Table
{/// <summary>
/// 车辆上传资料
/// </summary>
    [Table("UploadLnfo")]
    public class UploadLnfo
    {
        [Key]
        public int Id { get; set; }//上传资料Id

        public string? UploadLnfoName { get; set; }//上传资料名称

        public string? UploadLnfoFile { get; set; }//上传资料文件

        public string? UploadLnfoRemark { get; set; }//上传资料备注


    }
}

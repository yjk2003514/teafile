using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXLY.CarFinancingRentSystem._2004A.Domain.Table
{
    /// <summary>
    /// 车商联系资料
    /// </summary>
    [Table("Relation")]
    public class Relation
    {
        [Key]
        public Guid Id { get; set; }//联系资料  Id

        public string? RelationFname { get; set; }//联系资料关系代码

        public string? RelationName { get; set; }//联系资料联系人姓名

        public string? RelationPhone { get; set; }//联系资料手机号

        public string? RelationHomePhone{ get; set; }//联系资料居家电话

        public string? RelationCompanyPhone { get; set; }//联系资料公司电话
    }
}

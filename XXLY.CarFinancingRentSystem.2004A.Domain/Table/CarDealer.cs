using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXLY.CarFinancingRentSystem._2004A.Domain.Table 
{   /// <summary>
    /// 车商表
    /// </summary>
    [Table("CarDealer")]
    public class CarDealer
    {
        [Key]
        public Guid Id { get; set; } = new Guid();//车商Id

        public string? CarDealerOrganizationCodeCertificate { get; set; }//组织机构代码

        public string? CarDealerCompanyName { get; set; }//公司名称

        public decimal CarDealerRegisteredFund { get; set; }//注册资金

        public string? CarDealerIdentityCard { get; set; }//法人身份证号码

        public DateTime CarDealerSetUpDateTime { get; set; }//公司成立时间

        public string? CarDealerRegisteredAddress { get; set; }//公司登记地址

        public string? CarDealerBusinessdAddress { get; set; }//公司营业地址

        public string? CarDealerCompanyPhone { get; set; }//公司电话

        public string? CarDealerDifferentiate { get; set; }//区分

        public string? CarDealerBankOfDeposit { get; set; }//公司开户行

        public string? CarDealerAccountName{ get; set; }//账户名称

        public string? CarDealerBankAccount { get; set; }//银行账号

        public string? CarDealerTaxRegistrationNumber { get; set; }//税务登记号

        public string? CarDealerFiliale { get; set; }//分公司名称

        public string? CarDealerSalesman { get; set; }//业务员
    }
}

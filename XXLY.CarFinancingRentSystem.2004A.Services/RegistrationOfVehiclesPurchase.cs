using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XXLY.CarFinancingRentSystem._2004A.Repository;

namespace XXLY.CarFinancingRentSystem._2004A.Services
{
    /// <summary>
    /// 车辆管理采购服务层
    /// </summary>
    public class RegistrationOfVehiclesPurchase<T> where T:class,new()
    {
        IRespository<T> _Repository;

        public RegistrationOfVehiclesPurchase(IRespository<T> repository)
        {
            _Repository = repository;
        }
        /// <summary>
        /// 采购单显示
        /// </summary>
        /// <returns></returns>
        public List<T> PurchaseShow()
        {
            var i = _Repository.Show();
            return i.ToList();
        }
    }
}

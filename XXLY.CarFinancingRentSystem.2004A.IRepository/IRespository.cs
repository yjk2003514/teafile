using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXLY.CarFinancingRentSystem._2004A.IRepository
{
    public interface IRespository<T> where T : class, new()
    {
        int Add(T Model);
        object Del(T id);
        IEnumerable<T> Find(Guid Id);
        IEnumerable<T> Show();
        int Upt(T Model);
    }
}

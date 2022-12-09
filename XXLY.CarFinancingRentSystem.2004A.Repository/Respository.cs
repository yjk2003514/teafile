using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XXLY.CarFinancingRentSystem._2004A.Dapper;

namespace XXLY.CarFinancingRentSystem._2004A.Repository
{
    public class Respository<T> where T:class,new()
    {
        DapperDbContext _DapperDbContext;

        public Respository(DapperDbContext dapperDbContext)
        {
            _DapperDbContext = dapperDbContext;
        }

        /// <summary>
        /// 显示的仓储
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> Show()
        {
            var i = _DapperDbContext._IContext();
            var ty = typeof(T);
            string MySqlName = "";
            var getproperty = ty.GetCustomAttributes(typeof(TableAttribute), true);
            MySqlName = ((TableAttribute)getproperty[0]).Name;
            var sql = $"select * from {MySqlName}";
            var list = i.Query<T>(sql);
            return list;
        }

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IEnumerable<T> Find(int Id)
        {
            var i = _DapperDbContext._IContext();
            var ty = typeof(T);
            string MySqlName = "";
            var getproperty = ty.GetCustomAttributes(typeof(TableAttribute), true);
            MySqlName = ((TableAttribute)getproperty[0]).Name;
           
            var list = i.Query<T>($"select * from {MySqlName} where Id=@Id", new {Id=Id});
            return list;
        }
         /// <summary>
         /// 添加的仓储
         /// </summary>
         /// <param name="Model"></param>
         /// <returns></returns>
        public  int Add(T Model)
        {
            var i = _DapperDbContext._IContext();
            var ty = typeof(T);
            string setTable = "";
            string setproperty = "";
            var setcharacter = ty.GetCustomAttributes(typeof(TableAttribute), true);
            string characterName = ((TableAttribute)setcharacter[0]).Name;

            var ppt = ty.GetProperties();//获取字段属性

            ppt.ToList().ForEach(d =>
            {
                var hqzdsx = d.PropertyType;
                var hqzd = d.GetValue(Model, null);
                if (hqzd != null)
                {
                    if (hqzdsx == typeof(DateTime))
                    {
                        if (!hqzd.ToString().Contains("0001/1/1 0:00:00"))
                        {
                            setproperty += $"{d.Name},";
                            setTable += $"@{d.Name},";
                        }
                    }
                    else if (!d.Name.ToLower().Equals("id"))
                    {
                        setproperty += $"{d.Name},";
                        setTable += $"@{d.Name},";
                    }
                }
            });

            var sql = $"insert into {characterName} ({setproperty.TrimEnd(',')}) values({setTable.TrimEnd(',')})";
            i.Execute(sql, Model);
            return 200;
        }

        /// <summary>
        /// 修改的存储过程
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public int Upt(T Model)
        {
            var a = _DapperDbContext._IContext();
            var ty = typeof(T);
            string CFTable = "";
            string CFSJLX = "";
            var hqtx = ty.GetCustomAttributes(typeof(TableAttribute), true);
            CFTable = ((TableAttribute)hqtx[0]).Name;
            var ppt = ty.GetProperties();
            ppt.ToList().ForEach(d =>
            {
                var hqzdsx = d.PropertyType;
                var hqzd = d.GetValue(Model, null);
                if (hqzd != null)
                {
                    if (hqzdsx == typeof(DateTime))
                    {
                        if (!hqzd.ToString().Contains("0001/1/1 0:00:00"))
                        {
                            CFSJLX += $"{d.Name}=@{d.Name},";
                        }
                    }
                    else if(!d.Name.ToList().Equals("id"))
                    {
                        CFSJLX += $"{d.Name}=@{d.Name},";
                    }
                }
            });
            var sql = $"update {CFTable} set {CFSJLX.TrimEnd(',')} where id=@id";
            a.Execute(sql, Model);
            return 200;
        }
        /// <summary>
        /// 删除的存储过程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Del(int id)
        {
            var a = _DapperDbContext._IContext//连接上下文
            var ty = typeof(T);
            var hqtx = ty.GetCustomAttributes(typeof(TableAttribute), true);//获取特性
            string CFTable = ((TableAttribute)hqtx[0]).Name;//获取表名
            var sql = a.Execute($"delete from {CFTable} where id=@id", new { @id = id });//拼接sql语句
            return sql;//返回
        }
    }
}

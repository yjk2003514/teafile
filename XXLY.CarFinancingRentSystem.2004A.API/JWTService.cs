using CSRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace XXLY.CarFinancingRentSystem._2004A.API
{
    public class JWTService
    {
        //public IRespotry<User> User;
        /// <summary>
        /// 生成Token
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public static string GetNewJWT()
        {
            //解释JwtSecurityTokenHandler类型: JWT安全令牌处理程序类
            var tokenHand = new JwtSecurityTokenHandler();
            //解释Encoding.ASCII.GetBytes 这个方法是将字符串转换成字节数组
            //解释1111111111111111 这个字符串是加密的key，你可以随便写，但是要记住，这里的key要和验证的时候的key一样
            var key = Encoding.ASCII.GetBytes("1111111111111111");
            //解释SecurityTokenDescriptor 这个类是用来描述Token的一些基本信息的，比如说，谁颁发的，谁接收的，什么时候颁发的，什么时候过期的，加密的时候使用的key等等
            var tokenDescript = new SecurityTokenDescriptor()
            {
                //解释Subject 这个属性是用来描述这个Token的接收者的，一般是用户名
                //解释ClaimsIdentity  这个类是用来描述用户的一些基本信息的，比如说，用户名，用户ID，用户邮箱等等
                Subject = new ClaimsIdentity(new Claim[]
                 {
                     new Claim(ClaimTypes.Name,"admain"),
                     new Claim(ClaimTypes.Role,"admain"),
                 }),
                //解释Expires 这个属性是用来设置Token的过期时间的
                Expires = DateTime.Now.AddDays(1),
                //解释Issuer 这个属性是用来设置Token的颁发者的
                Issuer = "http://localhost:5041",
                //解释Audience 这个属性是用来设置Token的接收者的
                Audience = "http://localhost:5041",
                //解释SigningCredentials 这个属性是用来设置Token的加密方式的
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            //解释tokenHand.CreateToken 这个方法是用来生成Token的
            var token = tokenHand.CreateToken(tokenDescript);
            //解释tokenHand.WriteToken 这个方法是用来将Token转换成字符串的
            return tokenHand.WriteToken(token);
        }

    }
}

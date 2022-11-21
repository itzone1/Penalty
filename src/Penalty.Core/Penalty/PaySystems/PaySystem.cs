using Abp.Domain.Entities.Auditing;
using Penalty.Authorization.Users;
using Penalty.Penalty.Classes.RootEntities.Bets;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace Penalty.Penalty.PaySystems
{
    public class PaySystem : FullAuditedAggregateRoot<Guid>
    {
        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }
        public string MerchantUrl { get; set; }
        public int m_shop { get; set; }
        public int m_orderid { get; set; }
        public double m_amount { get; set; }
        public string m_curr { get; set; }
        public string? m_desc { get; set; }
        public string m_key { get; set; }
        public string sign { get; set; }
        public bool isCompleted { get; set; }

        //public static void Main(string[] args)
        //{
        //    var m_shop = "1778687373";
        //    var m_orderid = "1";
        //    var m_amount = "1.00";
        //    var m_curr = "USD";
        //    var m_desc = Base64Encode("Test");
        //    var m_key = "Secret key";
        //    var arr = new string[] { m_shop, m_orderid, m_amount, m_curr, m_desc, m_key };
        //    var sign = sign_hash(String.Join(":", arr));
        //}
        //public static string sign_hash(string text)
        //{
        //    byte[] data = Encoding.Default.GetBytes(text);
        //    var result = new SHA256Managed().ComputeHash(data);
        //    return BitConverter.ToString(result).Replace("-", "").ToUpper();
        //}
        //public static string Base64Encode(string plainText)
        //{
        //    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        //    return System.Convert.ToBase64String(plainTextBytes);
        //}
    }
 
}

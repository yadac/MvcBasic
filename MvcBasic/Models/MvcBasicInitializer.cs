using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcBasic.Models
{
    /// <summary>
    /// initializer
    /// </summary>
    public class MvcBasicInitializer : DropCreateDatabaseAlways<MvcBasicContext>
    {
        /// <summary>
        /// insert data when application launch.
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(MvcBasicContext context)
        {
            var members = new List<Member>()
            {
                new Member()
                {
                    Name = "Taro Yamada",
                    Email = "taro.yamada@example.com",
                    Birth = DateTime.Parse("1980-01-02"),
                    Married = false,
                    Memo = "dokaben",
                },
                new Member()
                {
                    Name = "Nobunaga Oda",
                    Email = "nobunaga.oda@example.com",
                    Birth = DateTime.Parse("1583-10-12"),
                    Married = true,
                    Memo = "owari no samurai",
                }
            };

            members.ForEach(m => context.Members.Add(m));
            context.SaveChanges();
        }
    }
}
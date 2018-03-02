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
                    Email = "dokaben@example.com",
                    Birth = DateTime.Parse("1980-01-02"),
                    Married = false,
                    Language = LanguageEnum.Japanese,
                    Memo = "『ドカベン』の主人公。ポジションは捕手。右投左打。新潟県新潟市旭七ヶ町生まれの神奈川県横浜市育ち。",
                },
                new Member()
                {
                    Name = "Okitsugu Tanuma",
                    Email = "otanuma@example.com",
                    Birth = DateTime.Parse("1753-01-01"), // sql server datetime range min 
                    Married = true,
                    Language = LanguageEnum.English,
                    Memo = "享保4年（1719年）7月27日、紀州藩士から旗本になった田沼意行の長男として江戸の本郷弓町の屋敷で生まれる。幼名は龍助。",
                }
            };

            members.ForEach(m => context.Members.Add(m));
            context.SaveChanges();
        }
    }
}
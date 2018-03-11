using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBasic.Models
{
    public class MemberTestRepository : IMemberRepository
    {

        public IEnumerable<Member> GetAll()
        {
            var members = new List<Member>();

            for (int i = 0; i < 5; i++)
            {
                members.Add(new Member()
                {
                    Id = i,
                    Name = "taro" + i.ToString(),
                    Email = "taro" + i.ToString() + "@example.com",
                    Birth = DateTime.Now.AddDays(i),
                    Married = i % 2 == 0 ? true : false,
                    Memo = "memo " + i.ToString(),
                });
            }
            return members;
        }

        public Member Create(Member member)
        {
            return member;
        }
    }
}
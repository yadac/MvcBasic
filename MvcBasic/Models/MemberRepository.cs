using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBasic.Models
{
    public class MemberRepository : IMemberRepository
    {
        // create context
        private readonly MvcBasicContext _db = new MvcBasicContext();

        /// <summary>
        /// get all member infomation.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Member> GetAll()
        {
            return _db.Members;
        }

        /// <summary>
        /// create argument member.
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public Member Create(Member member)
        {
            _db.Members.Add(member);
            _db.SaveChanges();
            return member;
        }
    }
}
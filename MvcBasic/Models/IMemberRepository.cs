using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBasic.Models
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAll();
        Member Create(Member member);
    }
}
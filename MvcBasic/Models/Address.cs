using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcBasic.Models
{
    [ComplexType]
    public class Address
    {
        public string Prefecture { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
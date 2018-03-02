using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBasic.Models
{
    public enum LanguageEnum
    {
        [Display(Name = "English")]
        English,
        [Display(Name = "Japanese")]
        Japanese,
        [Display(Name = "Korean")]
        Korean,
    }
}
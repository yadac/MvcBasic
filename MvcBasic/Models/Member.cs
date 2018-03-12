using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcBasic.Models
{
    [CustomValidation(typeof(Member), "CheckMarriedEmail")]
    public class Member : IValidatableObject
    {
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(MvcBasic.Resources.ModelResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MvcBasic.Resources.ModelResource))]
        [RegularExpression("[^a-zA-Z0-9]*", ErrorMessageResourceName = "RegularExpression", ErrorMessageResourceType = typeof(MvcBasic.Resources.ModelResource))]
        public string Name { get; set; }

        [Display(Name = "Email", ResourceType = typeof(MvcBasic.Resources.ModelResource))]
        [EmailAddress(ErrorMessage = "メールアドレスの形式で入力してください")]
        public string Email { get; set; }

        [DisplayName("メールアドレス（確認）")]
        [NotMapped]
        [Compare("Email", ErrorMessage = "{1}と一致していません")]
        public string EmailConfirmed { get; set; }

        [Display(Name = "Birth", ResourceType = typeof(MvcBasic.Resources.ModelResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(MvcBasic.Resources.ModelResource))]
        public DateTime Birth { get; set; }

        [Display(Name = "Married", ResourceType = typeof(MvcBasic.Resources.ModelResource))]
        public bool Married { get; set; }

        [DisplayName("言語")]
        public LanguageEnum Language { get; set; }

        [Display(Name = "Memo", ResourceType = typeof(MvcBasic.Resources.ModelResource))]
        [StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(MvcBasic.Resources.ModelResource))]
        // {0} = Name, {1} = maxLength, {2} = minLength
        // [StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(MvcBasic.Resources.ModelResource))]
        // [CustomValidation(typeof(Member), "CheckBlackword")]
        //[Blackword("違法,麻薬,毒")]
        public string Memo { get; set; }

        //public static ValidationResult CheckBlackword(string memo)
        //{
        //    string[] list = new string[] { "違法", "麻薬", "毒" };
        //    foreach (var word in list)
        //    {
        //        if (memo.Contains(word))
        //        {
        //            return new ValidationResult("NGワードが含まれています");
        //        }
        //    }
        //    return ValidationResult.Success; ;
        //}

        public static ValidationResult CheckMarriedEmail(Member m)
        {
            //if (m.Married && m.Email == null)
            //{
            //    return new ValidationResult("既婚者はEmailアドレスを入力してください");
            //}
            return ValidationResult.Success;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var m = validationContext.ObjectInstance as Member;
            if (m == null) yield return new ValidationResult("不正");
            if (m.Married && m.Email == null) yield return new ValidationResult("既婚者はEmailアドレスを入力してください", new[] { "Email" });
            yield return ValidationResult.Success;

        }
    }
}
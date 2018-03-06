﻿using System;
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
        [DisplayName("氏名")]
        [Required(ErrorMessage = "{0}は必須です")]
        [RegularExpression("[^a-zA-Z0-9]*", ErrorMessage = "{0}には半角英数字を含めないでください")]
        public string Name { get; set; }
        [DisplayName("メールアドレス")]
        [EmailAddress(ErrorMessage = "メールアドレスの形式で入力してください")]
        public string Email { get; set; }
        [DisplayName("メールアドレス（確認）")]
        [NotMapped]
        [Compare("Email", ErrorMessage = "{1}と一致していません")]
        public string EmailConfirmed { get; set; }
        [DisplayName("生年月日")]
        [Required(ErrorMessage = "{0}は必須です")]
        public DateTime Birth { get; set; }
        [DisplayName("既婚")]
        public bool Married { get; set; }
        [DisplayName("言語")]
        public LanguageEnum Language { get; set; }
        [DisplayName("自己紹介")]
        [StringLength(100, ErrorMessage = "{0}は{1}文字以内で入力してください")]
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
            if (m == null)
            {
                yield return new ValidationResult("不正");
            }
            if (m.Married && m.Email == null)
            {
                // エラーメッセージを特定のプロパティに関連付ける
                // 関連づけない場合はmodel全体のエラーとして関連付けられる
                yield return new ValidationResult("既婚者はEmailアドレスを入力してください", new[] { "Email" });
            }
            yield return ValidationResult.Success;

        }
    }
}
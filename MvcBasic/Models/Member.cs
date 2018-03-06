using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcBasic.Models
{
    /* 
     * 
     */
    public class Member
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
        public string Memo { get; set; }

    }
}
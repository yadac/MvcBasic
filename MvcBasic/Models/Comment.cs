using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcBasic.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [DisplayName("氏名")]
        public string Name { get; set; }

        [DisplayName("コメント")]
        public string Body { get; set; }

        [DisplayName("タイトル")]
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日}")]
        public DateTime Updated { get; set; }

        [DisplayName("記事")]
        public virtual Article Article { get; set; }

    }
}
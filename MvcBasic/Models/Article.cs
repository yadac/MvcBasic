﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcBasic.Models
{
    public class Article
    {
        public int Id { get; set; }

        [DisplayName("URL")]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        [DisplayName("タイトル")]
        public string Title { get; set; }

        [DisplayName("カテゴリー")]
        public CategoryEnum Category { get; set; }

        [DisplayName("概要")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("ビュー数")]
        public int ViewCount { get; set; }

        [DisplayName("公開日")]
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日}")]
        public DateTime Published { get; set; }

        [DisplayName("公開済")]
        public bool Released { get; set; }

        [JsonIgnore]
        [DisplayName("コメント")]
        public virtual ICollection<Comment> Comments { get; set; }

        [JsonIgnore]
        [DisplayName("著者")]
        public virtual ICollection<Author> Authors { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; } // store version number

        //[JsonIgnore]
        [NotMapped]
        public string Summary
        {
            get
            {
                if (Description.Length > 50)
                    return Description.Substring(0, 50);
                else
                    return Description;
            }
        }
    }
}
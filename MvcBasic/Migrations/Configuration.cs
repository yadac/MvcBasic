using MvcBasic.Models;
using System.Collections.Generic;

namespace MvcBasic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcBasic.Models.MvcBasicContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcBasic.Models.MvcBasicContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var members = new List<Member>()
            {
                new Member()
                {
                    Name = "Taro Yamada",
                    Email = "dokaben@example.com",
                    Birth = DateTime.Parse("1980-01-02"),
                    Married = false,
                    Language = LanguageEnum.Japanese,
                    Memo = "『ドカベン』の主人公。ポジションは捕手。右投左打。新潟県新潟市旭七ヶ町生まれの神奈川県横浜市育ち。",
                },
                new Member()
                {
                    Name = "Okitsugu Tanuma",
                    Email = "otanuma@example.com",
                    Birth = DateTime.Parse("1753-01-01"), // sql server datetime range min 
                    Married = true,
                    Language = LanguageEnum.English,
                    Memo = "享保4年（1719年）7月27日、紀州藩士から旗本になった田沼意行の長男として江戸の本郷弓町の屋敷で生まれる。幼名は龍助。",
                }
            };

            members.ForEach(m => context.Members.AddOrUpdate(item => item.Email, m));


            var article = new Article
            {
                Url = "http://www.buildinsider.net/web/jquerymobileref",
                Title = "jQuery Mobile逆引きリファレンス",
                Category = CategoryEnum.Reference,
                Description = "jQuery Mobileの基本機能を目的別リファレンスの形式でまとめます。",
                ViewCount = 36452,
                Published = DateTime.Parse("2014-01-09"),
                Released = true
            };

            var article2 = new Article
            {
                Url = "http://codezine.jp/article/corner/518",
                Title = "Bootstrapでレスポンシブでリッチなサイトを構築",
                Category = CategoryEnum.DotNet,
                Description = "ASP.NET MVC5のひな形ページで使用されているBootstrapというフレームワークについて紹介します。",
                ViewCount = 9312,
                Published = DateTime.Parse("2014-05-22"),
                Released = true
            };


            var article3 = new Article
            {
                Url = "http://codezine.jp/article/corner/511",
                Title = "ASP.NET Identity入門",
                Category = CategoryEnum.DotNet,
                Description = "新しい認証、資格管理システムである「ASP.NET Identity」について、どのように使うのか、どんな仕組みで動いているのかを紹介していきます。",
                ViewCount = 8046,
                Published = DateTime.Parse("2014-04-25"),
                Released = true
            };

            var article4 = new Article
            {
                Url = "http://codezine.jp/article/corner/513",
                Title = "Amazon Web Servicesによるクラウド超入門",
                Category = CategoryEnum.Cloud,
                Description = "Amazon Web Servicesを使ってクラウドシステム上に簡単なWebシステムを構築していきます。",
                ViewCount = 25687,
                Published = DateTime.Parse("2014-04-25"),
                Released = true
            };

            var article5 = new Article
            {
                Url = "http://www.buildinsider.net/web/jqueryuiref",
                Title = "jQuery UI逆引きリファレンス",
                Category = CategoryEnum.Reference,
                Description = "jQuery UIの基本機能を目的別リファレンスの形式でまとめます。",
                ViewCount = 56710,
                Published = DateTime.Parse("2013-07-11"),
                Released = true
            };

            var article6 = new Article
            {
                Url = "http://www.example.com/mvc5",
                Title = "ASP.NET MVC 入門",
                Category = CategoryEnum.DotNet,
                Description = "ASP.NET MVCをこれから始める人のために、詳しく丁寧に段階を追って解説します。",
                ViewCount = 0,
                Published = DateTime.Parse("2015-01-20"),
                Released = false
            };

            var article7 = new Article
            {
                Url = "http://www.example.com/azure",
                Title = "Azure新機能TIPS",
                Category = CategoryEnum.Cloud,
                Description = "Microsoft Azureの新機能についてTIPS形式で、使い方などを解説します。",
                ViewCount = 13469,
                Published = DateTime.Parse("2014-04-25"),
                Released = true
            };


            context.Articles.AddOrUpdate(item => item.Url, article);
            context.Articles.AddOrUpdate(item => item.Url, article2);
            context.Articles.AddOrUpdate(item => item.Url, article3);
            context.Articles.AddOrUpdate(item => item.Url, article4);
            context.Articles.AddOrUpdate(item => item.Url, article5);
            context.Articles.AddOrUpdate(item => item.Url, article6);
            context.Articles.AddOrUpdate(item => item.Url, article7);

            // context
            context.SaveChanges();

        }
    }
}

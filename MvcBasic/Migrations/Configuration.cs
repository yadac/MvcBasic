using MvcBasic.Models;
using System;
using System.Collections.Generic;

namespace MvcBasic.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcBasic.Models.MvcBasicContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MvcBasic.Models.MvcBasicContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MvcBasic.Models.MvcBasicContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            #region Member

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

            members.ForEach(m => context.Members.AddOrUpdate(m));


            #endregion

            #region Article & Comment

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
            context.Articles.AddOrUpdate(article);
            context.Comments.AddOrUpdate(new Comment
            {
                Name = "井上鈴子",
                Body = "目的別で探しやすく重宝しています。",
                Updated = DateTime.Parse("2014-06-01"),
                Article = article
            });
            context.Comments.AddOrUpdate(new Comment
            {
                Name = "和田翔太",
                Body = "寸例が載っているのでわかりやすいと思います。",
                Updated = DateTime.Parse("2014-06-11"),
                Article = article
            });

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
            context.Articles.AddOrUpdate(article2);
            context.Comments.AddOrUpdate(new Comment
            {
                Name = "田中三郎",
                Body = "まとめ方が良くてわかりやすかったです。",
                Updated = DateTime.Parse("2014-06-15"),
                Article = article2
            });

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
            context.Articles.AddOrUpdate(article3);
            context.Comments.AddOrUpdate(new Comment
            {
                Name = "和田翔太",
                Body = "自分で調べていて分からなかったところが、分かって良かったです。",
                Updated = DateTime.Parse("2014-07-02"),
                Article = article3
            });


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
            context.Articles.AddOrUpdate(article4);


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
            context.Articles.AddOrUpdate(article5);
            context.Comments.AddOrUpdate(new Comment
            {
                Name = "井上鈴子",
                Body = "用例の結果もみられるので、便利です。欲を言うとサンプルコードをダウンロードできるようにしてほしい。",
                Updated = DateTime.Parse("2014-07-01"),
                Article = article5
            });

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
            context.Articles.AddOrUpdate(article6);

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
            context.Articles.AddOrUpdate(article7);



            #endregion

            #region Author

            var author1 = new Author
            {
                Name = "山田太郎",
                Email = "taro@example.com",
                Birth = DateTime.Parse("1970-12-10"),
                Articles = new List<Article> { article, article2, article3, article5, article6 }
            };
            context.Authors.AddOrUpdate(author1);

            var author2 = new Author
            {
                Name = "鈴木久美",
                Email = "kumi@example.com",
                Birth = DateTime.Parse("1985-11-12"),
                Articles = new List<Article> { article, article4, article7 }
            };
            context.Authors.AddOrUpdate(author2);

            var author3 = new Author
            {
                Name = "佐藤敏夫",
                Email = "toshi@example.com",
                Birth = DateTime.Parse("1975-05-26"),
                Articles = new List<Article> { article, article2 }
            };
            context.Authors.AddOrUpdate(author3);


            #endregion

            #region People

            Address address1 = new Address()
            {
                Prefecture = "Aichi",
                City = "Nagoya",
                Street = "Route-1",
            };

            Person person1 = new Person()
            {
                Name = "Nobunaga",
                Address = address1,
            };
            context.People.AddOrUpdate(person1);


            #endregion


        }
    }
}

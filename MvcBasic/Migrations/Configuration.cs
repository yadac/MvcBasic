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
                    Memo = "�w�h�J�x���x�̎�l���B�|�W�V�����͕ߎ�B�E�����ŁB�V�����V���s�����������܂�̐_�ސ쌧���l�s�炿�B",
                },
                new Member()
                {
                    Name = "Okitsugu Tanuma",
                    Email = "otanuma@example.com",
                    Birth = DateTime.Parse("1753-01-01"), // sql server datetime range min 
                    Married = true,
                    Language = LanguageEnum.English,
                    Memo = "����4�N�i1719�N�j7��27���A�I�B�ˎm������{�ɂȂ����c���Ӎs�̒��j�Ƃ��č]�˂̖{���|���̉��~�Ő��܂��B�c���͗����B",
                }
            };

            members.ForEach(m => context.Members.AddOrUpdate(m));


            #endregion

            #region Article & Comment

            var article = new Article
            {
                Url = "http://www.buildinsider.net/web/jquerymobileref",
                Title = "jQuery Mobile�t�������t�@�����X",
                Category = CategoryEnum.Reference,
                Description = "jQuery Mobile�̊�{�@�\��ړI�ʃ��t�@�����X�̌`���ł܂Ƃ߂܂��B",
                ViewCount = 36452,
                Published = DateTime.Parse("2014-01-09"),
                Released = true
            };
            context.Articles.AddOrUpdate(article);
            context.Comments.AddOrUpdate(new Comment
            {
                Name = "����q",
                Body = "�ړI�ʂŒT���₷���d�󂵂Ă��܂��B",
                Updated = DateTime.Parse("2014-06-01"),
                Article = article
            });
            context.Comments.AddOrUpdate(new Comment
            {
                Name = "�a�c�đ�",
                Body = "���Ⴊ�ڂ��Ă���̂ł킩��₷���Ǝv���܂��B",
                Updated = DateTime.Parse("2014-06-11"),
                Article = article
            });

            var article2 = new Article
            {
                Url = "http://codezine.jp/article/corner/518",
                Title = "Bootstrap�Ń��X�|���V�u�Ń��b�`�ȃT�C�g���\�z",
                Category = CategoryEnum.DotNet,
                Description = "ASP.NET MVC5�̂ЂȌ`�y�[�W�Ŏg�p����Ă���Bootstrap�Ƃ����t���[�����[�N�ɂ��ďЉ�܂��B",
                ViewCount = 9312,
                Published = DateTime.Parse("2014-05-22"),
                Released = true
            };
            context.Articles.AddOrUpdate(article2);
            context.Comments.AddOrUpdate(new Comment
            {
                Name = "�c���O�Y",
                Body = "�܂Ƃߕ����ǂ��Ă킩��₷�������ł��B",
                Updated = DateTime.Parse("2014-06-15"),
                Article = article2
            });

            var article3 = new Article
            {
                Url = "http://codezine.jp/article/corner/511",
                Title = "ASP.NET Identity����",
                Category = CategoryEnum.DotNet,
                Description = "�V�����F�؁A���i�Ǘ��V�X�e���ł���uASP.NET Identity�v�ɂ��āA�ǂ̂悤�Ɏg���̂��A�ǂ�Ȏd�g�݂œ����Ă���̂����Љ�Ă����܂��B",
                ViewCount = 8046,
                Published = DateTime.Parse("2014-04-25"),
                Released = true
            };
            context.Articles.AddOrUpdate(article3);
            context.Comments.AddOrUpdate(new Comment
            {
                Name = "�a�c�đ�",
                Body = "�����Œ��ׂĂ��ĕ�����Ȃ������Ƃ��낪�A�������ėǂ������ł��B",
                Updated = DateTime.Parse("2014-07-02"),
                Article = article3
            });


            var article4 = new Article
            {
                Url = "http://codezine.jp/article/corner/513",
                Title = "Amazon Web Services�ɂ��N���E�h������",
                Category = CategoryEnum.Cloud,
                Description = "Amazon Web Services���g���ăN���E�h�V�X�e����ɊȒP��Web�V�X�e�����\�z���Ă����܂��B",
                ViewCount = 25687,
                Published = DateTime.Parse("2014-04-25"),
                Released = true
            };
            context.Articles.AddOrUpdate(article4);


            var article5 = new Article
            {
                Url = "http://www.buildinsider.net/web/jqueryuiref",
                Title = "jQuery UI�t�������t�@�����X",
                Category = CategoryEnum.Reference,
                Description = "jQuery UI�̊�{�@�\��ړI�ʃ��t�@�����X�̌`���ł܂Ƃ߂܂��B",
                ViewCount = 56710,
                Published = DateTime.Parse("2013-07-11"),
                Released = true
            };
            context.Articles.AddOrUpdate(article5);
            context.Comments.AddOrUpdate(new Comment
            {
                Name = "����q",
                Body = "�p��̌��ʂ��݂���̂ŁA�֗��ł��B�~�������ƃT���v���R�[�h���_�E�����[�h�ł���悤�ɂ��Ăق����B",
                Updated = DateTime.Parse("2014-07-01"),
                Article = article5
            });

            var article6 = new Article
            {
                Url = "http://www.example.com/mvc5",
                Title = "ASP.NET MVC ����",
                Category = CategoryEnum.DotNet,
                Description = "ASP.NET MVC�����ꂩ��n�߂�l�̂��߂ɁA�ڂ������J�ɒi�K��ǂ��ĉ�����܂��B",
                ViewCount = 0,
                Published = DateTime.Parse("2015-01-20"),
                Released = false
            };
            context.Articles.AddOrUpdate(article6);

            var article7 = new Article
            {
                Url = "http://www.example.com/azure",
                Title = "Azure�V�@�\TIPS",
                Category = CategoryEnum.Cloud,
                Description = "Microsoft Azure�̐V�@�\�ɂ���TIPS�`���ŁA�g�����Ȃǂ�������܂��B",
                ViewCount = 13469,
                Published = DateTime.Parse("2014-04-25"),
                Released = true
            };
            context.Articles.AddOrUpdate(article7);



            #endregion

            #region Author

            var author1 = new Author
            {
                Name = "�R�c���Y",
                Email = "taro@example.com",
                Birth = DateTime.Parse("1970-12-10"),
                Articles = new List<Article> { article, article2, article3, article5, article6 }
            };
            context.Authors.AddOrUpdate(author1);

            var author2 = new Author
            {
                Name = "��؋v��",
                Email = "kumi@example.com",
                Birth = DateTime.Parse("1985-11-12"),
                Articles = new List<Article> { article, article4, article7 }
            };
            context.Authors.AddOrUpdate(author2);

            var author3 = new Author
            {
                Name = "�����q�v",
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

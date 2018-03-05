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

            members.ForEach(m => context.Members.AddOrUpdate(item => item.Email, m));


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

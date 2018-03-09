using MvcBasic.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MvcBasic.Areas.API.Controllers
{
    public class ArticlesController : ApiController
    {
        private readonly MvcBasicContext db = new MvcBasicContext();

        public IEnumerable<Article> GetArticlesByCategory(CategoryEnum id)
        {
            var articles = db.Articles.Where(a => a.Category == id).OrderBy(a => a.Published);
            return articles;
        }

    }
}

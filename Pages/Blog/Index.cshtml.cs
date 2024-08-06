using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using razorweb.models;

namespace razorweb.Pages_Blog
{
    public class IndexModel : PageModel
    {
        private readonly razorweb.models.MyBlogContext _context;

        public IndexModel(razorweb.models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; } = default!;

        [BindProperty(SupportsGet =true, Name = "p")]
        public int currentPage {set;get;}
        public int countPages {set;get;}
        public const int ITEMS_PER_PAGE = 5;
        public async Task OnGetAsync(string searchString)
        {
            int nTotalArticles = await _context.Articles.CountAsync();
            countPages = (int)Math.Ceiling((double)nTotalArticles/ITEMS_PER_PAGE);
            Article = await _context.Articles.ToListAsync();

            if(currentPage<1)
                currentPage = 1;
            if(currentPage > countPages)
                countPages = countPages;

            var qr = from a in _context.Articles
            orderby a.Create select a;

            if(!string.IsNullOrEmpty(searchString))
            {
               Article = await (qr.Where(a=> a.Title.Contains(searchString))).Skip((currentPage-1)*ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE).ToListAsync();
            }
            else Article = await qr.Skip((currentPage-1)*ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE).ToListAsync();
        }
    }
}

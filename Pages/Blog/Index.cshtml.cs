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

        public async Task OnGetAsync(string searchString)
        {
            Article = await _context.Articles.ToListAsync();

            var qr = from a in _context.Articles
            orderby a.Create select a;

            if(!string.IsNullOrEmpty(searchString))
            {
               Article =  qr.Where(a=> a.Title.Contains(searchString)).ToList();
            }
            else Article = await qr.ToListAsync();
        }
    }
}

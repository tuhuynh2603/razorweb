using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using razorweb.models;

namespace razorweb.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly MyBlogContext myblogContext;
    public IndexModel(ILogger<IndexModel> logger, MyBlogContext _myblog)
    {
        _logger = logger;
        myblogContext = _myblog;
    }

    public void OnGet()
    {
        var posts = (from a in myblogContext.Articles orderby a.Create descending select a).ToList();
        ViewData["posts"] = posts;
    }
}

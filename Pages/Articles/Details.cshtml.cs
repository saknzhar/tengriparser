using System;
using System.Collections.Generic;
using System.Linq;
using lastfinal.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PuppeteerSharp.Input;
using lastfinal.Data;
using MongoDB.Driver;
using MongoDB.Bson;
using HtmlAgilityPack;

namespace lastfinal.Pages
{
	public class DetailsModel : PageModel
    {
        private readonly MongoDbContext _context;

        public DetailsModel(MongoDbContext context)
        {
            _context = context;
        }
        public News News { get; set; }
        public HtmlNode MyHtmlNode { get; set; }
        #region snippet1
        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var filter = Builders<News>.Filter.Eq(x => x.ArticleId, id);
            News = await _context.journal.Find(filter).FirstOrDefaultAsync();
            var document = new HtmlDocument();
            document.LoadHtml(News.Tags);
            MyHtmlNode = document.DocumentNode;
            if (News == null)
            {
                return NotFound();
            }
            return Page();
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lastfinal.Data;
using lastfinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;

namespace lastfinal.Pages
{
	public class NewsModel : PageModel
    {
        private readonly MongoDbContext _context;

        public NewsModel(MongoDbContext context)
        {
            _context = context;
        }

        public List<News> News { get; set; }

        public async Task OnGetAsync()
        {
            News = await _context.journal.Find(_ => true).ToListAsync();
        }
    }
}

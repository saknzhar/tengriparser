using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using lastfinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using PuppeteerSharp.Input;

namespace lastfinal.Pages.Articles
{
    public class CreateModel : PageModel
    {
        private readonly Data.MongoDbContext _context;

        public CreateModel(Data.MongoDbContext context)
        {
            _context = context;
        }

        public IActionResult OnPost(string LinqToArticle)
        {
            var newDoc = new News();
            newDoc.ArticleId = extractId(LinqToArticle);
            newDoc.LinqToArticle = LinqToArticle;
            newDoc.Tags = getTags(LinqToArticle);
            newDoc.Title = getTitle(LinqToArticle);
            _context.journal.InsertOne(newDoc);
            return RedirectToPage("/articles/index");
        }
        static string extractId(string link)
        {
            return new string(link.Where(char.IsDigit).ToArray()); ;
        }
        public string getTitle(string url)
        {
            HtmlAgilityPack.HtmlNode.ElementsFlags.Remove("form");
            var document = new HtmlWeb().Load(url);
            var divs = document.DocumentNode.SelectSingleNode("//h1[@class='tn-content-title']");
            return divs.InnerText.Split('\n')[0].Trim();
        }
        public string getTags(string url) {
            var document = new HtmlWeb().Load(url);
            var divs = document.DocumentNode.SelectSingleNode("//div[@class='tn-news-content']");
            if(divs == null)
            {
                return null;
            }
            return (without(divs.InnerHtml));
        }
        public string without(string tag)
        {
            string ans=String.Empty;
            string[] separ = { "\n", "                                                    " , "                                " };
            string[] TableName = tag.Split(separ, StringSplitOptions.None);
            foreach (var table in TableName)
            {
                ans += table;
            }
            return ans;
        }
    }
}


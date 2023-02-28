using System;
using lastfinal.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace lastfinal.Data
{
	public class MongoDbContext : DbContext
	{
        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoDatabase database)
        {
            _database = database;
        }
        public DbSet<Models.News> News { get; set; }
        public IMongoCollection<News> journal
        {
            get
            {
                return _database.GetCollection<News>("journal");
            }
        }
    }
}


using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lastfinal.Models
{
	public class News
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("ArticleId")]
        public string ArticleId { get; set; }
        public string LinqToArticle { get; set; }
		public string Tags { get; set; }
        public string Title { get; set; }
    }
}


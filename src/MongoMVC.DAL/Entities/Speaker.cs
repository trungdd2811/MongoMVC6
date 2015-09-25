using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoMVC.DAL.Entities
{
    public class Speaker
    {
        public ObjectId Id { get; set; }

        [BsonElement("first")]
        public string First { get; set; }

        [BsonElement("last")]
        public string Last { get; set; }

        [BsonElement("twitter")]
        public string Twitter { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("blog")]
        public string Blog { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace mONGOdb
{
        public class Postagem
        {
            [BsonId()]
            public ObjectId Id { get; set; }

            [BsonElement("title")]
            [BsonRequired()]
            public string Title { get; set; }

            [BsonElement("body")]
            [BsonRequired()]
            public string Body { get; set; }

            [BsonElement("criado")]
            [BsonRequired()]
            public DateTime Criado { get; set; }

            [BsonElement("active")]
            [BsonRequired()]
            public bool Active { get; set; }

            [BsonElement("value")]
            [BsonRequired()]
            public double Value { get; set; }

            [BsonElement("position")]
            [BsonRequired()]
            public int Position { get; set; }
        }
}

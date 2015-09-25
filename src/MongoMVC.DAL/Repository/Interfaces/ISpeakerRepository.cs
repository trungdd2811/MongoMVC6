using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoMVC.DAL.Entities;
using MongoDB.Bson;

namespace MongoMVC.DAL.Repository.Interfaces
{
    public interface ISpeakerRepository
    {
        IEnumerable<Speaker> AllSpeakers();

        Speaker GetById(ObjectId id);

        void Add(Speaker speaker);

        void Update(Speaker speaker);

        bool Remove(ObjectId id);
    }
}

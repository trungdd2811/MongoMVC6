﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Framework.OptionsModel;
using MongoMVC.DAL.Repository.Interfaces;
using MongoMVC.DAL.Entities;
using MongoMVC.Cores.Configurations;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace MongoMVC.DAL.Repository
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly MongoDBConfigs _settings;
        private readonly MongoDatabase _database;

        public SpeakerRepository(IOptions<MongoDBConfigs> settings)
        {
            _settings = settings.Options;
            _database = Connect();
        }

        public void Add(Speaker speaker)
        {
            _database.GetCollection<Speaker>("speakers").Save(speaker);
        }

        public IEnumerable<Speaker> AllSpeakers()
        {
            var speakers = _database.GetCollection<Speaker>("speakers").FindAll();
            return speakers;
        }

        public Speaker GetById(ObjectId id)
        {
            var query = Query<Speaker>.EQ(e => e.Id, id);
            var speaker = _database.GetCollection<Speaker>("speakers").FindOne(query);

            return speaker;
        }

        public bool Remove(ObjectId id)
        {
            var query = Query<Speaker>.EQ(e => e.Id, id);
            var result = _database.GetCollection<Speaker>("speakers").Remove(query);

            return GetById(id) == null;
        }

        public void Update(Speaker speaker)
        {
            var query = Query<Speaker>.EQ(e => e.Id, speaker.Id);
            var update = Update<Speaker>.Replace(speaker); // update modifiers
            _database.GetCollection<Speaker>("speakers").Update(query, update);
        }

        private MongoDatabase Connect()
        {
            var client = new MongoClient(_settings.Connection);
            var server = client.GetServer();
            var database = server.GetDatabase(_settings.Database);

            return database;
        }
    }

}

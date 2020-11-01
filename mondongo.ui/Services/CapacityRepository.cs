using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace mondongo.ui.Services
{
    public class CapacityRepository : ICapacityRepository
    {
        private readonly DateTime EPOCH = new DateTime(1970, 1, 1);
        private readonly IMongoCollection<CapacityDocument> capacityCollection;

        public CapacityRepository(IOptions<CapacityDatabaseSettings> capacityDatabaseSettingsOptions)
        {
            CapacityDatabaseSettings capacityDatabaseSettings = capacityDatabaseSettingsOptions.Value;
            MongoClient client = new MongoClient(capacityDatabaseSettings.ConnectionString);
            var database = client.GetDatabase(capacityDatabaseSettings.DatabaseName);

            this.capacityCollection = database.GetCollection<CapacityDocument>(capacityDatabaseSettings.CapacityCollectionName);
        }
        
        public void Increase()
        {
            CapacityDocument capacityDocument = this.Initialize();
            capacityDocument.TS = this.UnixNow();
            capacityDocument.Capacity++;

            this.capacityCollection.ReplaceOne(x => x.Id == capacityDocument.Id, capacityDocument);
        }

        public void Decrease()
        {
            CapacityDocument capacityDocument = this.Initialize();
            capacityDocument.TS = this.UnixNow();
            capacityDocument.Capacity--;

            this.capacityCollection.ReplaceOne(x => x.Id == capacityDocument.Id, capacityDocument);
        }

        public int GetCurrent()
        {
            CapacityDocument capacityDocument = this.Initialize();
            return capacityDocument.Capacity;
        }

        private CapacityDocument Initialize()
        {
            CapacityDocument capacityDocument = this.capacityCollection.Find(x => true)
                .FirstOrDefault();
            if (capacityDocument == null)
            {
                capacityDocument = new CapacityDocument()
                {
                    Capacity = 0,
                    TS = this.UnixNow()
                };
                this.capacityCollection.InsertOne(capacityDocument);
            }

            return capacityDocument;
        }

        private double UnixNow()
        {
            return (DateTime.UtcNow - this.EPOCH).TotalSeconds;
        }
    }
}
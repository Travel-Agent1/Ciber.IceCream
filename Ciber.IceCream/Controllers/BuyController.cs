﻿using System;
using System.Net;
using System.Net.Http.Formatting;
using System.Web.Http;
using CiberIs.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CiberIs.Controllers
{
    public class BuyController : ApiController
    {
        private readonly MongoDatabase _mongoDb = MongoHqConfig.RetrieveMongoHqDb();

        public dynamic Post(FormDataCollection data)
        {
            var ice = _mongoDb.GetCollection<IceCream>("IceCreams").FindOneById(new ObjectId(data.Get("iceCreamId")));
            if (ice == null) throw new HttpResponseException(HttpStatusCode.ExpectationFailed);
            try
            {
                ice.Quantity--;
                if(ice.Quantity < 0) throw new HttpResponseException(HttpStatusCode.Conflict);
                _mongoDb.GetCollection<IceCream>("IceCreams").Save(ice);
                _mongoDb.GetCollection<Purchase>("Purchases").Insert(new Purchase() { Price = ice.Price, Buyer = int.Parse(data.Get("buyer")), Time = DateTime.UtcNow });
            }
            catch (MongoException e)
            {
                return new { success = false, errorMessage = e.Message };
            }
            return new { success = true, errorMessage = string.Empty };
        }
    }
}

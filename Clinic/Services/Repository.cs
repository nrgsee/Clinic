﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteDB;
using Clinic.Models;

namespace Clinic.Services
{
    public abstract class BaseRepository<T> where T : IModel
    {
        public string Path { get; set; }
        public abstract string ModelName {  }
        protected virtual void Run(Action<LiteDatabase> action)
        {
            using (var db = new LiteDatabase(Path))
            {
                action.Invoke(db);
            }
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> list;
            Run((db) => { db.GetCollection<T>()  });
        }
    }




    /*
     using(var db = new LiteDatabase(@"MyData.db"))
{
    // Get customer collection
    var customers = db.GetCollection<Customer>("customers");

    // Create your new customer instance
    var customer = new Customer
    { 
        Name = "John Doe", 
        Phones = new string[] { "8000-0000", "9000-0000" }, 
        IsActive = true
    };

    // Insert new customer document (Id will be auto-incremented)
    customers.Insert(customer);

    // Update a document inside a collection
    customer.Name = "Joana Doe";

    customers.Update(customer);

    // Index document using a document property
    customers.EnsureIndex(x => x.Name);

    // Use Linq to query documents
    var results = customers.Find(x => x.Name.StartsWith("Jo"));
}
     */
}

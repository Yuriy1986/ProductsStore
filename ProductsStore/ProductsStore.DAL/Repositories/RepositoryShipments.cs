using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProductsStore.DAL.EF;
using ProductsStore.DAL.Entities;
using ProductsStore.DAL.Interfaces;

namespace ProductsStore.DAL.Repositories
{
    public class RepositoryShipments : IRepositoryShipments
    {
        readonly ApplicationDbContext db;

        public RepositoryShipments(ApplicationDbContext context)
        {
            this.db = context;
        }

        public bool CreateShipment()
        {
            return true;
        }


    }
}

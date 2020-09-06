using Library.DataAccess.Data;
using Library.Models.dbo;
using Library.Services.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Repository
{
    public class ProductRepository:RepositoryAsync<Product>,IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async void Update(Product product)
        {
            var objFromDb = await _db.Products.FirstOrDefaultAsync(i => i.Id == product.Id);
            if (objFromDb != null)
            {
                if (product.ImageUrl != null)
                {
                    objFromDb.ImageUrl = product.ImageUrl;
                }
                objFromDb.Name = product.Name;
                objFromDb.Description = product.Description;
                objFromDb.SKU = product.SKU;
                objFromDb.Price = product.Price;
                objFromDb.Qty = product.Qty;
                objFromDb.Availability = product.Availability;

            }
        }
    }
}

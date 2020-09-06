using Library.Models.dbo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Repository.IRepository
{
    public interface IProductRepository: IRepositoryAsync<Product>
    {
        void Update(Product product);
    }
}

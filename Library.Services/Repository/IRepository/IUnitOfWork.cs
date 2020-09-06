using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Repository.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        IProductRepository Product { get; }
        void Save();
    }
}

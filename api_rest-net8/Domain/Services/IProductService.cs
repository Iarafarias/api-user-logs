using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_rest.Communication;
using api_rest.Domain.Models;

namespace api_rest.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<GenericResponse<Product>> GetByIdAsync(int id);
        Task<GenericResponse<Product>> SaveAsync(Product product);
        Task<GenericResponse<Product>> UpdateAsync(int id, Product product);
        Task<GenericResponse<Product>> DeleteAsync(int id);

    }
}

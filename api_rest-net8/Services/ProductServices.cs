using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api_rest.Domain.Models;
using api_rest.Domain.Services;
using api_rest.Domain.Repositories;
using api_rest.Communication;

namespace api_rest.Services
{
    public class ProductService : IProductService
    {
        private readonly Domain.Repositories.IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(Domain.Repositories.IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }

        public async Task<GenericResponse<Product>> GetByIdAsync(int id)
        {
            var product = await _productRepository.FindByIdAsync(id);
            if (product == null)
                return new GenericResponse<Product>("Produto não encontrado.");

            return new GenericResponse<Product>(product);
        }

        public async Task<GenericResponse<Product>> SaveAsync(Product product)
        {
            try
            {
                await _productRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync();

                return new GenericResponse<Product>(product);
            }
            catch (Exception ex)
            {
                return new GenericResponse<Product>($"Erro ao salvar o produto: {ex.Message}");
            }
        }

        public async Task<GenericResponse<Product>> UpdateAsync(int id, Product product)
        {
            var existingProduct = await _productRepository.FindByIdAsync(id);

            if (existingProduct == null)
                return new GenericResponse<Product>("Produto não encontrado.");

            existingProduct.Name = product.Name;
            existingProduct.QuantityInPackage = product.QuantityInPackage;
            existingProduct.UnitOfMeasurement = product.UnitOfMeasurement;
            existingProduct.CategoryId = product.CategoryId;

            try
            {
                _productRepository.Update(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new GenericResponse<Product>(existingProduct);
            }
            catch (Exception ex)
            {
                return new GenericResponse<Product>($"Erro ao atualizar o produto: {ex.Message}");
            }
        }

        public async Task<GenericResponse<Product>> DeleteAsync(int id)
        {
            var existingProduct = await _productRepository.FindByIdAsync(id);

            if (existingProduct == null)
                return new GenericResponse<Product>("Produto não encontrado.");

            try
            {
                _productRepository.Remove(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new GenericResponse<Product>(existingProduct);
            }
            catch (Exception ex)
            {
                return new GenericResponse<Product>($"Erro ao deletar o produto: {ex.Message}");
            }
        }
    }
}
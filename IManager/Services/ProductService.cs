using System.Collections.Generic;
using IManager.Data;
using IManager.Models;

namespace IManager.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public InvItem GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public void AddProduct(InvItem product)
        {
            // Perform any necessary business logic validations or transformations before calling the repository
            // For example, ensure that required fields are provided or perform any data manipulation

            _productRepository.AddProduct(product);
        }

        public void UpdateProduct(InvItem product)
        {
            // Perform any necessary business logic validations or transformations before calling the repository

            _productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(int id)
        {
            InvItem product = _productRepository.GetProductById(id);

            if (product != null)
            {
                // Perform any necessary business logic validations or additional checks before deleting the product

                _productRepository.DeleteProduct(product);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;
using ConsoleAppFishFarminngToFile.Context;
using ConsoleAppFishFarminngToFile.Repository;
using ConsoleAppFishFarminngToFile.Repository.Implementation;
using ConsoleAppFishFarminngToFile.Repository.Interface;
using ConsoleAppFishFarminngToFile.Service.Interface;
using ConsoleAppFishFarminngToFile.ViewModel;

namespace ConsoleAppFishFarminngToFile.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository categoryRepository = new CategoryRepository();
        // ICustomerRepository customerRepository = new CustomerRepository();
        IPondRepository pondRepository= new PondRepository();
        public CategoryResponseModel Create(string name, string period, decimal price, int quantity, string pondName)
        {
            var getPond = pondRepository.GetPondByName(pondName);
            if (getPond == null)
            {
                return new CategoryResponseModel()
                {
                    Message = "Pond does not exist",
                    Status = false
                };
            }
        
            var exist = categoryRepository.GetCategoryByName(name);
            if (exist != null)
            {
                return new CategoryResponseModel()
                {
                    Message = "Category already exist",
                    Status = false
                };
            }
            if (getPond.SpaceRemain < quantity)
            {
                
                return new CategoryResponseModel()
                {
                    Message = "The space is not enough to contain the fish",
                    Status = false
                };   
            }
             getPond.SpaceRemain -= quantity;

            var id = DataAccess.categories.Count == 0 ? 1 : DataAccess.categories.Count + 1;
            var category = new Category(id, name, period, price, quantity, getPond.PondTagNumber, UserService.LoginUser.Email);
            categoryRepository.Create(category);
            // Console.WriteLine("******************** Category created succesfully ****************");
            return new CategoryResponseModel()
            {
                Message = "========== Created successfully ===========",
                Status = true,
                Category = category,
            };
        }

        public CategoryResponseModel DeleteCategory(int id)
        {
            var category = categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return new CategoryResponseModel()
                {
                    Message = "Category not found",
                    Status = false
                };
            }
            categoryRepository.IsDeleted(category);
             return new CategoryResponseModel()
            {
                Message = "Category found",
                Status = true,
                Category = category
            };
        }

        public List<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }


        public CategoryResponseModel GetById(int id)
        {
            var category = categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return new CategoryResponseModel()
                {
                    Message = "Category not found",
                    Status = false,
                };
            }
            return new CategoryResponseModel()
            {
                Message = "Category found",
                Status = true,
                Category = category
            };
        }

        public CategoryResponseModel GetCategoryByName(string name)
        {
            var category = categoryRepository.GetCategoryByName(name);
            if (category == null)
            {
                return new CategoryResponseModel()
                {
                    Message = "Category not found",
                    Status = false
                };
            }
              return new CategoryResponseModel()
            {
                Message = "Category found",
                Status = true,
                Category = category
            };
        }

        public CategoryResponseModel Update(int id, decimal price, int quantity)
        {
            var category = categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return new CategoryResponseModel()
                {
                    Message = "Category not found",
                    Status = false
                };
            }
            category.Price = price;
            category.Quantity += quantity;
             return new CategoryResponseModel()
            {
                Message = "=================== Category updated successful ===================",
                Status = true,
                Category = category
            };
        }

        public void ViewAllCategory()
        {
            var category = GetAll();
            foreach (var item in category)
            {
                Console.WriteLine($"Id: {item.Id}\t Name: {item.Name}\t Period {item.Period}\t Price: {item.Price}\t Quantity: {item.Quantity}");
            }
          
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;
using ConsoleAppFishFarminngToFile.ViewModel;

namespace ConsoleAppFishFarminngToFile.Service.Interface
{
    public interface ICategoryService
    {
        CategoryResponseModel Create(string name, string period, decimal price, int quantity, string pondName);
        CategoryResponseModel GetById(int id);
        CategoryResponseModel GetCategoryByName(string name);
        List<Category> GetAll();
        CategoryResponseModel Update(int id, decimal price, int quantity);
        void ViewAllCategory();
        CategoryResponseModel DeleteCategory(int id);
    }
}
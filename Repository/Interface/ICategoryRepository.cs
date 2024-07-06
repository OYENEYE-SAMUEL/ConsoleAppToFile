using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;

namespace ConsoleAppFishFarminngToFile.Repository.Interface
{
    public interface ICategoryRepository
    {
          Category Create(Category category);
        Category GetCategoryById(int id);
        Category GetCategoryByName(string name);
        List<Category> GetAll();
        Category Update(Category category);
        bool IsDeleted(Category category);
        void RefreshFromFile();

    }
}
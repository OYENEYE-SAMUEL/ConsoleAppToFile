using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;
using ConsoleAppFishFarminngToFile.Context;
using ConsoleAppFishFarminngToFile.Repository.Interface;

namespace ConsoleAppFishFarminngToFile.Repository.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        public Category Create(Category category)
        {
           using (var str = new StreamWriter(DataAccess.CategoryFilePath, true))
            {
                string text = category.ToString();
                str.WriteLine(text);
            }
            DataAccess.categories.Add(category);
            return category;
        }

       
        public List<Category> GetAll()
        {
           return DataAccess.categories;
        }

        public Category GetCategoryById(int id)
        {
           foreach (var item in DataAccess.categories)
           {
                if (item.Id == id)
                {
                    return item;
                }
           }
           return null;
        }

        public Category GetCategoryByName(string name)
        {
            foreach (var item in DataAccess.categories)
           {
                if (item.Name == name)
                {
                    return item;
                }
           }
           return null;
        }

        public bool IsDeleted(Category category)
        {
           DataAccess.categories.Remove(category);
           RefreshFromFile();
           return true;
        }

        

        public void RefreshFromFile()
        {
            File.WriteAllText(DataAccess.CategoryFilePath, string.Empty);
            foreach (var item in DataAccess.categories)
            {
                using (var str = new StreamWriter(DataAccess.CategoryFilePath, true))
                {
                str.WriteLine(item.ToString());
                }
            }
        }

        public Category Update(Category category)
        {
           var getCat = GetCategoryByName(category.Name);
           if (getCat == null)
           {
                return null;
           }
           getCat.Name = category.Name;
           getCat.Period = category.Period;
           getCat.Price = category.Price;
           getCat.Quantity = category.Quantity;
           RefreshFromFile();
           return getCat;
        }
    }
}
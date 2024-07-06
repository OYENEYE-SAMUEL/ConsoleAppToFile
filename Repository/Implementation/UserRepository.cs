using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Threading.Tasks;
using ConsoleAppFishFarminng.Models;
using ConsoleAppFishFarminngToFile.Context;
using ConsoleAppFishFarminngToFile.Repository.Interface;

namespace ConsoleAppFishFarminngToFile.Repository.Implementation
{
   public class UserRepository : IUserRepository
   {
      public User Create(User user)
      {
         DataAccess.users.Add(user);
         using (var str = new StreamWriter(DataAccess.UserFilePath, true))
         {
            string text = user.ToString();
            str.WriteLine(text);
         }
         return user;
      }


      public List<User> GetAllUser()
      {
         return DataAccess.users;
      }

      public User GetUser(int id)
      {
         foreach (var item in DataAccess.users)
         {
            if (item.Id == id)
            {
               return item;
            }
         }
         return null;
      }

      public User GetUserByEmail(string email)
      {

         foreach (var item in DataAccess.users)
         {
            if (item.Email == email)
            {
               return item;
            }
         }
         return null;
      }

    
      

      public void RefreshFromFile()
      {
         File.WriteAllText(DataAccess.UserFilePath, string.Empty);
         foreach (var item in DataAccess.users)
         {
            using (var str = new StreamWriter(DataAccess.UserFilePath, false))
            {
               str.WriteLine(item.ToString());
            }
         }
      }
   }
}

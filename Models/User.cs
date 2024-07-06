using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleAppFishFarminng.Models
{
    public class User : BaseEntity
    {
         public string Email { get; set; } = default!;
        public int Pin { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string RoleName { get; set; } = default!;
        public Gender Gender { get; set; } = default!;

         public User(int id, string email, int pin, string firstName, string lastName, string address, string phoneNumber, string roleName, Gender gender) : base(id)
        {
            Id = id;
            Email = email;
            Pin = pin;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            RoleName = roleName;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"{Id}\t{Email}\t{Pin}\t{FirstName}\t{LastName}\t{Address}\t{PhoneNumber}\t{RoleName}\t{Gender}";
        }

         public static User ConvertToUserObj(string st)
        {
            var data = st.Split('\t');
            var user = new User(int.Parse(data[0]), data[1], int.Parse(data[2]), data[3], data[4], data[5], data[6], data[7], (Gender)Enum.Parse(typeof(Gender), data[8]));
            return user;
        }


    }
}
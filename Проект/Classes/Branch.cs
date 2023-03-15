using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public Branch(int id, string name, string adress, string phoneNumber)
        {
            Id = id;
            Name = name;
            Adress = adress;
            PhoneNumber = phoneNumber;
        }
        public void Show()
        {
            Console.WriteLine($"Код филиала {Id}\n" +
                              $"Название филиала {Name}\n" +
                              $"Адрес {Adress}\n" +
                              $"Номер телефона {PhoneNumber} \n");
        }
        public string ToString()
        {
            return $"{Id},{Name},{Adress},{PhoneNumber}";
        }
        public static Branch ToClass(string line)
        {
            string[] mas = line.Split(',');
            Branch branch = new Branch(int.Parse(mas[0]), mas[1], mas[2], mas[3]);
            return branch;
        }
    }
}

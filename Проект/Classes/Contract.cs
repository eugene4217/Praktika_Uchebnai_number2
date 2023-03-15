using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Contract
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal InsuranceSum { get; set; }
        public decimal Rate { get; set; }
        public int Branch { get; set; }
        public int InsuranceType { get; set; }
        public Contract(int id, DateTime date, decimal insuranceSum, decimal rate, int branch, int insuranceType)
        {
            Id = id;
            Date = date;
            InsuranceSum = insuranceSum;
            Rate = rate;
            Branch = branch;
            InsuranceType = insuranceType;
        }
        public void Show()
        {
            Console.WriteLine($"Номер договора {Id}\n" +
                              $"Дата заключения {Date}\n" +
                              $"Страховая сумма {InsuranceSum}\n" +
                              $"Тарифная ставка {Rate} \n" +
                              $"Код филиала {Branch} \n" +
                              $"Код вида страхования {InsuranceType} \n");
        }
        public string ToString()
        {
            return $"{Id},{Date},{InsuranceSum},{Rate},{Branch},{InsuranceType}";
        }
        public static Contract ToClass(string line)
        {
            string[] mas = line.Split(",");
            Contract contract = new Contract(int.Parse(mas[0]), DateTime.Parse(mas[1]), decimal.Parse(mas[2]), decimal.Parse(mas[3]), int.Parse(mas[4]), int.Parse(mas[5]));
            return contract;
        }
    }
}

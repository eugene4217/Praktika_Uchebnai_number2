namespace Classes
{
    public class InsuranceType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal BaseCost { get; set; }
        public InsuranceType(int id, string name, decimal baseCost)
        {
            Id = id;
            Name = name;
            BaseCost = baseCost;
        }
        public void Show()
        {
            Console.WriteLine($"Код вида страхования {Id}\n" +
                              $"Название {Name}\n" +
                              $"Базовая тарифная ставка {BaseCost}\n");
        }
        public string ToString()
        {
            return $"{Id},{Name},{BaseCost}";
        }
        public static InsuranceType ToClass(string line)
        {
            string[] mas = line.Split(',');
            InsuranceType type = new InsuranceType(int.Parse(mas[0]), mas[1], decimal.Parse(mas[2]));
            return type;
        }
    }
}
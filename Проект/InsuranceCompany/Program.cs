using Classes;
using System;
using System.IO.Pipes;
using System.Net.Http.Headers;

Menu();
static void Menu()
{
    Console.Clear();
    Console.WriteLine("-----------------------------------------------------------------------------\n" +
                      "|Филиалы (1) |  Виды страхования (2)|  Договоры (3)|  Выход из программы (4)|\n" +
                      "-----------------------------------------------------------------------------");
    Console.Write("Введите код операции: ");
    char Code = Console.ReadKey(true).KeyChar;
    switch (Code)
    {
        case '1':
            BranchMenu();
            break;
        case '2':
            TypeMenu();
            break;
        case '3':
            ContractMenu();
            break;
        case '4':
            Environment.Exit(0);
            break;

    }
}

static void BranchMenu()
{
    ICollection<Branch> _branches = new List<Branch>();
    int branch_id = -1;

    using (StreamReader reader = new StreamReader("branches.txt"))
    {
        while (!reader.EndOfStream)
        {
            _branches.Add(Branch.ToClass(reader.ReadLine()));
        }
    }
    if (_branches.Count > 0) { branch_id = _branches.Last().Id; }
    Console.Clear();
    Console.WriteLine("--------------------------------------------------------------------------------\n" +
                      "|Показать филиалы(1)|  Добавить филиал(2)|  Удалить филиал(3)|  Выход в меню(4)|\n" +
                      "--------------------------------------------------------------------------------");
    Console.Write("Введите код операции: ");
    char Code = Console.ReadKey(true).KeyChar;
    switch (Code)
    {
        case '1':
            ShowBranches(_branches);
            break;
        case '2':
            AddBranch(_branches, branch_id);
            break;
        case '3':
            DeleteBranch(_branches);
            break;
        case '4':
            Menu();
            break;

    }
}

static void ShowBranches(ICollection<Branch> _branches)
{
    Console.Clear();
    if (_branches.Count == 0)
    {
        Console.WriteLine("Филиалов нет");
    }
    else
    {
        foreach (Branch branch in _branches)
        {
            branch.Show();
        }
    }
    Console.ReadKey();
    BranchMenu();
}

static void AddBranch(ICollection<Branch> _branches, int branch_id)
{
    Console.WriteLine("Введите название филиала");
    string Name = Console.ReadLine();
    Console.WriteLine("Введите адрес филиала");
    string Adress = Console.ReadLine();
    Console.WriteLine("Введите номер телефона");
    string PhoneNumber = Console.ReadLine();
    branch_id++;
    Branch branch = new Branch(branch_id, Name, Adress, PhoneNumber);
    _branches.Add(branch);
    using (StreamWriter writer = new StreamWriter("branches.txt", false))
    {
        foreach (Branch _branch in _branches)
        {
            writer.WriteLine(_branch.ToString());
        }
    }
    BranchMenu();
}

static void DeleteBranch(ICollection<Branch> _branches)
{
    Console.Clear();
    Console.WriteLine("Введите код филиала");
    int id = int.Parse(Console.ReadLine());
    var temp = _branches.Where(d => d.Id == id).First();
    if (temp is not null)
    {
        _branches.Remove(temp);
        using (StreamWriter writer = new StreamWriter("branches.txt", false))
        {
            foreach (Branch _branch in _branches)
            {
                writer.WriteLine(_branch.ToString());
            }
        }
    }
    else
    {
        Console.WriteLine("Филиала с таким кодом не существует");
        Console.ReadKey();
    }
    BranchMenu();
}

static void TypeMenu()
{
    ICollection<InsuranceType> _types = new List<InsuranceType>();
    int types_id = -1;

    using (StreamReader reader = new StreamReader("types.txt"))
    {
        while (!reader.EndOfStream)
        {
            _types.Add(InsuranceType.ToClass(reader.ReadLine()));
        }
    }
    if (_types.Count > 0)
    {
        types_id = _types.Last().Id;
    }
        Console.Clear();
        Console.WriteLine("-------------------------------------------------------------------------------\n" +
                          "|Показать виды страхования(1)| Добавить вид(2)| Удалить вид(3)| Выход в меню(4)|\n" +
                          "-------------------------------------------------------------------------------");
        Console.Write("Введите код операции: ");
        char Code = Console.ReadKey(true).KeyChar;
        switch (Code)
        {
            case '1':
                ShowTypes(_types);
                break;
            case '2':
                AddType(_types, types_id);
                break;
            case '3':
                DeleteType(_types);
                break;
            case '4':
                Menu();
                break;

        }
}

static void ShowTypes(ICollection<InsuranceType> types)
{
    Console.Clear();
    if (types.Count == 0) 
    {
        Console.WriteLine("Видов страхования нет");
    }
    else
    {
        foreach (InsuranceType type in types)
        {
            type.Show();
        }
    }
    Console.ReadKey();
    TypeMenu();
}

static void AddType(ICollection<InsuranceType> types, int type_id)
{
    Console.WriteLine("Введите название");
    string Name = Console.ReadLine();
    Console.WriteLine("Введите базовую ставку");
    decimal BaseCost = decimal.Parse(Console.ReadLine());
    type_id++;
    InsuranceType type = new InsuranceType(type_id, Name, BaseCost);
    types.Add(type);
    using (StreamWriter writer = new StreamWriter("types.txt", false))
    {
        foreach (InsuranceType _type in types)
        {
            writer.WriteLine(_type.ToString());
        }
    }
    TypeMenu();
}

static void DeleteType(ICollection<InsuranceType> types)
{
    Console.Clear();
    Console.WriteLine("Введите код вида страхования");
    int id = int.Parse(Console.ReadLine());
    var temp = types.Where(d => d.Id == id).First();
    if (temp is not null)
    {
        types.Remove(temp);
        using (StreamWriter writer = new StreamWriter("types.txt", false))
        {
            foreach (InsuranceType _type in types)
            {
                writer.WriteLine(_type.ToString());
            }
        }
    }
    else
    {
        Console.WriteLine("Вида страхования с таким кодом не существует");
        Console.ReadKey();
    }
    TypeMenu();
}

static void ContractMenu()
{
    ICollection<Contract> _contracts = new List<Contract>();
    int contract_id = -1;

    using (StreamReader reader = new StreamReader("contracts.txt"))
    {
        while (!reader.EndOfStream)
        {
            _contracts.Add(Contract.ToClass(reader.ReadLine()));
        }
    }
    if (_contracts.Count > 0) { contract_id = _contracts.Last().Id; }
    Console.Clear();
    Console.WriteLine("--------------------------------------------------------------------------------\n" +
                      "|Показать договоры(1)| Добавить договор(2)| Удалить договор(3)| Выход в меню(4)|\n" +
                      "-------------------------------------------------------------------------------");
    Console.Write("Введите код операции: ");
    char Code = Console.ReadKey(true).KeyChar;
    switch (Code)
    {
        case '1':
            ContractsShow(_contracts);
            break;
        case '2':
            ContractAdd(_contracts,contract_id);
            break;
        case '3':
            ContractDelete(_contracts);
            break;
        case '4':
            Menu();
            break;

    }
}

static void ContractsShow(ICollection<Contract> contracts)
{
    Console.Clear();
    if (contracts.Count== 0)
    {
        Console.WriteLine("Договоров нет");
    }
    else
    {
        foreach (Contract contract in contracts)
        {
            contract.Show();
        }
    }
    Console.ReadKey();
    ContractMenu();
}
static void ContractAdd(ICollection<Contract> contracts, int contract_id)
{
    ICollection<InsuranceType> _types = new List<InsuranceType>();

    using (StreamReader reader = new StreamReader("types.txt"))
    {
        while (!reader.EndOfStream)
        {
            _types.Add(InsuranceType.ToClass(reader.ReadLine()));
        }
    }

    ICollection<Branch> _branches = new List<Branch>();

    using (StreamReader reader = new StreamReader("branches.txt"))
    {
        while (!reader.EndOfStream)
        {
            _branches.Add(Branch.ToClass(reader.ReadLine()));
        }
    }
    Console.Clear();
    if (_types.Count == 0)
    {
        Console.WriteLine("Видов страхования нет");
        Console.ReadKey();
        ContractMenu();
    }
    else
    {
        foreach (InsuranceType type in _types)
        {
            type.Show();
            Console.WriteLine("Введите код нужного вида страхования");
        }
        int t_code = int.Parse(Console.ReadLine());
        int t_temp = _types.Where(d => d.Id == t_code).First().Id;
        if (t_temp != null)
        {
            Console.Clear();
            if (_branches.Count == 0)
            {
                Console.WriteLine("Филиалов нет");
                Console.ReadKey();
                ContractMenu();
            } else
            {
                foreach (Branch branch in _branches)
                {
                    branch.Show();
                }
                int b_code = int.Parse(Console.ReadLine());
                int b_temp = _branches.Where(d => d.Id == b_code).First().Id;
                if (b_temp != null)
                {
                    Console.Clear();
                    Console.WriteLine("Введите дату заключения");
                    DateTime Date = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Введите страховую сумму");
                    decimal InsuranceSum = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Введите тарифную ставку");
                    decimal Rate = decimal.Parse(Console.ReadLine());
                    contract_id++;
                    Contract contract = new Contract(contract_id, Date, InsuranceSum, Rate, b_code, t_code);
                    contracts.Add(contract);
                    using (StreamWriter writer = new StreamWriter("contracts.txt", false))
                    {
                        foreach (Contract _contract in contracts)
                        {
                            writer.WriteLine(_contract.ToString());
                        }
                    }
                }
            }
        }
    }
    ContractMenu();
}
static void ContractDelete(ICollection<Contract> contracts)
{
    Console.Clear();
    Console.WriteLine("Введите код договора");
    int id = int.Parse(Console.ReadLine());
    var temp = contracts.Where(d => d.Id == id).First();
    if (temp != null)
    {
        contracts.Remove(temp);
        using (StreamWriter writer = new StreamWriter("contracts.txt", false))
        {
            foreach (Contract contract in contracts)
            {
                writer.WriteLine(contract.ToString());
            }
        }
    }
    ContractMenu();
}
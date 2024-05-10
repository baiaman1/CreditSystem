using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


public class CreditSystem
{
    private List<Credit>? credits;
    private int nextId = 1;
    private string filename;

    public CreditSystem(string filename)
    {
        this.filename = filename;
        string json = File.ReadAllText(filename);
        var converter = new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" };
#pragma warning disable CS8601
        credits = JsonConvert.DeserializeObject<List<Credit>>(json, converter);
#pragma warning restore CS8601
        if (credits.Any())
        {
            nextId = credits.Max(c => c.ID) + 1;
        }
        if (credits != null)
            foreach (var credit in credits)
            {
                if (!string.IsNullOrEmpty(credit.CarModel))
                {
                    credit.Type = "Auto Loan";
                }
                else if (!string.IsNullOrEmpty(credit.AddressOfObject))
                {
                    credit.Type = "Mortgage";
                }
                else
                {
                    credit.Type = "Education Loan";
                }

            }
    }

    public void GetAllCredits()
    {
        if (credits != null)
            foreach (var credit in credits)
            {
                Console.WriteLine(credit.ToString());
                
            }
    }

    public void GetAllBanks()
    {
        Console.WriteLine($"ID | Name   | Address");
        if (credits != null)
            foreach (var credit in credits)
            {
                Console.WriteLine($"{credit.Bank.Id} | {credit.Bank.Name} | {credit.Bank.Address}");
            }
    }

    public void GetAllBorrowers()
    {
        Console.WriteLine($"ID | Name   | Birth Date | Passport Number");
        if (credits != null)
            foreach (var credit in credits)
            {
                Console.WriteLine($"{credit.Borrower.Id} | {credit.Borrower.FirstName} {credit.Borrower.LastName} | {credit.Borrower.DateOfBirth.ToString("dd.MM.yyyy")} | {credit.Borrower.PaasportNumber}");
            }
    }

    public void GetCreditsByType(string creditType)
    {
        foreach(Credit credit in credits)
        {
            if(credit.Type == creditType)
            {
                Console.WriteLine(credit.ToString());
                
            }
        }  
    }

    public void AddNewCredit()
    {
        Console.WriteLine("Выберите тип кредита:");
        Console.WriteLine("1. Автокредит");
        Console.WriteLine("2. Ипотека");
        Console.WriteLine("3. Кредит на обучение");
        Console.Write("Введите номер типа кредита: ");
        int typeChoice = int.Parse(Console.ReadLine());

        Credit newCredit = new Credit { ID = nextId++ };

        switch (typeChoice)
        {
            case 1:
                Console.Write("Введите сумму кредита: ");
                newCredit.Amount = decimal.Parse(Console.ReadLine());
                Console.Write("Введите срок кредита в месяцах: ");
                newCredit.CountOfMonth = int.Parse(Console.ReadLine());
                Console.Write("Введите процентную ставку: ");
                newCredit.Percent = double.Parse(Console.ReadLine());
                Console.Write("Введите модель автомобиля: ");
                newCredit.CarModel = Console.ReadLine();
                Console.Write("Введите марку автомобиля: ");
                newCredit.CarBrand = Console.ReadLine();
                Console.Write("Введите VIN код автомобиля: ");
                newCredit.VIN = Console.ReadLine();
                break;
            case 2:
                Console.Write("Введите сумму кредита: ");
                newCredit.Amount = decimal.Parse(Console.ReadLine());
                Console.Write("Введите срок кредита в месяцах: ");
                newCredit.CountOfMonth = int.Parse(Console.ReadLine());
                Console.Write("Введите процентную ставку: ");
                newCredit.Percent = double.Parse(Console.ReadLine());
                Console.Write("Введите адрес объекта ипотеки: ");
                newCredit.AddressOfObject = Console.ReadLine();
                Console.Write("Введите площадь объекта ипотеки: ");
                newCredit.Square = double.Parse(Console.ReadLine());
                break;
            case 3:
                Console.Write("Введите сумму кредита: ");
                newCredit.Amount = decimal.Parse(Console.ReadLine());
                Console.Write("Введите срок кредита в месяцах: ");
                newCredit.CountOfMonth = int.Parse(Console.ReadLine());
                Console.Write("Введите процентную ставку: ");
                newCredit.Percent = double.Parse(Console.ReadLine());
                Console.Write("Введите название университета: ");
                newCredit.UniversityName = Console.ReadLine();
                Console.Write("Введите адрес университета: ");
                newCredit.UniversityAddress = Console.ReadLine();
                break;
            default:
                Console.WriteLine("Неправильный выбор типа кредита.");
                return;
        }

        credits.Add(newCredit);
        SaveCreditsToFile();
        Console.WriteLine("Новый кредит добавлен успешно.");
    }
    private void SaveCreditsToFile()
    {
        string json = JsonConvert.SerializeObject(credits, Formatting.Indented);
        // File.WriteAllText(filename, json);
        File.AppendAllText(filename, json);
    }

    public void GetCreditsByBorrowerName(string LastName)
    {
        foreach(Credit credit in credits)
        {
            if(credit.Borrower.LastName == LastName)
            {
                Console.WriteLine(credit.ToString());
            }
        }
    }
}
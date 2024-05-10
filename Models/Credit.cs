using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;


public class Credit
{
    public int ID { get; set; }
    public decimal Amount { get; set; }
    public int CountOfMonth { get; set; }
    public double Percent { get; set; }
    
    [JsonIgnore]
    public string Type { get; set; } = "";
    [AllowNull]
    public Borrower Borrower { get; set; }
    [AllowNull]
    public Bank Bank { get; set; } 
    public string CarModel { get; set; } = "";
    public string CarBrand { get; set; } = "";
    public string VIN { get; set; } = "";
    public string AddressOfObject { get; set; } = "";
    public double Square { get; set; }
    public string UniversityName { get; set; } = "";
    public string UniversityAddress { get; set; } = "";

    public override string ToString()
    {
        return $"{ID} | {Amount} | {Percent} | {CountOfMonth} | {Type} | {Bank.Name} | {Borrower.LastName} {Borrower.FirstName}";
    }
}
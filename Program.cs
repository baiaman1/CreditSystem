using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filename = "credits.json";
        CreditSystem creditSystem = new CreditSystem(filename);
        // creditSystem.GetAllCredits();
        // creditSystem.GetAllBanks();
        // creditSystem.GetAllBorrowers();
        // creditSystem.GetCreditsByType("Education Loan");
        creditSystem.AddNewCredit();
        // creditSystem.GetCreditsByBorrowerName("Li");
    }
}

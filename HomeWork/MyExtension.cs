
namespace DebtorHomeWork;

static class MyExtension
{
    public static void AgeRangeDebtor(this List<Debtor> debtors, int MiddleAge, int BigAge)
    {
        int NowYear = DateTime.Now.Year;
        foreach (var debtor in debtors)
        {
            int AgeCalculator = NowYear - debtor.BirthDay.Year;
            if (MiddleAge < BigAge && AgeCalculator > MiddleAge && AgeCalculator < BigAge)
            { Console.WriteLine(debtor.ToString()); }

        }
    }

    public static void RangeDebtor(this List<Debtor> debtors, double Money)
    {
        foreach (var debtor in debtors)
        {
            if (debtor.Debt < Money) { Console.WriteLine(debtor.ToString()); }
        }
    }

    public static void Symbol(this List<Debtor> debtors, int symboCount, int number, int numberCount)
    {
        foreach (var debtor in debtors)
        {
            char CharParse = char.Parse(number.ToString()); // int to Char
            int CalCount = debtor.Phone.Count(c => c == CharParse); // symbol count
            if (debtor.FullName.Length > symboCount && CalCount >= numberCount)
                Console.WriteLine(debtor.ToString());
        }
    }

    public static void SameLetterCount(this List<Debtor> debtors , int LetterCount) 
    {
        foreach (var debtor in debtors)
        {
            string DebtorName = debtor.FullName.Split().First().ToLower();
            string DebtorSurname = debtor.FullName.Split().Last().ToLower();
            bool CheckName  = false;
            bool CheckSurname  = false;

            for (int i = 0; i < DebtorName.Length; i++)
            {
                var dublicatsNameCount = DebtorName.Count(c => c == DebtorName[i]);
                if(dublicatsNameCount >= LetterCount) CheckName = true; 
            }
            for (int i = 0; i < DebtorSurname.Length; i++)
            {
                var dublicatsSurnameCount = DebtorSurname.Count(c => c == DebtorSurname[i]);
                if (dublicatsSurnameCount >= LetterCount) CheckSurname = true;
            }

            if (CheckName && CheckSurname) Console.WriteLine(debtor.ToString());
        }
        
    }

    public static void PopularYear(this List<Debtor> debtors)
    {
        List<int> Years = new();
        foreach (var debtor in debtors) Years.Add(debtor.BirthDay.Year);

        var PopularYears = Years.GroupBy(y => y).OrderByDescending(g => g.Count()).First().Key;

        Console.WriteLine($"Popular Year-> {PopularYears}");

    }

    public static void TotalDebt(this List<Debtor> debtors)
    {
        int Total = 0;
        foreach (var debtor in debtors) Total += debtor.Debt;
        Console.WriteLine($"Total Debt-> {Total}");
    }

    public static void PhoneNoDuplicates(this List<Debtor> debtors)
    {
        List<Debtor> debtorsNoDuplicats = new();
        bool CheckBool = false;
        int check = 0;

        foreach (var debtor in debtors)
        {
            for (int i = 0; i < debtor.Phone.Length; i++) 
            {
                if (char.IsDigit(debtor.Phone[i])) // ancaq reqemleri goturur
                {
                    for (int j = i + 1; j < debtor.Phone.Length; j++)
                    {
                        if (debtor.Phone[i] == debtor.Phone[j]) { CheckBool = false; j = i = debtor.Phone.Length;}
                        else CheckBool = true;
                    }
                }
            }
            if (CheckBool) debtorsNoDuplicats.Add(debtor);
        }
        if (debtorsNoDuplicats.Count == 0 ) { Console.WriteLine("Not Phone Duplicats Debtor !"); }
        else
            foreach (var item in debtorsNoDuplicats) Console.WriteLine($"Debet -> {item.Debt}");        
    }

    public static void BrhitdayCash(this List<Debtor> debtors, int Pay)
    {
        List<Debtor> NotDebetors = new();
        int DateMonth = DateTime.Now.Month;
        int calculator = 0;

        foreach (var debtor in debtors)
        {
            for (int i = DateMonth; i != debtor.BirthDay.Month; i++)
            {
                calculator += Pay;
                if (i == 12) i = debtor.BirthDay.Month - 1;
            }
            if (debtor.Debt - calculator <= 0) { NotDebetors.Add(debtor); }
            calculator = 0;
        }

        foreach (var item in NotDebetors) Console.WriteLine(item.ToString());

    }

    public static void WordinDebtor(this List<Debtor> debtors, string Word)
    {
        char[] CharWord = Word.ToLower().ToCharArray();
        List<Debtor> WordsDebtor = new();
        int len = 0;

        foreach (var debtor in debtors)
        {
            debtor.FullName.ToLower();
            for (int i = 0; i < CharWord.Length; i++)
                if (debtor.FullName.Contains(CharWord[i])) len++;

            if (len == CharWord.Length) WordsDebtor.Add(debtor);
            len = 0;
        }

        foreach(var item in WordsDebtor) Console.WriteLine(item.ToString());
        
    }



}

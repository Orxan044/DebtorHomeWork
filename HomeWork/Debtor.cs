

namespace DebtorHomeWork;


class Debtor
{
    public Debtor(string fullname, DateTime birthDay, string phone, string email, string address, int debt)
    {
        FullName = fullname;
        BirthDay = birthDay;
        Phone = phone;
        Email = email;
        Address = address;
        Debt = debt;
    }

    public string FullName { get; set; }
    public DateTime BirthDay { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public int Debt { get; set; }
    public override string ToString()
    {
        return $"{FullName} {BirthDay.ToShortDateString()} {Phone} {Email} {Address} {Debt}";
    }

}



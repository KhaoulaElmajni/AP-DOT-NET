using System.Text.Json;

namespace FIRSTAPP.Service
{
    public class Account
    {
        public int id { get; set; }
        public string? currency { get; set; }
        public double balance { get; set; }

        public Account(){}

        public Account(int id, string currency, double balance)
        {
            this.id = id;
            this.currency = currency;
            this.balance = balance;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
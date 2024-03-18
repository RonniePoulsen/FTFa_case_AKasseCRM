namespace FTFa_case_AKasseCRM
{
    public class Member
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsEmployed { get; set; } = true;
        public decimal LastKnownSalary { get; set; }
        public decimal BenefitAmount 
        { 
            get 
            {
                return Math.Min(LastKnownSalary * 0.9M, 19728M);
            } 
        }


        public override string ToString()
        {
            return $"ID: {Id}\n" +
                   $"Full Name: {FullName}\n" +
                   $"Email: {Email}\n" +
                   $"Employment Status: {(IsEmployed ? "Employed" : "Unemployed")}\n" +
                   $"Last Known Salary: {LastKnownSalary:C}\n" +  
                   $"Benefit Amount: {BenefitAmount:C}\n";       
        }
    }
}
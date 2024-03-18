namespace FTFa_case_AKasseCRM
{
    public static class Database
    {
        public static List<Member> Members { get; set; } = new List<Member>
        {
            new Member
            {
                Id = 1,
                FullName = "Anders And",
                Email = "anders@ducky.com",
                IsEmployed = true,
                LastKnownSalary = 25000M,
            },
            new Member
            {
                Id = 2,
                FullName = "Mickey Mouse",
                Email = "mouseman@disney.com",
                IsEmployed = false,
                LastKnownSalary = 22000M,
            },
            new Member
            {
                Id = 3,
                FullName = "Fedtmule",
                Email = "fedtmule@gmail.com",
                IsEmployed = true,
                LastKnownSalary = 23000M,
            }
        };
    }
}
namespace FTFa_case_AKasseCRM;

internal class MemberService
{
    /// <summary>
    /// Registers a new member to the current collection.
    /// </summary>
    public void RegisterMember()
    {
        Console.Clear();
        Console.WriteLine("Register New Member");
        Console.WriteLine("--------------------------------");
        
        var member = new Member();
        member.Id = GetNewMemberId();
        
        Console.Write("Full name:");
        member.FullName = Console.ReadLine();
        
        Console.Write("Email:");
        member.Email = Console.ReadLine();
        
        Console.Write("Last known salary:");
        member.LastKnownSalary = Convert.ToDecimal(Console.ReadLine());

        Database.Members.Add(member);

        Console.WriteLine("\nNew member registered:\n");
        Console.Write(member);
    }

    /// <summary>
    /// Shows the current collection of members.
    /// </summary>
    public void ViewMembers()
    {
        Console.Clear();
        Console.WriteLine("Members list:\n");
        foreach (var member in Database.Members)
        {
            Console.WriteLine(member);
        }
    }

    /// <summary>
    /// Looks up a member by either full name or email.
    /// </summary>
    public void LookupMember()
    {
        var continueRunning = true;
        while (continueRunning)
        {
            Console.Clear();
            Console.WriteLine("Search for a member");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Search by full name");
            Console.WriteLine("2. Search by email");
            Console.WriteLine("3. Return to main menu");
            Console.Write("Please select an option (1-3): ");

            var userInput = Console.ReadLine();
            Member member;

            switch (userInput)
            {
                case "1":
                    Console.Write("\nMember full name:");
                    member = GetMemberByFullName(Console.ReadLine());
                    if (member == null)
                    {
                        Console.WriteLine("Member not found.");
                        break;
                    }
                    Console.WriteLine(member);
                    break;
                case "2":
                    Console.Write("\nMember email:");
                    member = GetMemberByEmail(Console.ReadLine());
                    if (member == null)
                    {
                        Console.WriteLine("Member not found.");
                        break;
                    }
                    Console.WriteLine(member);
                    break;
                case "3":
                    continueRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a number between 1 and 3.");
                    break;
            }

            if (continueRunning)
            {
                Console.WriteLine("\nPress any key to try again...");
                Console.ReadKey();
            }
        }

    }

    /// <summary>
    /// Updates the employment status of a specific member.
    /// </summary>
    public void UpdateEmploymentStatus()
    {
        Console.Clear();
        Console.WriteLine("Update member employment status");
        Console.WriteLine("-------------------------------\n");
        Console.Write("Enter ID of the user to update: ");
        var id = Console.ReadLine();
        var member = GetMember(m => m.Id == Convert.ToUInt32(id));
        Console.WriteLine("\n" + member);
        Console.WriteLine("\nSet employment status (Employed = 1, Unemployed = 2): ");
        var status = Console.ReadLine();
        if(status == "1")
        {
            member.IsEmployed = true;
        }
        else if(status == "2")
        { 
            member.IsEmployed = false; 
        }
        else
        {
            Console.WriteLine("Something went wrong. Go back to main menu and try again.");
        }
        Console.WriteLine($"\nMember is now {(member.IsEmployed ? "employed" : "unemployed")}.");
    }

    /// <summary>
    /// Deletes a specific member from the current collection.
    /// </summary>
    public void DeleteMember()
    {
        Console.Clear();
        Console.Write("Enter ID of member to delete:");
        var id = Convert.ToInt32(Console.ReadLine());
        var member = GetMember(m => m.Id == id);
        if (member != null)
        {
            Database.Members.Remove(member);
            Console.WriteLine("\nMember deleted.");
        }
        else
        {
            Console.WriteLine($"No member found with ID:{id}");
        }
    }

    /// <summary>
    /// Gets a unused ID for a new member.
    /// </summary>
    /// <returns>Returns the highest existing ID + 1.</returns>
    private int GetNewMemberId()
    {
        return Database.Members.Select(m => m.Id).ToArray().Max() + 1;
    }

    /// <summary>
    /// Gets a member by email.
    /// </summary>
    /// <param name="email">Email of the member.</param>
    /// <returns>Returns the member that matches the given email.</returns>
    private Member GetMemberByEmail(string email)
    {
        return GetMember(m => m.Email == email);
    }

    /// <summary>
    /// Gets a member by full name.
    /// </summary>
    /// <param name="fullName">Full name of the member.</param>
    /// <returns>Returns the member that matches the given full name.</returns>
    private Member GetMemberByFullName(string fullName)
    {
        return GetMember(m=>m.FullName == fullName);
    }

    /// <summary>
    /// Gets a matching member from the database.
    /// </summary>
    /// <param name="filter">A linq query to use for filter.</param>
    /// <returns>Returns the member matching the search filter.</returns>
    private Member GetMember(Func<Member, bool> filter)
    {
        return Database.Members.FirstOrDefault(filter);
    }
}

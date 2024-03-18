using FTFa_case_AKasseCRM;

var memberService = new MemberService();

bool continueRunning = true;

while (continueRunning)
{
    Console.Clear();
    Console.WriteLine("A-kasse Member Management System");
    Console.WriteLine("--------------------------------");
    Console.WriteLine("1. Register a new member");
    Console.WriteLine("2. View all members");
    Console.WriteLine("3. Search for a member");
    Console.WriteLine("4. Update employment status of a member");
    Console.WriteLine("5. Delete member");
    Console.WriteLine("6. Exit");
    Console.Write("\nPlease select an option (1-6): ");

    string userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            memberService.RegisterMember();
            break;
        case "2":
            memberService.ViewMembers();
            break;
        case "3":
            memberService.LookupMember();
            break;
        case "4":
            memberService.UpdateEmploymentStatus();
            break;
        case "5":
            memberService.DeleteMember();
            break;
        case "6":
            continueRunning = false;
            break;
        default:
            Console.WriteLine("Invalid choice. Please select a number between 1 and 6.");
            break;
    }

    if (continueRunning)
    {
        Console.WriteLine("\nPress any key to return to the main menu...");
        Console.ReadKey();
    }
}
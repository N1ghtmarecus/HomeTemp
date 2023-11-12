namespace HomeTemp;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("  Welcome to HomeTemp Project!  ");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Acceptable values: -30 to +50°C.");

        var livingRoom = new RoomInFile("Living Room");
        var bedroom = new RoomInFile("Bedroom");
        var bathroom = new RoomInFile("Bathroom");

        List<RoomInFile> rooms = new List<RoomInFile>() { livingRoom, bedroom, bathroom };

        var roomInFile = new RoomInFile("");

        bool showMenu = true;

        while (true)
        {
            if (showMenu)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Enter rooms temperatures");
                Console.WriteLine("2. Show statistics");
                Console.WriteLine("3. Quit the program");
            }

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nIf you want to finish adding temperatures press 'Q' and view statistics.");
                    while (true)
                    {
                        EnterTemperatures(rooms);

                        if (!ContinueEnteringTemperatures())
                        {
                            break;
                        }
                    }
                    roomInFile.ShowStatistics(rooms);
                    showMenu = true;
                    break;
                case "2":
                    roomInFile.ShowStatistics(rooms);
                    showMenu = true;
                    break;
                case "3":
                    Console.WriteLine("Quitting the program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    showMenu = false;
                    break;
            }
        }

        static void EnterTemperatures(List<RoomInFile> rooms)
        {
            foreach (RoomInFile room in rooms)
            {
                bool continueEntering = true;

                while (continueEntering)
                {
                    Console.Write($"\nEnter the next {room.Name} temperature: ");
                    var input = Console.ReadLine().ToUpper();

                    if (input == "Q")
                    {
                        Console.WriteLine("Ending process.");
                        return;
                    }

                    try
                    {
                        room.AddTemp(input);
                        continueEntering = false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exception caught: {ex.Message}");
                    }
                }
            }
        }

        static bool ContinueEnteringTemperatures()
        {
            while (true)
            {
                Console.Write("\nDo you want to continue entering temperatures? Y/N : ");
                var userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "Y":
                        Console.WriteLine("Continue entering temperatures.");
                        return true;
                    case "N":
                        Console.WriteLine("Ending process.");
                        return false;
                    default:
                        Console.WriteLine("Wrong letter! Please enter 'Y' or 'N'.");
                        break;
                }
            }
        }
    }
}
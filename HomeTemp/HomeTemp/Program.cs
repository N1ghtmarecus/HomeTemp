namespace HomeTemp;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("  Welcome to HomeTemp Project!  ");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Acceptable values: -30 to +50°C.");

        var livingRoom = new RoomInFile("Living Room");
        var bedroom = new RoomInFile("Bedroom");
        var bathroom = new RoomInFile("Bathroom");

        List<RoomInFile> rooms = new List<RoomInFile>() { livingRoom, bedroom, bathroom };

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
                    Console.WriteLine("\nIf you want to finish adding temperatures press 'Q' and view rooms statistics.");
                    while (true)
                    {
                        EnterTemperatures(rooms);

                        if (!ContinueEnteringTemperatures())
                        {
                            break;
                        }
                    }
                    ShowStatistics(rooms);
                    showMenu = true;
                    break;
                case "2":
                    ShowStatistics(rooms);
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

        static void ShowStatistics(List<RoomInFile> rooms)
        {
            Console.WriteLine("\nSTATISTICS:");

            RoomInFile warmestRoom = null;
            RoomInFile coldestRoom = null;
            bool anyDataFound = false;

            foreach (RoomInFile room in rooms)
            {
                var roomStatistics = room.GetStatistics();

                if (roomStatistics.Count != 0)
                {
                    Console.WriteLine($"\n{room.Name}:");
                    Console.WriteLine(new string('-', room.Name.Length));
                    Console.WriteLine($"Total amount of correct values: {roomStatistics.Count}");
                    Console.WriteLine($"Average temperature: {roomStatistics.Average:N1}°C");
                    Console.WriteLine($"Min temperature: {roomStatistics.Min:N1}°C");
                    Console.WriteLine($"Max temperature: {roomStatistics.Max:N1}°C");

                    if (warmestRoom == null || roomStatistics.Average > warmestRoom.GetStatistics().Average)
                    {
                        warmestRoom = room;
                    }

                    if (coldestRoom == null || roomStatistics.Average < coldestRoom.GetStatistics().Average)
                    {
                        coldestRoom = room;
                    }

                    anyDataFound = true;
                }
            }

            if (!anyDataFound)
            {
                Console.WriteLine("No temperature data found in any room. Please enter temperatures first.");
            }
            else
            {
                if (warmestRoom != null)
                {
                    Console.WriteLine($"\nRoom with highest average temperature - {warmestRoom.Name}: {warmestRoom.GetStatistics().Average:N1}°C");
                }
                if (coldestRoom != null)
                {
                    Console.WriteLine($"Room with lowest average temperature - {coldestRoom.Name}: {coldestRoom.GetStatistics().Average:N1}°C");
                }
            }

            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }
    }
}
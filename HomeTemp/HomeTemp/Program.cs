namespace HomeTemp;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("----------------------------");
        Console.WriteLine("Welcome to HomeTemp Project!");
        Console.WriteLine("----------------------------");
        Console.WriteLine("Acceptable values: -30 to +50 degrees Celsius.");
        Console.WriteLine("Press 'Q' to finish adding temperatures and view statistics.");

        var livingRoom = new RoomInFile("Living Room");
        var bedroom = new RoomInFile("Bedroom");
        var bathroom = new RoomInFile("Bathroom");

        List<RoomInFile> rooms = new List<RoomInFile>() { livingRoom, bedroom, bathroom };

        var roomInFile = new RoomInFile("");

        while (true)
        {
            EnterTemperatures(rooms);

            if (!ContinueEnteringTemperatures())
            {
                break;
            }
        }
        roomInFile.ShowStatistics(rooms);
    }

    private static void EnterTemperatures(List<RoomInFile> rooms)
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

    private static bool ContinueEnteringTemperatures()
    {
        while (true)
        {
            Console.Write("\nDo you want to continue entering temperatures? Y/N : ");
            var userInput = Console.ReadLine().ToUpper();

            if (userInput == "Y")
            {
                Console.WriteLine("Continue entering temperatures.");
                return true;
            }
            else if (userInput == "N")
            {
                Console.WriteLine("Ending process.");
                return false;
            }
            else
            {
                Console.WriteLine("Wrong letter! Please enter 'Y' or 'N'.");
            }
        }
    }
}
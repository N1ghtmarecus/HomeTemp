using HomeTemp;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("----------------------------");
        Console.WriteLine("Welcome to HomeTemp Project!");
        Console.WriteLine("----------------------------");
        Console.WriteLine("Acceptable values: -30 to +50 degrees Celsius.");
        Console.WriteLine("Press 'Q' to finish adding temperatures and view statistics.");

        var livingRoom = new RoomInMemory("Living Room");
        var bedroom = new RoomInMemory("Bedroom");

        while (true)
        {
            while (true)
            {
                Console.Write($"\nEnter the next Living Room temperature: ");
                var input = Console.ReadLine().ToUpper();

                if (input == "Q")
                    break;

                try
                {
                    livingRoom.AddTemp(input);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception catched: {ex.Message}");
                }
            }

            while (true)
            {
                Console.Write($"\nEnter the next Bedroom temperature: ");
                var input = Console.ReadLine().ToUpper();

                if (input == "Q")
                    break;

                try
                {
                    bedroom.AddTemp(input);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception catched: {ex.Message}");
                }
            }

            Console.Write("\nDo you want to continue entering temperatures? Y/N : ");
            var userInput = Console.ReadLine().ToUpper();

            switch (userInput)
            {
                case "Y":
                    Console.WriteLine("Continue entering temperatures.");
                    continue;
                case "N":
                    Console.WriteLine("Ending process.");
                    break;
                default:
                    Console.WriteLine("Wrong letter! Ending process!");
                    break;
            }
            break;
        }

        var livingRoomStatistics = livingRoom.GetStatistics();

        Console.WriteLine("\nSTATISTICS:");

        Console.WriteLine("\nLiving Room:");
        Console.WriteLine("------------");
        Console.WriteLine($"Total amount of correct values: {livingRoomStatistics.Count}");
        Console.WriteLine($"Average temperature: {livingRoomStatistics.Average:N1}");
        Console.WriteLine($"Min temperature: {livingRoomStatistics.Min:N1}");
        Console.WriteLine($"Max temperature: {livingRoomStatistics.Max:N1}");

        var bedroomStatistics = bedroom.GetStatistics();

        Console.WriteLine("\nBedroom:");
        Console.WriteLine("--------");
        Console.WriteLine($"Total amount of correct values: {bedroomStatistics.Count}");
        Console.WriteLine($"Average temperature: {bedroomStatistics.Average:N1}");
        Console.WriteLine($"Min temperature: {bedroomStatistics.Min:N1}");
        Console.WriteLine($"Max temperature: {bedroomStatistics.Max:N1}");

        var totalSum = livingRoomStatistics.Sum + bedroomStatistics.Sum;
        var totalCount = livingRoomStatistics.Count + bedroomStatistics.Count;
        var totalAverage = totalSum / totalCount;

        Console.WriteLine("\nTotal: ");
        Console.WriteLine("-------");
        Console.WriteLine($"Total amount of correct values: {totalCount}");
        Console.WriteLine($"Average temperature: {totalAverage:N1}");
    }
}


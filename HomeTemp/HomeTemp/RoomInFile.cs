﻿namespace HomeTemp

{
    public class RoomInFile : RoomBase
    {
        private string roomFileName;

        public RoomInFile(string name)
            : base(name)
        {
        }

        public override event TempAddedDelegate TempAdded;

        public override void AddTemp(float temp)
        {
            if (temp >= -30.0f && temp <= 50.0f)
            {
                roomFileName = $"{Name}_Temperatures.txt";

                using (var writer = File.AppendText(roomFileName))
                    writer.WriteLine(temp);

                if (TempAdded != null) 
                    TempAdded(this, new EventArgs());
            }
            else if (temp < -30.0f)
                throw new Exception("Even snow hides in the fridge! Please enter the correct value from -30 to +50°C!");
            else
                throw new Exception("What da Hell?! Please enter the correct value from -30 to +50°C!");
        }

        public override Statistics GetStatistics()
        {
            var tempsFromFile = this.ReadTempsFromFile();
            var result = this.CountStatistics(tempsFromFile);
            return result;
        }

        private List<float> ReadTempsFromFile()
        {
            var temps = new List<float>();
            if (File.Exists($"{roomFileName}"))
            {
                using (var reader = File.OpenText($"{roomFileName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        temps.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return temps;
        }

        private Statistics CountStatistics(List<float> temps)
        {
            var statistics = new Statistics();

            foreach (var temp in temps)
            {
                statistics.AddTemp(temp);
            }

            return statistics;
        }

        public void ShowStatistics(List<RoomInFile> rooms)
        {
            Console.WriteLine("\nSTATISTICS:");

            foreach (RoomInFile room in rooms)
            {
                var roomStatistics = room.GetStatistics();

                Console.WriteLine($"\n{room.Name}:");
                Console.WriteLine(new string('-', room.Name.Length));
                Console.WriteLine($"Total amount of correct values: {roomStatistics.Count}");
                Console.WriteLine($"Average temperature: {roomStatistics.Average:N1}°C");
                Console.WriteLine($"Min temperature: {roomStatistics.Min:N1}°C");
                Console.WriteLine($"Max temperature: {roomStatistics.Max:N1}°C");
            }
        }
    }
}

namespace HomeTemp

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
            roomFileName = $"{Name}_Temperatures.txt";

            if (File.Exists(roomFileName))
            {
                try
                {
                    using (var reader = File.OpenText(roomFileName))
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
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading temperature data: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"No temperature data found for {Name}.");
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
    }
}

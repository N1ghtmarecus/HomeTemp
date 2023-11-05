namespace HomeTemp
{
    public abstract class RoomBase : IRoom
    {
        public delegate void TempAddedDelegate(object sender, EventArgs args);

        public abstract event TempAddedDelegate TempAdded;

        public string Name { get; private set; }
        public RoomBase(string name)
        {
            this.Name = name;
        }

        public abstract void AddTemp(float temp);

        public abstract void AddTemp(string temp);

        public abstract void AddTemp(double temp);

        public abstract void AddTemp(long temp);

        public abstract Statistics GetStatistics();

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

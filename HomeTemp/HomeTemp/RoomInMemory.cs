namespace HomeTemp
    
{
    public class RoomInMemory : RoomBase
    {
        public override event TempAddedDelegate TempAdded;

        private readonly List<float> temps = new();
        public RoomInMemory(string name)
            : base(name)
        {
        }

        public override void AddTemp(float temp)
        {
            if (temp >= -30.0f && temp <= 50.0f)
            {
                this.temps.Add(temp);
                Console.WriteLine($"Temperature {temp:N1}°C added succesfully!");
            }
            else if (temp < -30.0f)
                throw new Exception("Even snow hides in the fridge! Please enter the correct value from -30 to +50°C!");
            else
                throw new Exception("What da Hell?! Please enter the correct value from -30 to +50°C!");
        }

        public override void AddTemp(string temp)
        {
            if (float.TryParse(temp, out float result))
                AddTemp(result);
            else
                throw new Exception("Please enter the correct value!");
        }

        public override void AddTemp(double temp)
        {
            float tempAsDouble = (float)temp;
            AddTemp(tempAsDouble);
        }

        public override void AddTemp(long temp)
        {
            float tempAsLong = (float)temp;
            AddTemp(tempAsLong);
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var temp in this.temps)
            {
                statistics.AddTemp(temp);
            }
            return statistics;
        }
    }
}

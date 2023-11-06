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

        public void AddTemp(string temp)
        {
            if (float.TryParse(temp, out float result))
                AddTemp(result);
            else
                throw new Exception("Please enter the correct value!");
        }

        public void AddTemp(double temp)
        {
            float tempAsDouble = (float)temp;
            AddTemp(tempAsDouble);
        }

        public void AddTemp(long temp)
        {
            float tempAsLong = (float)temp;
            AddTemp(tempAsLong);
        }

        public abstract Statistics GetStatistics();
    }
}

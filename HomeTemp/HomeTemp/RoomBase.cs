namespace HomeTemp
{
    public abstract class RoomBase : IRoom
    {
        public RoomBase(string name) 
        {
            this.Name = name;
        }
        public string Name { get; private set; }

        public abstract void AddTemp(float temp);

        public abstract void AddTemp(string temp);

        public abstract void AddTemp(double temp);

        public abstract void AddTemp(long temp);

        public abstract Statistics GetStatistics();
    }
}

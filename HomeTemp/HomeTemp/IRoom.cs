using static HomeTemp.RoomBase;

namespace HomeTemp
{
    public interface IRoom
    {
        string Name { get; }

        void AddTemp(float temp);
        void AddTemp(string temp);
        void AddTemp(double temp);
        void AddTemp(long temp);

        Statistics GetStatistics();

        event TempAddedDelegate TempAdded;

        // public void ShowStatistics(List<RoomInMemory> rooms);
        public void ShowStatistics(List<RoomInFile> rooms);
    }
}

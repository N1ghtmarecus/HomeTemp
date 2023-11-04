namespace HomeTemp
{
    public class Statistics
    {
        public float Min { get; private set; }

        public float Max { get; private set; }

        public int Count { get; private set; }

        public float Sum { get; private set; }

        public float Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public Statistics() 
        {
            this.Min    = float.MaxValue;
            this.Max    = float.MinValue;
            this.Count  = 0;
            this.Sum    = 0;
        }

        public void AddTemp(float temp)
        {
            this.Min = Math.Min(temp, this.Min);
            this.Max = Math.Max(temp, this.Max);
            this.Count++;
            this.Sum += temp;
        }

    }
}

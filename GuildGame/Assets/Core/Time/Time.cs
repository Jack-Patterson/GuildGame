namespace com.Halkyon.Time
{
    public class Time
    {
        public int Days;
        public int Hours;
        public int Minutes;
        
        public Time(int days, int hours, int minutes)
        {
            Days = days;
            Hours = hours;
            Minutes = minutes;
        }

        public void Increment()
        {
            Minutes++;
            
            if (Minutes < 60) return;
            Minutes = 0;
            Hours++;
            
            if (Hours < 24) return;
            Hours = 0;
            Days++;
        }

        public override string ToString()
        {
            return $"{Days:00}:{Hours:00}:{Minutes:00}";
        }
    }
}
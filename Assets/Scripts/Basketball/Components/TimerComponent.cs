namespace basketball
{
    public struct TimerComponent
    {
        public TimerType Type;
        public float StartTime;
        public float TargetTime;
    }
    public enum TimerType { BallDestroy, LevelTime}
}

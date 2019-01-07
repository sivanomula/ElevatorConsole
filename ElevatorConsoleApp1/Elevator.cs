namespace ElevatorConsoleApp1
{
    internal class Elevator
    {
        public string Name { get; set; }
        public int Floors { get; set; }
        public EnumDirection Direction { get; set; } = EnumDirection.Up;
        public int CurrentFloor { get; set; } = 0;
        public int DestinationFloor { get; set; } = 0;
        public bool IsBusy { get;  set; }
    }
}
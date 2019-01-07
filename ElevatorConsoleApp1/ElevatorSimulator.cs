using System;
using System.Collections.Generic;
using System.Linq;

namespace ElevatorConsoleApp1
{
    internal class ElevatorSimulator
    {
        private readonly ElevatorBL elevatorBl;
        private readonly int elevatorsCount = 3;
        public List<Elevator> Elevators { get; set; } = new List<Elevator>();
        public readonly int floorsCount = 13;

        public ElevatorSimulator()
        {
            //elevatorBl = new ElevatorBL(3, 10);

            Elevators.Add(new Elevator
            {
                Name = "E1",
                Floors = floorsCount,
                CurrentFloor = new Random().Next(1, 13),
                DestinationFloor = new Random().Next(1, 13)
            });
            Elevators.Last().Direction = Elevators.Last().CurrentFloor < Elevators.Last().DestinationFloor ? EnumDirection.Up : EnumDirection.Down;
            Elevators.Add(new Elevator
            {
                Name = "E2",
                Floors = floorsCount,
                CurrentFloor = new Random().Next(1, 13),
                DestinationFloor = new Random().Next(1, 13)
            });
            Elevators.Last().Direction = Elevators.Last().CurrentFloor < Elevators.Last().DestinationFloor ? EnumDirection.Up : EnumDirection.Down;
            Elevators.Add(new Elevator
            {
                Name = "E3",
                Floors = floorsCount,
                CurrentFloor = new Random().Next(1, 13),
                DestinationFloor = new Random().Next(1, 13)
            });
            Elevators.Last().Direction = Elevators.Last().CurrentFloor < Elevators.Last().DestinationFloor ? EnumDirection.Up : EnumDirection.Down;
            elevatorBl = new ElevatorBL(Elevators);
        }

        internal void AddPause(string elevatorName)
        {
            elevatorBl.AddPause(elevatorName);
        }
        internal void RemovePause(string elevatorName)
        {
            elevatorBl.RemovePause(elevatorName);
        }

        internal string AddRequest(int floorNumber, EnumDirection direction)
        {
            return elevatorBl.GetClosestElevator(floorNumber, direction);
        }
        internal void PrintElevatorsStatus()
        {
            Elevators.ForEach(p => Console.WriteLine(p.Print()));
        }
    }
}
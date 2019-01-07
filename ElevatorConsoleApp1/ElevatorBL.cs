using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ElevatorConsoleApp1
{
    internal class ElevatorBL
    {
        private readonly int elevatorsCount;
        private readonly int floorsCount;
        private List<Elevator> list;

        internal List<Elevator> Elevators { get; set; }
        public ElevatorBL(int elevatorsCount, int floorsCount)
        {
            this.elevatorsCount = elevatorsCount;
            this.floorsCount = floorsCount;
            for (int i = 0; i < elevatorsCount; i++)
            {
                Elevators.Add(new Elevator
                {
                    Name = "E" + i,
                    Floors = floorsCount,
                    CurrentFloor = 0,
                    Direction = EnumDirection.Up,
                    DestinationFloor = floorsCount - 1
                });
            }
        }

        public ElevatorBL(List<Elevator> elevators)
        {
            this.elevatorsCount = elevators.Count;
            this.floorsCount = elevators.FirstOrDefault().Floors;
            Elevators = elevators;
        }

        internal string GetClosestElevator(int floorNumber, EnumDirection direction)
        {
            return Elevators.Where(p=>!p.IsBusy).Select(p => new
            {
                Elevator = p,
                Distance = p.GetDistance(floorNumber, direction)
            }).OrderBy(p => p.Distance).FirstOrDefault().Elevator.Name;
        }
        internal void AddPause(string elevatorName)
        {
            var elevator = Elevators.FirstOrDefault(p => p.Name.ToLowerInvariant() == elevatorName.ToLowerInvariant());
            if (null != elevator)
            {
                elevator.IsBusy = true;
            }
        }
        internal void RemovePause(string elevatorName)
        {
            var elevator = Elevators.FirstOrDefault(p => p.Name.ToLowerInvariant() == elevatorName.ToLowerInvariant());
            if (null != elevator)
            {
                elevator.IsBusy = false;
            }
        }
    }
}

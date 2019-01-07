using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ElevatorConsoleApp1
{
    internal static class ElevatorExtensions
    {
        public static int GetDistance(this Elevator elevator, int floor, EnumDirection direction)
        {
            var counter = 0;
            var ele = new Elevator
            {
                CurrentFloor = elevator.CurrentFloor,
                DestinationFloor = elevator.DestinationFloor,
                Direction = elevator.Direction,
                Floors = elevator.Floors,
                Name = elevator.Name
            };
            while (!((ele.CurrentFloor == floor && ele.Direction == direction) && (ele.CurrentFloor == floor || ele.DestinationFloor == -1)))
            {
                ele.Move();
                ele.ReDirection(floor, direction);
                counter++;
            }
            return counter;
        }
        public static int TargetDistance(this Elevator elevator, int floor)
        {
            return Math.Abs(elevator.DestinationFloor - floor);
        }
        public static int EndDistance(this Elevator elevator)
        {
            return Math.Abs(elevator.DestinationFloor - elevator.CurrentFloor);
        }
        public static string Print(this Elevator elevator)
        {
            return $"Name: {elevator.Name} Floors: {elevator.Floors} Direction: {(elevator.Direction == EnumDirection.Up ? "Up  " : "Down")} CurrentFloor: {EnumFloorName.Floor1.GetRawFloorName( elevator.CurrentFloor)} TargetFloor: {EnumFloorName.Floor1.GetRawFloorName(elevator.DestinationFloor)}  ";
        }
        public static void Move(this Elevator elevator)
        {
            if (elevator.Direction == EnumDirection.Up)
            {
                if (elevator.CurrentFloor == elevator.Floors)
                {
                    elevator.Direction = EnumDirection.Down;
                    elevator.CurrentFloor--;
                    elevator.DestinationFloor = -1;
                }
                else
                {
                    elevator.CurrentFloor++;
                }
            }
            else
            {
                if (elevator.CurrentFloor == 0)
                {
                    elevator.Direction = EnumDirection.Up;
                    elevator.CurrentFloor++;
                    elevator.DestinationFloor = -1;
                }
                else
                {
                    elevator.CurrentFloor--;
                }
            }
        }
        public static void ReDirection(this Elevator elevator, int floor, EnumDirection direction)
        {
            if (elevator.CurrentFloor == elevator.DestinationFloor)
            {
                elevator.Direction = elevator.CurrentFloor < floor ? EnumDirection.Up : EnumDirection.Down;
                elevator.Direction = elevator.CurrentFloor == floor ? direction : elevator.Direction;

                elevator.DestinationFloor = -1;
            }
        }

        public static string GetUserInputFloorName(this EnumFloorName enumFloorName, int floor)
        {
            return ((EnumFloorName)floor).ToString();
        }
        public static string GetRawFloorName(this EnumFloorName enumFloorName, int floor)
        {
            floor -= enumFloorName.AdditionalFloors();
            return ((EnumFloorName)floor).ToString();
        }
        public static int GetRawFloorNumer(this EnumFloorName enumFloorName, int floor)
        {
            return floor + enumFloorName.AdditionalFloors();
        }

        private static int AdditionalFloors(this EnumFloorName enumFloorName)
        {
            return Enum.GetNames(enumFloorName.GetType()).Length -
                Enum.GetNames(EnumFloorName.Floor1.GetType()).Select(p => (int)(Enum.Parse(EnumFloorName.Floor1.GetType(), p))).Max();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Labs_3_4.Models
{
    [Serializable]
    public class Item
    {
        public string Id { get;  set; }
        public string Street { get;  set; }
        public bool DividedBathroom { get;  set; }
        public string BuildingType { get;  set; }
        public short BuildYear { get;  set; }
        public int RoomCount { get;  set; }
        public double Square { get;  set; }
        public int Floor { get;  set; }

        public Item(string id, string street, bool dividedBath, string buildingType, short buildYear, int roomCount, double square, int floor)
        {
            Id = id;
            Street = street;
            DividedBathroom = dividedBath;
            BuildingType = buildingType;
            BuildYear = buildYear;
            RoomCount = roomCount;
            Square = square;
            Floor = floor;
        }

        public static Item BuildStart(string id, string street, int roomCount, int floor)
        {
            var result = new Item();
            result.Id = id;
            result.Street = street;
            result.RoomCount = roomCount;
            result.Floor = floor;

            return result;
        }

        public Item BuildFinish(bool dividedBath, string buildingType, short buildYear, double square)
        {
            DividedBathroom = dividedBath;
            BuildingType = buildingType;
            BuildYear = buildYear;
            Square = square;

            return this;
        }

        public Item()
        {

        }
    }
}
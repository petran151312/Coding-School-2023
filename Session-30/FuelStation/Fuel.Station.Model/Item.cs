﻿using FuelStation.Model.Enums;
using Microsoft.EntityFrameworkCore;

namespace Fuel.Station.Model
{
    [Index(nameof(Code), IsUnique = true)]

    public class Item
    {
        //Properties
        public int Id { get; set; }

        public string? Code { get; set; }

        public string? Description { get; set; }

        public ItemType itemType { get; set; }

        public decimal Price { get; set; }

        public decimal Cost { get; set; }

        //Constructors
        public Item()
        {

        }


        public Item(string? code, string? description, ItemType itemtype)
        {
            Code = code;
            Description = description;
            itemType = itemtype;
        }

        //Relations
        public List<TransactionLine> TransactionLines { get; set; }



    }
}

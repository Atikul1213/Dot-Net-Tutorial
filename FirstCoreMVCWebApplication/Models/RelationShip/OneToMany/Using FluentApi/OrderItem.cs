﻿namespace FirstCoreMVCWebApplication.Models.RelationShip.OneToMany.Using_FluentApi
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int OrderId { get; set; } // FK, Required Relationship
        public Order Order { get; set; } // Navigation property
    }
}

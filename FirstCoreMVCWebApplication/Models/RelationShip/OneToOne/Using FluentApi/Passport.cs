﻿namespace FirstCoreMVCWebApplication.Models.RelationShip.OneToOne.Using_FluentApi
{
    public class Passport
    {
        public int Id { get; set; } //PK
        public string PassportNumber { get; set; }
        public int UserId { get; set; } //FK, Required Relationship
        public User User { get; set; }  // Navigation property
    }
}

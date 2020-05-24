using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ChoreDataModel.Interfaces;

namespace ChoreDataModel.Model
{
    [Table("Chore")]
    public class Chore : IChoreEntity
    {
        [Key]
        public int ChoreID { get; set; }
        public int? AssignedPartnerId { get; set; }
        public string ChoreName { get; set; }
        public bool? Completed { get; set; }
        public bool? Assigned { get; set; }
    }
}

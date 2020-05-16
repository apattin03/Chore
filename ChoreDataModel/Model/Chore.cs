using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChoreDataModel.Model
{
    public class Chore
    {
        [Key]
        public int ChoreID { get; set; }
        public int AssignedPartnerId { get; set; }
        public string ChoreName { get; set; }
        public bool Completed { get; set; }
        public bool Assigned { get; set; }
    }
}

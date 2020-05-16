using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Transactions;
using ChoreDataModel.Interfaces;

namespace ChoreDataModel.Model
{
    [Table("ChoreSprint")]
    public class ChoreSprint : IChoreEntity
    {
        [Key]
        public int ChoreSprintId { get; set; }
        public List<Chore> Chores { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}

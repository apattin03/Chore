using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Transactions;

namespace ChoreDataModel.Model
{
    public class ChoreSprint
    {
        [Key]
        public int ChoreSprintId { get; set; }
        public List<Chore> Chores { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}

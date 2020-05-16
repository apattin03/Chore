using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using System.Transactions;

namespace ChoreDataModel.Model
{
    public class Partner
    {
        [Key]
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public List<Chore> Chores { get; set; }
        public int CompletedChores { get; set; }
        public int IncompleteChores { get; set; }

    }
}

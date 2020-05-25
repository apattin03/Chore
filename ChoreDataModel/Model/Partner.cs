using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChoreDataModel.Interfaces;

namespace ChoreDataModel.Model
{
    [Table(("Partner"))]
    public class Partner: IChoreEntity
    {
        [Key]
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public List<Chore> Chores { get; set; }
        public int CompletedChores { get; set; }
        public int IncompleteChores { get; set; }

    }
}

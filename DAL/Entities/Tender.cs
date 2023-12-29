using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Entities.Enum;

namespace DAL.Entities
{
    public class Tender
    {
        [Key]
        public int IdTender { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User Client { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public TenderStatus Status { get; set; }
        public List<Proposal> Proposals { get; set; }
    }
}
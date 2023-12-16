using System;
using DAL.Entities.Enum;

namespace DAL.Entities
{
    public class Tender
    {
        public int IdTender { get; set; }
        public User Client { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public TenderStatus TenderStatus { get; set; }
        public List<Proposal> Proposals { get; set; }
    }
}
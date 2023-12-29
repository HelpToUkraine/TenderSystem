using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Entities.Enum;

namespace DAL.Entities
{
    public class Proposal
    {
        [Key]
        public int IdProposal { get; set; }
        [ForeignKey("Tender")]
        public int? TenderId { get; set; }
        public Tender Tender { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User Submitter { get; set; }
        public double Price { get; set; }
        public DateTime SubmissionDate { get; set; }
        public ProposalStatus Status { get; set; }
    }
}
using System;
using DAL.Entities.Enum;

namespace DAL.Entities
{
    public class Proposal
    {
        public int IdProposal { get; set; }
        public Tender Tender { get; set; }
        public User Submitter { get; set; }
        public double Price { get; set; }
        public DateTime SubmissionDate { get; set; }
        public ProposalStatus ProposalStatus { get; set; }
    }
}
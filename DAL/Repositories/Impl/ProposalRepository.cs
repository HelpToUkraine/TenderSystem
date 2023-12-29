using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Impl;

public class ProposalRepository : BaseRepository<Proposal>, IProposalRepository
{
    public ProposalRepository(TenderContext context)
        : base(context)
    {
    }
}


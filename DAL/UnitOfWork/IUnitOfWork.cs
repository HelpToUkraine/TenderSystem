using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    ITenderRepository Tenders { get; }
    IProposalRepository Proposals { get; }
    void Save();
}
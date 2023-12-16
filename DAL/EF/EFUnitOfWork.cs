using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public class EFUnitOfWork : IUnitOfWork
{
    private TenderContext db;
    private TenderRepository tenderRepository;
    private ProposalRepository proposalRepository;
    public EFUnitOfWork(DbContextOptions options)
    {
        db = new TenderContext(options);
    }
    public ITenderRepository Tenders
    {
        get
        {
            if (tenderRepository == null)
                tenderRepository = new TenderRepository(db);
            return tenderRepository;
        }
    }

    public IProposalRepository Proposals
    {
        get
        {
            if (proposalRepository == null)
                proposalRepository = new ProposalRepository(db);
            return proposalRepository;
        }
    }
    public void Save()
    {
        db.SaveChanges();
    }

    private bool disposed = false;

    public virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                db.Dispose();
            }
            this.disposed = true;
        }
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

}
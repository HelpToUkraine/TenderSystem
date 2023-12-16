using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;

public class TenderRepository
    : BaseRepository<Tender>, ITenderRepository
{
    internal TenderRepository(TenderContext context)
        : base(context)
    {
    }
}
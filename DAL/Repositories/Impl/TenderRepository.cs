using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Impl;

public class TenderRepository
    : BaseRepository<Tender>, ITenderRepository
{
    internal TenderRepository(TenderContext context)
        : base(context)
    {
    }
}
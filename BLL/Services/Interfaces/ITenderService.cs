using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface ITenderService
    {
        IEnumerable<TenderDTO> GetTenders();
    }
}
using DAL.Entities.Enum;

namespace BLL.DTO;
// OSBB DTO
public class TenderDTO
{
    public int IdTender { get; set; }
    public int UserId { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public TenderStatus Status { get; set; }

    public IEnumerable<ProposalDTO> Propossals { get; set; }
}
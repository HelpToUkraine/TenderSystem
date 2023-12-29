using DAL.Entities.Enum;

namespace BLL.DTO;
// Street DTO
public class ProposalDTO
{
    public int IdProposal { get; set; }
    public int TenderId { get; set; }
    public int UserId { get; set; }
    public double Price { get; set; }
    public DateTime SubmissionDate { get; set; }
    public ProposalStatus Status { get; set; }
}
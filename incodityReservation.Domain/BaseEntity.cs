
namespace incodityReservation.Domain;

public class BaseEntity : Entity, IDateEntity
{
    public DateTime CreatedAt { get; set; } // 1402/11/01 //required
    public DateTime? UpdatedAt { get; set; } // optional , can be null
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
}

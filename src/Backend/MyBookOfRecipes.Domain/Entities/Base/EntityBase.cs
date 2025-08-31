using MyBookOfRecipes.Domain.Enums;

namespace MyBookOfRecipes.Domain.Entities.Base
{
    public class EntityBase
    {
        public Guid Id { get; set;} = Guid.NewGuid();
        public DateTime CreatedAt { get; set;} = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set;}  
        public StatusEntityEnum Status { get; set;} = StatusEntityEnum.Enabled;
    }
}

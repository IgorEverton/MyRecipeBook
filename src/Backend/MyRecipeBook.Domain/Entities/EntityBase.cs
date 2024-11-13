namespace MyRecipeBook.Domain.Entities
{
    public class EntityBase
    {
        long Id { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}

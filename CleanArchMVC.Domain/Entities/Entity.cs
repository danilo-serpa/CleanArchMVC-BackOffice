namespace CleanArchMVC.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public DateTime Created { get; protected set; }
        public DateTime? Updated { get; protected set; }
    }
}
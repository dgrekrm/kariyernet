namespace KariyerApp.Core.Interfaces
{
    public interface IDeletableEntity : IUpdateableEntity
    {
        bool IsDeleted { get; set; }
    }

}

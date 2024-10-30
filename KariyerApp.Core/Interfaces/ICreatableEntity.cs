namespace KariyerApp.Core.Interfaces
{
    public interface ICreatableEntity
    {
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
    }

}

namespace KariyerApp.Core.Interfaces
{
    public interface IUpdateableEntity
    {
        DateTime? UpdatedDate { get; set; }
        string? UpdatedBy { get; set; }
    }

}

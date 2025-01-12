namespace ProjectNet.Data.Interfaces
{
    public interface IDateTracking
    {
      public  DateTime CreatedDate { get; set; }
      public  DateTime? LastModifiedDate { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http.HttpResults;
using ProjectNet.Data.Interfaces;

namespace ProjectNet.Data.Entities
{
    public class Course: IDateTracking
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int JoinNumber { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public  decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
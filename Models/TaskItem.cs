using Dapper.Contrib.Extensions;
using TaskFlow.Models;

namespace TaskFlow

{
    [Table("Tasks")]
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.Pending;
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Write(false)] //Não permite que o Dapper faça o mapeamento da propriedade Category
        public Category? Category { get; set; } //Permite que o Dapper faça o mapeamento da propriedade Category
    
    }
}
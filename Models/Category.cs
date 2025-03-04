using Dapper.Contrib.Extensions;

namespace TaskFlow.Models
{
    [Table("Categories")]
    public class Category
    {

        public Category()
          =>  Tasks = new List<TaskItem>();

        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        [Write(false)] 
        public List<TaskItem> Tasks { get; set; }  
    }
}

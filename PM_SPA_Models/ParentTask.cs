using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PM_SPA_Models
{
    [Table("ParentTask")]
    public class ParentTask
    {      
        [Key]
        [JsonProperty(PropertyName = "TaskId")]
        public int ParentId { get; set; }
        [Required]
        [MaxLength(100)]
        [JsonProperty(PropertyName = "TaskName")]
        public string Parent_Task { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}

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
        [JsonProperty(PropertyName = "ParentTaskId")]
        public int ParentTaskId { get; set; }
        [Required]
        [MaxLength(100)]
        [JsonProperty(PropertyName = "Parent_Task")]
        public string Parent_Task { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}

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
    public class Task
    {
        [Key]
        [JsonProperty(PropertyName = "TaskId")]
        public int Task_ID { get; set; }
        [JsonProperty(PropertyName = "ParentId")]
        public int? Parent_ID { get; set; }
        [JsonProperty(PropertyName = "ProjectId")]
        public int Project_ID { get; set; }
        [Column("TaskName")]
        [MaxLength(100)]
        [JsonProperty(PropertyName = "TaskName")]
        public string TaskName { get; set; }      
        
        [JsonProperty(PropertyName = "TaskUserId")]
        public int User_ID { get; set; }
        [NotMapped]
        [JsonProperty(PropertyName = "isParentTask")]
        public bool IsParent { get; set; }
        [Column(TypeName = "Date")]
        [JsonProperty(PropertyName = "ProjectStartDate")]
        public DateTime? ProjectStartDate { get; set; }
        [Column(TypeName = "Date")]
        [JsonProperty(PropertyName = "ProjectEndDate")]
        public DateTime? ProjectEndDate { get; set; }
        [JsonProperty(PropertyName = "Priority")]
        public int Priority { get; set; }
        [JsonProperty(PropertyName = "Parent")]
        [ForeignKey("ParentTaskId")]
        public ParentTask Parent { get; set; }
        public Project Project { get; set; }
    }
}

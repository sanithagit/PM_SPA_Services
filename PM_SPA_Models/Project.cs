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
    [Table("Project")]
    public class Project
    {

        [Key]
        [JsonProperty("ProjectId")]
        public int ProjectId { get; set; }
        [Required]
        [JsonProperty("ProjectName")]
        [MaxLength(100)]
        public string ProjectName { get; set; }
        [JsonProperty("ProjectStartDate")]
        [Column(TypeName = "Date")]
        public DateTime? ProjectStartDate { get; set; }
        [JsonProperty("ProjectEndDate")]
        [Column(TypeName = "Date")]
        public DateTime? ProjectEndDate { get; set; }
        [JsonProperty("ProjectPriority")]
        public int Priority { get; set; }       
        [JsonProperty("ProjectUserId")]
        public int User_ID { get; set; }
        [NotMapped]
        [JsonProperty("ProjectTotalTasks")]
        public int projectTotalTasks { get; set; }
        [NotMapped]
        [JsonProperty("ProjectTasksCompleted")]
        public int projectTasksCompleted { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<User> Users { get; set; }
    }
}

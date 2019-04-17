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
    [Table("User")]
    public class User
    {
        [Key]
        [JsonProperty("UserId")]
        public int User_ID { get; set; }
        [Required]
        [MaxLength(100)]
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        [JsonProperty("LastName")]
        public string LastName { get; set; }
        [Required]
        [JsonProperty("EmployeeId")]
        public int Employee_ID { get; set; }       
    }
}

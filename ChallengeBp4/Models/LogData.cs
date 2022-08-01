using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeBp4.Models
{
    public class LogData
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string Action { get; set; }
        public string StackTrace { get; set; }
    }
}

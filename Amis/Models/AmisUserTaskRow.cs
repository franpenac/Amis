using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis.Models
{
    public class AmisUserTaskRow
    {
        public int AmisUserTaskId { get; set; }
        public int AmisTaskTypeId { get; set; }
        public string AmisTaskTypeImage { get; set; }
        public int AmisTaskId { get; set; }
        public string AmisTaskName { get; set; }
        public String AmisUserTaskDescription { get; set; }
        public string AmisUserTaskActionTaken { get; set; }
        public string AmisUserTaskDone { get; set; }
        public DateTime AmisUserTaskStartDate { get; set; }
        public DateTime? AmisUserTaskFinishDate { get; set; }
    }
}
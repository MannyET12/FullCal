using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace FullCal.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Process Name")]
        public string? ProcName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Calibration { get; set; }
        public string CalibrationStatus { get; set; }
        public string Responsible { get; set; }
        [DisplayName("Start Date")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Close Date")]
        public DateTime ClosingDate { get; set; }
        public string CurrentStatus { get; set; }

        //Relational data
        public virtual Process Process { get; set; }
        public virtual ApplicationUser User { get; set; }

        public Event(IFormCollection form, Process process, ApplicationUser user)
        {
            //Id = int.Parse(form["Id"]);
            User = user;
            Name = form["Event.Name"].ToString();
            Description = form["Event.Description"].ToString();
            ProcName = form["Event.ProcName"].ToString();
            Location = form["Event.Location"].ToString();
            Calibration = form["Event.Calibration"].ToString();
            CalibrationStatus = form["Event.CalibrationStatus"].ToString();
            Responsible = form["Event.Responsible"].ToString();

            CreatedDate = DateTime.Parse(form["Event.CreatedDate"].ToString());
            ClosingDate = DateTime.Parse(form["Event.ClosingDate"].ToString());
            CurrentStatus = form["Event.CurrentStatus"].ToString();
            Process = process;
        
        }

        public void UpdateEvent(IFormCollection form, Process process, ApplicationUser user)
        {
            //Id = int.Parse(form["Event.Id"]);
            User = user;
            Name = form["Event.Name"];
            Description = form["Event.Description"];
            ProcName = form["Event.ProcName"];
            Location = form["Event.Location"];
            Calibration = form["Event.Calibration"];
            CalibrationStatus = form["Event.CalibrationStatus"];
            Responsible = form["Event.Responsible"];
            CreatedDate = DateTime.Parse(form["Event.CreatedDate"]);
            ClosingDate = DateTime.Parse(form["Event.ClosingDate"]);
            CurrentStatus = form["Event.CurrentStatus"];
            Process = process;

        }

        public Event()
        {

        }
    }
}

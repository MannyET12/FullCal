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
        public string ProcessName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Calibration { get; set; }
        public string CalibrationStatus { get; set; }
        public string Responsible { get; set; }
        [DisplayName("Start Date")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Close Date")]
        public DateTime ClosingDate { get; set; }
        [Range(1, 31, ErrorMessage = "Please enter a value between 1 and 31")]
        //public int Days { get; set; }
        //public int Month { get; set; }
        //public int Year { get; set; }
        //public Status StatusID { get; set; }
        //[Display(Name = "Status")]
        public string CurrentStatus { get; set; }

        //public enum Status
        //{
        //    OK,
        //    Imminent,
        //    Overdue
        //}

        //Relational data
        public virtual Process Process { get; set; }

        public Event(IFormCollection form, Process process)
        {
            Id = int.Parse(form["Id"]);
            Name = form["Name"];
            Description = form["Description"];
            ProcessName = form["ProcessName"];
            Location = form["Location"];
            Calibration = form["Calibration"];
            CalibrationStatus = form["CalibrationStatus"];
            Responsible = form["Responsible"];
            CreatedDate = DateTime.Parse(form["CreatedDate"]);
            ClosingDate = DateTime.Parse(form["ClosingDate"]);
            CurrentStatus = form["CurrentStatus"];
            Process = process;
        }

        public void UpdateEvent(IFormCollection form, Process process)
        {
            Id = int.Parse(form["Id"]);
            Name = form["Name"];
            Description = form["Description"];
            ProcessName = form["ProcessName"];
            Location = form["Location"];
            Calibration = form["Calibration"];
            CalibrationStatus = form["CalibrationStatus"];
            Responsible = form["Responsible"];
            CreatedDate = DateTime.Parse(form["CreatedDate"]);
            ClosingDate = DateTime.Parse(form["ClosingDate"]);
            CurrentStatus = form["CurrentStatus"];
            Process = process;
        }

        public Event()
        {

        }
    }
}

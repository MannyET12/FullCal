using Microsoft.AspNetCore.Mvc.Rendering;


namespace FullCal.Models.ViewModels
{
    public class EventViewModel
    {
        public Event Event { get; set; }
        public List<SelectListItem> Process = new List<SelectListItem>();
        public string ProcessName { get; set; }
        public string Userid { get; set; }

        public EventViewModel(Event myEvent, List<Process> processes, string userid)
        {
            Event = myEvent;
            ProcessName = myEvent.Process.Name;
            Userid = userid;
            foreach (var proc in processes)
            {
                Process.Add(new SelectListItem() { Text = proc.Name });
            }
        }

        public EventViewModel(List<Process> processes, string userid)
        {
            Userid = userid;
            foreach (var proc in processes)
            {
                Process.Add(new SelectListItem() { Text = proc.Name });
            }
        }

        public EventViewModel()
        {

        }
    }
}

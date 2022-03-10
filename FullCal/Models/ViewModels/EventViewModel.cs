using Microsoft.AspNetCore.Mvc.Rendering;


namespace FullCal.Models.ViewModels
{
    public class EventViewModel
    {
        public Event Event { get; set; }
        public List<SelectListItem> Process = new List<SelectListItem>();
        public string ProcessName { get; set; }

        public EventViewModel(Event myEvent, List<Process> processes)
        {
            Event = myEvent;
            ProcessName = myEvent.Process.Name;
            foreach (var proc in processes)
            {
                Process.Add(new SelectListItem() { Text = proc.Name });
            }
        }

        public EventViewModel(List<Process> processes)
        {
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

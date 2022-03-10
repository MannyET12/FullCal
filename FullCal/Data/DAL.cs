using FullCal.Data;
using FullCal.Models;

namespace FullCal.Data
{
    public interface IDAL
    {
        public List<Event> GetEvents();
        public List<Event> GetMyEvents(string userid);
        public Event GetEvent(int id);
        public void CreateEvent(IFormCollection form);
        public void UpdateEvent(IFormCollection form);
        public void DeleteEvent(int id);
        public List<Process> GetProcesses();
        public Process GetProcess(int id);
        public void CreateProcess(Process process);
    }

    public class DAL : IDAL
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<Event> GetEvents()
        {
            return db.Events.ToList();
        }
        public List<Event> GetMyEvents(string userid)
        {
            return db.Events.Where(m => m.User.Id == userid).ToList();
        }
        public Event GetEvent(int id)
        {
            return db.Events.FirstOrDefault(m => m.Id == id);
        }
        public void CreateEvent(IFormCollection form)
        {
            var procname = form["Process"].ToString();
            var newevent = new Event(form, db.Processes.FirstOrDefault(m => m.Name == procname));
            db.Events.Add(newevent);
            db.SaveChanges();
        }
        public void UpdateEvent(IFormCollection form)
        {
            var procname = form["Process"].ToString();
            var eventid = int.Parse(form["Event.Id"]);
            var myevent = db.Events.FirstOrDefault(m => m.Id == eventid);
            var process = db.Processes.FirstOrDefault(m => m.Name == procname);
            myevent.UpdateEvent(form, process);
            db.Entry<Event>(myevent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteEvent(int id)
        {
            var myevent = db.Events.Find(id);
            db.Events.Remove(myevent);
            db.SaveChanges();
        }
        public List<Process> GetProcesses()
        {
            return db.Processes.ToList();
        }
        public Process GetProcess(int id)
        {
            return db.Processes.Find(id);
        }
        public void CreateProcess(Process process)
        {
            db.Processes.Add(process);
            db.SaveChanges();
        }
    }
}

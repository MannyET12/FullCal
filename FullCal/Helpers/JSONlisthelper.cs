namespace FullCal.Helpers
{
    public class JSONListhelper
    {
        public static string GetEventListJSONString(List<Models.Event> events)
        {
            var evenlist = new List<CalendarEvent>();
            foreach (var model in events)
            {
                var myevent = new CalendarEvent()
                {
                    id = model.Id,
                    start = model.CreatedDate,
                    end = model.ClosingDate,
                    resourceId = model.Process.Id,
                    description = model.Description,
                    title = model.Name
                };
                evenlist.Add(myevent);
            }
            return System.Text.Json.JsonSerializer.Serialize(evenlist);
        }
        public static string GetResourceListJSONString(List<Models.Process> processes)
        {
            var resourcelist = new List<Resource>();
            foreach (var proc in processes)
            {
                var resource = new Resource()
                {
                    id = proc.Id,
                    title = proc.Name
                };
                resourcelist.Add(resource);
            }
            return System.Text.Json.JsonSerializer.Serialize(resourcelist);
        }
    }

    public class CalendarEvent
    {
        public int id { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int resourceId { get; set; }
        public string description { get; set; }
        public string report { get; set; }
        public string title { get; set; }
    }

    public class Resource
    {
        public int id { get; set; }
        public string title { get; set; }
    }

}

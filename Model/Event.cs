namespace CodeFirstApi.Model
{
    public class Event
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public int NoOfGuests { get; set; }

        public DateTime Data {  get; set; }

        public int EventTypeId { get; set; }

        public virtual EventType EventType { get; set; }
    }
}

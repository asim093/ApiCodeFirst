namespace CodeFirstApi.Model
{
    public class EventDTO
    {
        public int? Id { get; set; }

        public string CustomerName { get; set; }

        public int NoOfGuests { get; set; }

        public DateTime Data { get; set; }

        public int EventTypeId { get; set; }

    }
}

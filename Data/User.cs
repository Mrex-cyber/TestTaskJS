namespace TestTaskJS.Data
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int EventsCount { get => UserEvents.Count; }
        public List<Event> UserEvents { get; set; } = new();
        public string NextEventDate { get; set; } = "";
    }
}

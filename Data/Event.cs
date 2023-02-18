﻿using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaskJS.Data
{
    public class Event
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public int? UserOfEventId { get; set; }
        public User? UserOfEvent { get; set; }
    }
}
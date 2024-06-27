using System;
using System.Collections.Generic;

#nullable disable

namespace OnewsApi
{
    public partial class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public string Adress { get; set; }
        public DateTime? Date { get; set; }
        public string Result { get; set; }
    }
}

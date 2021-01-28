using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerRequestTracking.Functions.Model
{
    public class RequestForm
    {
        public Guid Id { get; set; } =  Guid.NewGuid();
        public DateTime CreatedDate { get; set; }
        public string LandingPage { get; set; }
        public string NameSurname { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
    }
}

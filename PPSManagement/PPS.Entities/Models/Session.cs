using System;
using System.Collections.Generic;
using System.Text;

namespace PPS.Entities
{
    public class Session
    {
        public int SessionId { get; set; }
        public string SessionCode { get; set; }
        public string AppKey{get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}

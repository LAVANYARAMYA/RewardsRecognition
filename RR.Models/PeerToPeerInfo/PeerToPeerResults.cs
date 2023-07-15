using RR.Models.EmployeeInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR.Models.PeerToPeerInfo
{
    public class PeerToPeerResults
    {
        public int Id { get; set; }

        public string? NomineeId { get; set; }
        public string? NominatorId { get; set; }

        public string? Citation { get; set; }

        public Employee? Employee { get; set; }
    }
}

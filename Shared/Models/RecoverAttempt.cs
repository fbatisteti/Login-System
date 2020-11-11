using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Shared.Models
{
    public class RecoverAttempt
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int LuckyNumber { get; set; }
    }
}

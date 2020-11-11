using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Shared.Services
{
    public class PersistentData
    {
        // For "Authentication"
        public string Name { get; set; }
        public int Role { get; set; }
        public bool Logged { get; set; }

        // For keeping the field content during register
        public string Email { get; set; }
    }
}

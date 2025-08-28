using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuraCoreMediFlow.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Admin, Doctor, Nurse, etc.
        public string? Description { get; set; }
    }
}


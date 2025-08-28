using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuraCoreMediFlow.Domain.Entities
{
    public class HospitalAccount
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string HospitalName { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty; // unique code or subdomain
        public string? DatabaseName { get; set; }                // optional DB name
        public string? DatabaseConnectionString { get; set; }    // optional encrypted connection string
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}


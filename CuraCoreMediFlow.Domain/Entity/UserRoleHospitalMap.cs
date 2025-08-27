using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuraCoreMediFlow.Domain.Entity
{
    public class UserRoleHospitalMap
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid RoleId { get; set; }
        public Role? Role { get; set; }

        public Guid HospitalAccountId { get; set; }
        public HospitalAccount? HospitalAccount { get; set; }

        public DateTime AssignedAt { get; set; } = DateTime.Now;
    }
}

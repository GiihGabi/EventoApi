using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.GeralContext
{
    public class Comprador : User
    {
        public List<Eventos>? Eventos { get; set; }
    }
}

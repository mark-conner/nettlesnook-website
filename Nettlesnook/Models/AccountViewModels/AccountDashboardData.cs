using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nettlesnook.Models.AccountViewModels
{
    public class AccountDashboardData
    {
        public IEnumerable<Messages> Messages { get; set; }
        public IEnumerable<Blog> Blog { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BOMContext
{
    public partial class bomContext : templatedevContext
    {
        protected readonly IConfiguration Configuration;

        public bomContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

    }
}

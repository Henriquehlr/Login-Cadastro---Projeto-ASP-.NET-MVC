using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fabrica.Mascaras.Web.Identity
{
    public class MascaraIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public MascaraIdentityDbContext()
            : base("MascaraDbContext")
        {
            
        }
        
    }
}
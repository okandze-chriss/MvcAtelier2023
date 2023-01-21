using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MvcGLAtelelier2023.Models
{
    public class bdAtelier2023Context:DbContext
    {
        public bdAtelier2023Context() : base("connAtelier")
        {

        }

        public DbSet<Personne> personnes { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Gerant> gerants { get; set; }

        public System.Data.Entity.DbSet<MvcGLAtelelier2023.Models.ClientViewModel> ClientViewModels { get; set; }

        public System.Data.Entity.DbSet<MvcGLAtelelier2023.Models.GerantVeiwModel> GerantVeiwModels { get; set; }
    }
}
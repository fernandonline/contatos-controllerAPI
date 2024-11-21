using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dotnet8__minimal_false__API.Entitys;

namespace Dotnet8__minimal_false__API.Context
{
    public class AgendaContext(DbContextOptions<AgendaContext> options) : DbContext(options)
    {
        public DbSet<Contato> Contatos { get; set; }
    }
}
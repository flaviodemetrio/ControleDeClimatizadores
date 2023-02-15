using Microsoft.EntityFrameworkCore;

namespace EstoqueWeb.Models
{
    public class EstoqueWebContext :DbContext 
    {
        public DbSet<ClienteModel> Clientes{get;set;}
        public DbSet<EquipamentoModel> Equipamentos{get;set;}

        public EstoqueWebContext(DbContextOptions<EstoqueWebContext> options): base(options)
        {
            
        }        
    }    
}
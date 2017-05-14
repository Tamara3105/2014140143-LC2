using _2014140143_ENT.Entities;
using _2014140143_PER.EntityTypeConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_PER
{
    class _2014140143DbContext : DbContext
    {
        public DbSet<AdministradorEquipo> AdministradorEquipos { get; set; }
        public DbSet<AdministradorLinea> AdministrarLineas { get; set; }
        public DbSet<CentroAtencion> CentroAtencions { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Direccion> Direccions { get; set; }
        public DbSet<Distrito> Distritos { get; set; }
        public DbSet<EquipoCelular> EquipoCelulars { get; set; }
        public DbSet<EstadoEvaluacion> EstadoEvaluacions { get; set; }
        public DbSet<Evaluacion> Evaluacions { get; set; }
        public DbSet<LineaTelefonica> LineaTelefonicas { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<TipoEvaluacion> TipoEvaluacions { get; set; }
        public DbSet<TipoLinea> TipoLineas { get; set; }
        public DbSet<TipoPago> TipoPagos { get; set; }
        public DbSet<TipoTrabajador> TipoTrabajadors { get; set; }
        public DbSet<Trabajador> Trabajadors { get; set; }
        public DbSet<Ubigeo> Ubigeos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<TipoPlan> TipoPlans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdministradorEquipoConfigurations());
            modelBuilder.Configurations.Add(new AdministradorLineaConfigurations());
            modelBuilder.Configurations.Add(new CentroAtencionConfigurations());
            modelBuilder.Configurations.Add(new ClienteConfigurations());
            modelBuilder.Configurations.Add(new ContratoConfigurations());
            modelBuilder.Configurations.Add(new DepartamentoConfigurations());
            modelBuilder.Configurations.Add(new DireccionConfigurations());
            modelBuilder.Configurations.Add(new DistritoConfigurations());
            modelBuilder.Configurations.Add(new EquipoCelularConfigurations());
            modelBuilder.Configurations.Add(new EstadoEvaluacionConfigurations());
            modelBuilder.Configurations.Add(new EvaluacionConfigurations());
            modelBuilder.Configurations.Add(new LineaTelefonicaConfigurations());
            modelBuilder.Configurations.Add(new PlanConfigurations());
            modelBuilder.Configurations.Add(new ProvinciaConfigurations());
            modelBuilder.Configurations.Add(new TipoEvaluacionConfigurations());
            modelBuilder.Configurations.Add(new TipoLineaConfigurations());
            modelBuilder.Configurations.Add(new TipoPagoConfigurations());
            modelBuilder.Configurations.Add(new TipoTrabajadorConfigurations());
            modelBuilder.Configurations.Add(new TrabajadorConfigurations());
            modelBuilder.Configurations.Add(new UbigeoConfigurations());
            modelBuilder.Configurations.Add(new VentaConfigurations());
            modelBuilder.Configurations.Add(new TipoPlanConfigurations());


            base.OnModelCreating(modelBuilder);



        }
    }
}

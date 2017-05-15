namespace _2014140143_PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdministradorEquipo",
                c => new
                    {
                        AdministradorEquipoId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.AdministradorEquipoId);
            
            CreateTable(
                "dbo.EquipoCelular",
                c => new
                    {
                        EquipoCelularId = c.Int(nullable: false, identity: true),
                        CodigoCelular = c.Int(nullable: false),
                        Marca = c.String(),
                        Modelo = c.String(),
                        Imei = c.String(),
                        Color = c.String(),
                        Precio = c.Double(nullable: false),
                        Stock = c.Int(nullable: false),
                        AdministradorEquipo_AdministradorEquipoId = c.Int(),
                    })
                .PrimaryKey(t => t.EquipoCelularId)
                .ForeignKey("dbo.AdministradorEquipo", t => t.AdministradorEquipo_AdministradorEquipoId)
                .Index(t => t.AdministradorEquipo_AdministradorEquipoId);
            
            CreateTable(
                "dbo.AdministrarLinea",
                c => new
                    {
                        AdministradorLineaId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.AdministradorLineaId);
            
            CreateTable(
                "dbo.LineaTelefonica",
                c => new
                    {
                        LineaTelefonicaId = c.Int(nullable: false, identity: true),
                        NumeroTelefonico = c.String(),
                        IcciaTelefonico = c.String(),
                        TipoLinea_TipoLineaId = c.Int(),
                        AdministradorLinea_AdministradorLineaId = c.Int(),
                        Evaluacion_EvaluacionId = c.Int(),
                    })
                .PrimaryKey(t => t.LineaTelefonicaId)
                .ForeignKey("dbo.TipoLinea", t => t.TipoLinea_TipoLineaId)
                .ForeignKey("dbo.AdministrarLinea", t => t.AdministradorLinea_AdministradorLineaId)
                .ForeignKey("dbo.Evaluacion", t => t.Evaluacion_EvaluacionId)
                .Index(t => t.TipoLinea_TipoLineaId)
                .Index(t => t.AdministradorLinea_AdministradorLineaId)
                .Index(t => t.Evaluacion_EvaluacionId);
            
            CreateTable(
                "dbo.TipoLinea",
                c => new
                    {
                        TipoLineaId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoLineaId);
            
            CreateTable(
                "dbo.CentroAtencion",
                c => new
                    {
                        CentroAtencionId = c.Int(nullable: false, identity: true),
                        CodigoCentroAtencion = c.Int(nullable: false),
                        NombreCentroAtencion = c.String(),
                        CodDireccion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CentroAtencionId);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        CodigoCliente = c.Int(nullable: false),
                        NombreCliente = c.String(),
                        ApePaternoCliente = c.String(),
                        ApeMaternoCliente = c.String(),
                        DNICliente = c.String(),
                        FecNacimientoCliente = c.String(),
                        SueldoCliente = c.Double(nullable: false),
                        CorreoCliente = c.String(),
                        DireccionCliente = c.String(),
                        Evaluacion_EvaluacionId = c.Int(),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.Evaluacion", t => t.Evaluacion_EvaluacionId)
                .Index(t => t.Evaluacion_EvaluacionId);
            
            CreateTable(
                "dbo.Contrato",
                c => new
                    {
                        ContratoId = c.Int(nullable: false, identity: true),
                        NumeroContrato = c.Int(nullable: false),
                        Plazo = c.String(),
                        FormaContrato = c.String(),
                    })
                .PrimaryKey(t => t.ContratoId);
            
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        DepartamentoId = c.Int(nullable: false, identity: true),
                        CodigoDepartamento = c.Int(nullable: false),
                        NombreDepartamento = c.String(),
                        Ubigeo_UbigeoId = c.Int(),
                        CodProvincia_ProvinciaId = c.Int(),
                    })
                .PrimaryKey(t => t.DepartamentoId)
                .ForeignKey("dbo.Ubigeo", t => t.Ubigeo_UbigeoId)
                .ForeignKey("dbo.Provincia", t => t.CodProvincia_ProvinciaId)
                .Index(t => t.Ubigeo_UbigeoId)
                .Index(t => t.CodProvincia_ProvinciaId);
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        ProvinciaId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ProvinciaId);
            
            CreateTable(
                "dbo.Ubigeo",
                c => new
                    {
                        UbigeoId = c.Int(nullable: false, identity: true),
                        CodigoUbigeo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UbigeoId);
            
            CreateTable(
                "dbo.Distrito",
                c => new
                    {
                        DistritoId = c.Int(nullable: false, identity: true),
                        CodigoDistrito = c.Int(nullable: false),
                        NombreDistrito = c.String(),
                        Ubigeo_UbigeoId = c.Int(),
                    })
                .PrimaryKey(t => t.DistritoId)
                .ForeignKey("dbo.Ubigeo", t => t.Ubigeo_UbigeoId)
                .Index(t => t.Ubigeo_UbigeoId);
            
            CreateTable(
                "dbo.Direccion",
                c => new
                    {
                        DireccionId = c.Int(nullable: false, identity: true),
                        CodigoDireccion = c.Int(nullable: false),
                        NombreDireccion = c.String(),
                        CodigoUbigeo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DireccionId);
            
            CreateTable(
                "dbo.EstadoEvaluacion",
                c => new
                    {
                        EstadoEvaluacionId = c.Int(nullable: false, identity: true),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.EstadoEvaluacionId);
            
            CreateTable(
                "dbo.Evaluacion",
                c => new
                    {
                        EvaluacionId = c.Int(nullable: false, identity: true),
                        TipoDocumento = c.String(),
                        FecNacimiento = c.String(),
                        NumeroDocumento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EvaluacionId);
            
            CreateTable(
                "dbo.Plan",
                c => new
                    {
                        PlanId = c.Int(nullable: false, identity: true),
                        CodigoPlan = c.Int(nullable: false),
                        TopeConsumo = c.String(),
                        CargoFijo = c.String(),
                        CaracteristicasPlan = c.String(),
                        Evaluacion_EvaluacionId = c.Int(),
                    })
                .PrimaryKey(t => t.PlanId)
                .ForeignKey("dbo.Evaluacion", t => t.Evaluacion_EvaluacionId)
                .Index(t => t.Evaluacion_EvaluacionId);
            
            CreateTable(
                "dbo.TipoEvaluacion",
                c => new
                    {
                        TipoEvaluacionId = c.Int(nullable: false, identity: true),
                        DescripTipEvaluacion = c.String(),
                    })
                .PrimaryKey(t => t.TipoEvaluacionId);
            
            CreateTable(
                "dbo.TipoPago",
                c => new
                    {
                        TipoPagoId = c.Int(nullable: false, identity: true),
                        FormaPago = c.String(),
                    })
                .PrimaryKey(t => t.TipoPagoId);
            
            CreateTable(
                "dbo.TipoPlan",
                c => new
                    {
                        TipoPlanId = c.Int(nullable: false, identity: true),
                        DescripcionTipoPlan = c.String(),
                    })
                .PrimaryKey(t => t.TipoPlanId);
            
            CreateTable(
                "dbo.TipoTrabajador",
                c => new
                    {
                        TipoTrabajadorId = c.Int(nullable: false, identity: true),
                        CodigoTipoTrabajor = c.Int(nullable: false),
                        DescripTipoTrabajador = c.String(),
                    })
                .PrimaryKey(t => t.TipoTrabajadorId);
            
            CreateTable(
                "dbo.Trabajador",
                c => new
                    {
                        TrabajadorId = c.Int(nullable: false, identity: true),
                        CodigoTrabajador = c.Int(nullable: false),
                        NombreTrabajador = c.String(),
                        ApellidoPaTrabajador = c.String(),
                        ApellidoMaTrabajador = c.String(),
                        NumtipoTrabajador = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrabajadorId);
            
            CreateTable(
                "dbo.Venta",
                c => new
                    {
                        VentaId = c.Int(nullable: false, identity: true),
                        CodigoVenta = c.Int(nullable: false),
                        Modalidad = c.String(),
                        FechaVanta = c.String(),
                        MontoTotal = c.Double(nullable: false),
                        TiposPagos_TipoPagoId = c.Int(),
                    })
                .PrimaryKey(t => t.VentaId)
                .ForeignKey("dbo.TipoPago", t => t.TiposPagos_TipoPagoId)
                .Index(t => t.TiposPagos_TipoPagoId);
            
            CreateTable(
                "dbo.UbigeoProvincias",
                c => new
                    {
                        Ubigeo_UbigeoId = c.Int(nullable: false),
                        Provincia_ProvinciaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ubigeo_UbigeoId, t.Provincia_ProvinciaId })
                .ForeignKey("dbo.Ubigeo", t => t.Ubigeo_UbigeoId, cascadeDelete: true)
                .ForeignKey("dbo.Provincia", t => t.Provincia_ProvinciaId, cascadeDelete: true)
                .Index(t => t.Ubigeo_UbigeoId)
                .Index(t => t.Provincia_ProvinciaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Venta", "TiposPagos_TipoPagoId", "dbo.TipoPago");
            DropForeignKey("dbo.Plan", "Evaluacion_EvaluacionId", "dbo.Evaluacion");
            DropForeignKey("dbo.LineaTelefonica", "Evaluacion_EvaluacionId", "dbo.Evaluacion");
            DropForeignKey("dbo.Cliente", "Evaluacion_EvaluacionId", "dbo.Evaluacion");
            DropForeignKey("dbo.Departamento", "CodProvincia_ProvinciaId", "dbo.Provincia");
            DropForeignKey("dbo.UbigeoProvincias", "Provincia_ProvinciaId", "dbo.Provincia");
            DropForeignKey("dbo.UbigeoProvincias", "Ubigeo_UbigeoId", "dbo.Ubigeo");
            DropForeignKey("dbo.Distrito", "Ubigeo_UbigeoId", "dbo.Ubigeo");
            DropForeignKey("dbo.Departamento", "Ubigeo_UbigeoId", "dbo.Ubigeo");
            DropForeignKey("dbo.LineaTelefonica", "AdministradorLinea_AdministradorLineaId", "dbo.AdministrarLinea");
            DropForeignKey("dbo.LineaTelefonica", "TipoLinea_TipoLineaId", "dbo.TipoLinea");
            DropForeignKey("dbo.EquipoCelular", "AdministradorEquipo_AdministradorEquipoId", "dbo.AdministradorEquipo");
            DropIndex("dbo.UbigeoProvincias", new[] { "Provincia_ProvinciaId" });
            DropIndex("dbo.UbigeoProvincias", new[] { "Ubigeo_UbigeoId" });
            DropIndex("dbo.Venta", new[] { "TiposPagos_TipoPagoId" });
            DropIndex("dbo.Plan", new[] { "Evaluacion_EvaluacionId" });
            DropIndex("dbo.Distrito", new[] { "Ubigeo_UbigeoId" });
            DropIndex("dbo.Departamento", new[] { "CodProvincia_ProvinciaId" });
            DropIndex("dbo.Departamento", new[] { "Ubigeo_UbigeoId" });
            DropIndex("dbo.Cliente", new[] { "Evaluacion_EvaluacionId" });
            DropIndex("dbo.LineaTelefonica", new[] { "Evaluacion_EvaluacionId" });
            DropIndex("dbo.LineaTelefonica", new[] { "AdministradorLinea_AdministradorLineaId" });
            DropIndex("dbo.LineaTelefonica", new[] { "TipoLinea_TipoLineaId" });
            DropIndex("dbo.EquipoCelular", new[] { "AdministradorEquipo_AdministradorEquipoId" });
            DropTable("dbo.UbigeoProvincias");
            DropTable("dbo.Venta");
            DropTable("dbo.Trabajador");
            DropTable("dbo.TipoTrabajador");
            DropTable("dbo.TipoPlan");
            DropTable("dbo.TipoPago");
            DropTable("dbo.TipoEvaluacion");
            DropTable("dbo.Plan");
            DropTable("dbo.Evaluacion");
            DropTable("dbo.EstadoEvaluacion");
            DropTable("dbo.Direccion");
            DropTable("dbo.Distrito");
            DropTable("dbo.Ubigeo");
            DropTable("dbo.Provincia");
            DropTable("dbo.Departamento");
            DropTable("dbo.Contrato");
            DropTable("dbo.Cliente");
            DropTable("dbo.CentroAtencion");
            DropTable("dbo.TipoLinea");
            DropTable("dbo.LineaTelefonica");
            DropTable("dbo.AdministrarLinea");
            DropTable("dbo.EquipoCelular");
            DropTable("dbo.AdministradorEquipo");
        }
    }
}

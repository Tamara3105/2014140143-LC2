using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140143_ENT.IRepositories
{
    public interface IUnityOfWork : IDisposable
    {
        IAdministradorEquipoRepository AdministradorEquipos { get; set; }
        IAdministradorLineaRepository AdministrarLineas { get; set; }
        ICentroAtencionRepository CentroAtencions { get; set; }
        IClienteRepository Clientes { get; set; }
        IContratoRepository Contratos { get; set; }
        IDepartamentoRepository Departamentos { get; set; }
        IDireccionRepository Direccions { get; set; }
        IDistritoRepository Distritos { get; set; }
        IEquipoCelularRepository EquipoCelulars { get; set; }
        IEvaluacionRepository Evaluacions { get; set; }
        ILineaTelefonicaRepository LineaTelefonicas { get; set; }
        IPlanRepository Plans { get; set; }
        IProvinciaRepository Provincias { get; set; }
        ITrabajadorRepository Trabajadors { get; set; }
        IUbigeoRepository Ubigeos { get; set; }
        IVentaRepository Ventas { get; set; }

        int SaveChanges();
        void StateModified(object entity);
    }
}

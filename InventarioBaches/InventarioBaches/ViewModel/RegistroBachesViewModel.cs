using InventarioBaches.Model.Entities;
using InventarioBaches.Model.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace InventarioBaches.ViewModel
{
    public class RegistroBachesViewModel : ObservableBaseObject
    {
        public ObservableCollection<Estado> Estados { get; set; }
        public ObservableCollection<Provincia> Provincias { get; set; }
        public ObservableCollection<Canton> Cantones { get; set; }
        public ObservableCollection<Distrito> Distritos { get; set; }
        public ObservableCollection<Municipalidad> Municipalidades { get; set; }
        public ObservableCollection<TipoBache> TipoBaches { get; set; }
 
        private ClienteAzure clienteAzure;
        public ICommand GuardarReporteCommand { get; private set; }

        public bool IsSaving { set; get; }


        public RegistroBachesViewModel()
        {
            Estados = new ObservableCollection<Estado>();
            Provincias = new ObservableCollection<Provincia>();
            Cantones = new ObservableCollection<Canton>();
            Distritos = new ObservableCollection<Distrito>();
            Municipalidades = new ObservableCollection<Municipalidad>();
            TipoBaches = new ObservableCollection<TipoBache>();

            clienteAzure = new ClienteAzure();

            CargarTipoBache();
            CargarProvincias();
            CargarEstados();

            GuardarReporteCommand = new Command(() => GuardarReporte());

            IsSaving = true;
        }

        public void GuardarReporte()
        {
            IsSaving = false;
            bool isValidForm = true;
            var bache = new Bache();

            if (ProvinciaSeleccionada == null || CantonSeleccionado == null || DistritoSeleccionado == null
                || TipoBacheSeleccionado == null || MunicipalidadSeleccionada == null || string.IsNullOrEmpty(Descripcion))
            {
                isValidForm = false;
            }
            else
            {
                bache.IdProvincia = ProvinciaSeleccionada.Id;
                bache.IdCanton = CantonSeleccionado.Id;
                bache.IdDistrito = DistritoSeleccionado.Id;
                bache.IdTipoBache = TipoBacheSeleccionado.Id;
                bache.IdMunicipalidad = MunicipalidadSeleccionada.Id;            
                bache.Descripcion = Descripcion;
                bache.Nombre = Nombre;
                bache.IdEstado = Estados.FirstOrDefault().Id;
                bache.Fecha = DateTime.Now;
            }

            if (isValidForm)
            {
                clienteAzure.AddBaches(bache);

                MensajeError =string.Empty;

            }
            else
            {
                MensajeError = "Upps! Faltan campos del formulario";
            }
            IsSaving = true;

        }


        #region Metodos GET
        public async void CargarEstados()
        {
            var result = await clienteAzure.GetEstados();

            if (Estados.Any())
                Estados.Clear();

            foreach (var item in result)
            {
                Estados.Add(item);
            }
        }

        public async void CargarProvincias()
        {
            var result = await clienteAzure.GeProvincias();

            if (Provincias.Any())
                Provincias.Clear();

            foreach (var item in result)
            {
                Provincias.Add(item);
            }
        }

        public async void CargarCantones()
        {
            var result = await clienteAzure.GetCantones();

            if (Cantones.Any())
                Cantones.Clear();

            foreach (var item in result.Where(a => a.IdProvincia == provinciaSeleccionada.Id))
            {
                Cantones.Add(item);
            }
        }

        public async void CargarDistritos()
        {
            var result = await clienteAzure.GetDistritos();

            if (Distritos.Any())
                Distritos.Clear();

            foreach (var item in result.Where(a => a.IdProvincia == provinciaSeleccionada.Id && a.IdCanton == cantonSeleccionado.Id))
            {
                Distritos.Add(item);
            }
        }

        public async void CargarMunicipalidades()
        {
            var result = await clienteAzure.GetMunicipalidades();

            if (Municipalidades.Any())
                Municipalidades.Clear();

            foreach (var item in result.Where(a => a.IdProvincia == provinciaSeleccionada.Id && a.IdCanton == cantonSeleccionado.Id))
            {
                Municipalidades.Add(item);
            }
        }

        public async void CargarTipoBache()
        {
            var result = await clienteAzure.GetTipoBaches();

            if (TipoBaches.Any())
                TipoBaches.Clear();

            foreach (var item in result)
            {
                TipoBaches.Add(item);
            }
        }

        #endregion

        #region Propiedades seleccionadas

        private string mensajeError;
        public string MensajeError
        {
            get { return mensajeError; }
            set
            {
                if (value == mensajeError) return;
                mensajeError = value;
                OnPropertyChanged("MensajeError");
            }
        }
        

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value == nombre) return;
                nombre = value;
                OnPropertyChanged("Nombre");
            }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                if (value == descripcion) return;
                descripcion = value;
                OnPropertyChanged("Descripcion");
            }
        }


        private Provincia provinciaSeleccionada;
        public Provincia ProvinciaSeleccionada
        {
            get { return provinciaSeleccionada; }
            set
            {
                if (value == provinciaSeleccionada) return;
                provinciaSeleccionada = value;
                OnPropertyChanged("ProvinciaSeleccionada");
                CargarCantones();
            }
        }

        private Canton cantonSeleccionado;
        public Canton CantonSeleccionado
        {
            get { return cantonSeleccionado; }
            set
            {
                if (value == cantonSeleccionado) return;
                cantonSeleccionado = value;
                OnPropertyChanged("CantonSeleccionado");
                CargarDistritos();
                CargarMunicipalidades();
            }
        }

        private Distrito distritoSeleccionado;
        public Distrito DistritoSeleccionado
        {
            get { return distritoSeleccionado; }
            set
            {
                if (value == distritoSeleccionado) return;
                distritoSeleccionado = value;
                OnPropertyChanged("DistritoSeleccionado");
            }
        }

        private TipoBache tipoBacheSeleccionado;
        public TipoBache TipoBacheSeleccionado
        {
            get { return tipoBacheSeleccionado; }
            set
            {
                if (value == tipoBacheSeleccionado) return;
                tipoBacheSeleccionado = value;
                OnPropertyChanged("TipoBacheSeleccionado");
            }
        }

        private Municipalidad municipalidadSeleccionada;
        public Municipalidad MunicipalidadSeleccionada
        {
            get { return municipalidadSeleccionada; }
            set
            {
                if (value == municipalidadSeleccionada) return;
                municipalidadSeleccionada = value;
                OnPropertyChanged("MunicipalidadSeleccionada");
            }
        }

        #endregion
    }
}

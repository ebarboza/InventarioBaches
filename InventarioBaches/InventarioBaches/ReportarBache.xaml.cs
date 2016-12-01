using InventarioBaches.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace InventarioBaches
{
    public partial class ReportarBache : ContentPage
    {
        

        public ReportarBache()
        {
            InitializeComponent();
            this.BindingContext = new RegistroBachesViewModel();
            
        }        

    }
}

using design_time_datacontext.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_time_datacontext.ViewModel
{
    class PizzaViewModel
    {
        public ObservableCollection<Pizza> PizzaCollection { get; set; }

        public PizzaViewModel()
        {
            PizzaCollection = new ObservableCollection<Pizza>();

            PizzaCollection.Add(new Pizza() { ID = 1, Name = "Hungarian Hustle", Diameter = 45 });
            PizzaCollection.Add(new Pizza() { ID = 2, Name = "Chili Cheese", Diameter = 20 });
            PizzaCollection.Add(new Pizza() { ID = 3, Name = "Triple Z", Diameter = 105 });
        }
    }
}

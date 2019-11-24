using System.Collections.Generic;

namespace Crudlicious.Models

{
    public class IndexView
    {
        public Dish Dish {get; set;}
        public List<Dish> AllDishes {get; set;}
    }
}
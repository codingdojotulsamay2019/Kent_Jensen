using System;
using System.Collections.Generic;

namespace IronNinja
{
    class SpiceHound : Ninja
    {
        public override bool IsFull {get;}
            // provide override for IsFull (Full at 1200 Calories)
        public override void Consume(IConsumable item)
        {
            // provide override for Consume
        }
    }
}



// Make a child class of Ninja, for a SpiceHound. A SpiceHound should be "full" at 1200 calories. When a SpiceHound "Consumes":
// If NOT Full
// adds calorie value to SpiceHound's total calorieIntake (-5 additional calories if the consumable item is "Spicy")
// adds the randomly selected IConsumable object to SpiceHound's ConsumptionHistory list
// calls the IConsumable object's GetInfo() method
// If Full
// issues a warning to the console that the SpiceHound is full and cannot eat anymore
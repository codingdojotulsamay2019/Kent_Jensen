using System;
using System.Collections.Generic;

namespace IronNinja
{
    class SweetTooth : Ninja
    {
        public override bool IsFull {get;}

        public override void Consume(IConsumable item)
        {
            // provide override for Consume
        }
    }
}


// Make a child class of Ninja, for a SweetTooth. A SweetTooth should be "full" at 1500 calories. When a SweetTooth "Consumes":
// If NOT Full
// adds calorie value to SweetTooth's total calorieIntake (+10 additional calories if the consumable item is "Sweet")
// adds the randomly selected IConsumable object to SweetTooth's ConsumptionHistory list
// calls the IConsumable object's GetInfo() method
// If Full
// issues a warning to the console that the SweetTooth is full and cannot eat anymore
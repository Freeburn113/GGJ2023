using Pickups;

namespace Events.Events
{
    public class PickupReceivedEvent : SEvent
    {
        public static Handler<PickupReceivedEvent> Handlers; //it's handlers

        public readonly PickupType pickupType; // these are constants so ok for public

        public PickupReceivedEvent(PickupType _pickupType) // pars point out left and right score like 1,0 or 0,1, not the total score
        {
            pickupType = _pickupType;
        }

        public override void Deliver()
        {
            if (Handlers != null) Handlers(this); // deliver this specific event to it's handlers
        }
    }
}
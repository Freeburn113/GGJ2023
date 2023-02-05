using Pickups;

namespace Events.Events
{
    public class CustomerEvent : SEvent
    {
        public static Handler<CustomerEvent> Handlers; //it's handlers

        public readonly int id;
        public readonly int meshId; // these are constants so ok for public

        public CustomerEvent(int _id, int _meshId) // pars point out left and right score like 1,0 or 0,1, not the total score
        {
            id = _id;
            meshId = _meshId;
        }

        public override void Deliver()
        {
            if (Handlers != null) Handlers(this); // deliver this specific event to it's handlers
        }
    }
}
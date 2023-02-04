namespace Events
{
    public abstract class SEvent
    {
        /// <summary>
        /// The handlers for the event
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="e">The e.</param>
        public delegate void Handler<E>(E e) where E : SEvent;

        /// <summary>
        /// Delivers this instance.
        /// </summary>
        abstract public void Deliver();
    }
}
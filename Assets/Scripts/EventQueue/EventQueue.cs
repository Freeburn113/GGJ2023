using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    public class EventQueue : MonoBehaviour
    {
        private List<SEvent> queue = new List<SEvent>();

        /// <summary>
        /// Add the specified event to the queue.
        /// </summary>
        /// <param name="e">The event.</param>
        public void Add(SEvent e)
        {
            queue.Add(e);
        }

        /// <summary>
        /// Deliver all the events to their handlers
        /// </summary>
        public void Deliver()
        {
            for (int i = 0; i < queue.Count; ++i)
            {
                SEvent e = queue[i];
                e.Deliver();
            }
            queue.Clear();
        }

        public void LateUpdate()
        {
            Deliver();
        }
    }
}

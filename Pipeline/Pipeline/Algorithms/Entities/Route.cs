using System.Collections;
using System.Collections.Generic;

namespace Pipeline.Algorithms.Entities
{
    public class Route : IEnumerable<Road>
    {
        private List<Road> _nodes = null;

        public Route()
        {
            _nodes = new List<Road>();
        }


        public void Add(Road node)
        {
            _nodes.Add(node);
        }

        public int Capacity
        {
            get
            {
                return _nodes.Count;
            }
        }


        #region IEnumarable Implementaion


        public IEnumerator<Road> GetEnumerator()
        {
            return _nodes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _nodes.GetEnumerator();
        }


        #endregion
    }
}

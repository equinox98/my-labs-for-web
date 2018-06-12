using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizations
{
    public class Plant : Organization, IEnumerable
    {
        //collection of all products
        //performed in the plant
        private ArrayList _production = null;


        //Constructor
        public Plant() : base()
        {
            _production = new ArrayList();
        }

        /// <summary>
        /// Add product to the performed list
        /// </summary>
        /// <param name="product"></param>
        public void Add(object product)
        {
            _production.Add(product);
        }

        /// <summary>
        /// Iterates on each one of the products
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return _production.GetEnumerator();
        }
    }
}

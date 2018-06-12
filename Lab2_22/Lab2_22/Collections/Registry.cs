using Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab2_22.Collections
{
    public class Registry : IEnumerable<Organization>
    {
        //list of organizations
        private List<Organization> _organizations;

        public Registry()
        {
            _organizations = new List<Organization>();
        }

        public void Add(Organization organization)
        {
            _organizations.Add(organization);
        }

        public void Remove(Organization organization)
        {
            _organizations.Remove(organization);
        }


        public IEnumerator<Organization> GetEnumerator()
        {
            return _organizations.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _organizations.GetEnumerator();
        }



        public void ShowInfo()
        {
            foreach(var organization in _organizations)
            {
                organization.ShowInfo();
            }
        }

    }
}

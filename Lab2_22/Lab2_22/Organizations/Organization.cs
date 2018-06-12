using System.Collections.Generic;
using System.Linq;

namespace Organizations
{
    public abstract class Organization
    {
        private List<Personal.Stuff> _stuff;


        //name of the organization
        public string Name { get; private set; }

        //director info
        public Personal.Stuff Director { get; private set; }

        //cout of all branches
        public int BranchesCount { get; private set; }

        public Organization()
        {
            this._stuff = new List<Personal.Stuff>();
        }

        public List<Personal.Stuff> Stuff
        {
            get
            {
                return this._stuff;
            }
        }

        public void AddStuff(Personal.Stuff stuff)
        {
            _stuff.Add(stuff);
        }

        public void RemoveStuff(Personal.Stuff stuff)
        {
            _stuff.Remove(stuff);
        }

        /// <summary>
        /// Return summ of each one of stuff
        /// </summary>
        public int GeneralSalary
        {
            get
            {
                int salary = 0;

                foreach(var person in _stuff)
                {
                    salary += person.Salary;
                }


                return salary;

            }
        }

        /// <summary>
        /// Return count of stuff in the 
        /// aproppriative department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public int DepartmentStuffCount(OrganizationDepartments department)
        {
            int count = 0;

            _stuff.ForEach((s) =>
            {
                if(s.Department == department)
                {
                    count++;
                }
            });

            return count;

        }

        /// <summary>
        /// Get general count of the stuff
        /// </summary>
        public int StuffCount
        {
            get
            {
                return _stuff.Count;
            }
        }

        /// <summary>
        /// Get avarage salary
        /// </summary>
        public int AvarageSalary
        {
            get
            {
                int count = _stuff.Count;
                int generalSalary = 0;

                foreach(var person in _stuff)
                {
                    generalSalary += person.Salary;
                }

                return count == 0 ? 0 : generalSalary / count;
            }
        }

        public virtual void ShowInfo()
        {
            System.Console.WriteLine("Title{0}\nDirector:{1}\nAvarage Salary:{2}\nStuff Count{3}:\nBranches Count:{4}\n", Name, 
                Director, AvarageSalary, StuffCount, BranchesCount);
        }

    }
}

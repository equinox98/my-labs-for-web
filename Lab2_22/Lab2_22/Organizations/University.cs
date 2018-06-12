using Organizations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_22.Organizations
{
    public class University : Organization, IEnumerable
    {
        //collection of the students
        private List<Student> _students;

        public University() : base()
        {
            _students = new List<Student>();
        }

        /// <summary>
        /// Get list of all students
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return _students.GetEnumerator();
        }



        #region Student

        private struct Student
        {
            public string Name;
            public string Term;
        }

        #endregion
    }
}

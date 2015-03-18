using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class Admin
    {
        #region Student

        public static void AddStudent(Student student)
        {
            using (SchoolDataDataContext conn = new SchoolDataDataContext())
            {
                conn.Students.InsertOnSubmit(student);
                conn.SubmitChanges();
            }
        }

        #endregion
    }
}

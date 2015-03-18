using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VoiceRecorder
{
    class Admin
    {
        #region Student

        //db : local
        public static void AddStudent(HeartRate student)
        {
            using (HeartRateDBDataContext conn = new HeartRateDBDataContext())
            {
                conn.HeartRates.InsertOnSubmit(student);
                //conn.SubmitChanges();
            }
        }
        
        // db : online
        //public static void AddStudent(ES_HeartRate student)
        //{
        //    using (ShesopDBDataContext conn = new ShesopDBDataContext())
        //    {
        //        conn.ES_HeartRates.InsertOnSubmit(student);
        //        conn.SubmitChanges();
        //    }
        //}

        // db : localShesop
        //public static void AddStudent(STEPPY_API_t_loose_measurement student)
        //{
        //    using (db_shesop2DataContext conn = new db_shesop2DataContext())
        //    {
        //        conn.STEPPY_API_t_loose_measurements.InsertOnSubmit(student);
        //        conn.SubmitChanges();
        //    }
        //}

        #endregion
    }
}

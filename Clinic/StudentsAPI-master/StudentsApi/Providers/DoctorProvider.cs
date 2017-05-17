using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentsApi.Providers
{
    public class DoctorProvider
    {
        DatabaseDB db = new DatabaseDB();

        public IList<Doctor> GetDisponibilityDoctors()
        {
            return db.Doctors.Where(d => d.Disponibility.Equals("1")).ToList();
        }

        public void Add(Doctor doctor)
        {
            db.Doctors.Add(doctor);
            db.SaveChanges();

        }
        public void Edit(Doctor doctor)
        {
            db.Entry(doctor).State = EntityState.Modified;
            db.SaveChanges();

        }
        public void Delete(int id)
        {
            Doctor doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
            db.SaveChanges();

        }


        public Doctor GetDoctorById(int? id)
        {
            try
            {
                Doctor doctor = db.Doctors.First(d => d.Id == id);
                return doctor;
            }
            catch (Exception)
            {
                return null;

            }



        }

    }
}
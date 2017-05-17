using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsApi.Providers
{
    public class ConsultProvider
    {
        public DatabaseDB db = new DatabaseDB();

        public IList<Consultation> GetConsults() {

            var consults = db.Consultations.ToList();
            return consults;
        }

        public void Add(Consultation consultation) {

            db.Consultations.Add(consultation);
            db.SaveChanges();
        }

        public void Edit(Consultation consultation) {

            db.Entry(consultation).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

        }

        public Patient GetById(int id)
        {
            Patient patient = db.Patients.Find(id);
            return patient;
        }

        public void Delete(int id) {

            Consultation consultation = db.Consultations.Find(id);
            db.Consultations.Remove(consultation);
            db.SaveChanges();
        }

    }
}
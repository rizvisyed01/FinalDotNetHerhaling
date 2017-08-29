using FinalHerhalingApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace FinalHerhalingApi.repositories
{
    public class SchoolRepository
    {
        private SchoolContext Db;

        public SchoolRepository(SchoolContext context)
        {
            Db = context;
        }

        public ICollection<StudentBasic> getAllStudenten()
        {
            return Db.Studenten.Select(s => new StudentBasic()
            {
                StudId = s.Studnr,
                Voornaam = s.Voornaam,
                Achternaam = s.Familienaam
            }).OrderBy(s => s.StudId).ToList();
        }

        public StudentBasic getStudentById(int id)
        {
            return Db.Studenten.Select(s => new StudentBasic()
            {
                StudId = s.Studnr,
                Voornaam = s.Voornaam,
                Achternaam = s.Familienaam
            }).OrderBy(s => s.StudId).Where(s => s.StudId == id).FirstOrDefault();
        }

        public void addStudent(StudentBasic student)
        {
            Db.Studenten.Add(new Studenten()
            {
                Studnr = student.StudId,
                Voornaam = student.Voornaam,
                Familienaam = student.Achternaam
            });
            Db.SaveChanges();
        }

        public void changeStudent(int id, StudentBasic student)
        {
            Studenten old = Db.Studenten.Where(s => s.Studnr == id).First();
            old.Voornaam = student.Voornaam;
            old.Familienaam = student.Achternaam;
            Db.Update(old);
            Db.SaveChanges();
        }

        public void deleteStudent(int id)
        {
            Db.Studenten.Remove(Db.Studenten.Where(s => s.Studnr == id).First());
            Db.SaveChanges();
        }
    }
}

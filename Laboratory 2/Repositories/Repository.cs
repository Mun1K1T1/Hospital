using Laboratory_2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using Laboratory_2.Data.Models.Data;

namespace Laboratory_2.Repositories
{
    public class Repository<T> : IRepository<T> where T : EEntity
    {
        private static DBApplicationContext _context;
        private static Repository<T> _instanse;
        private static DbSet<T> _dbSet;

        private Repository(DBApplicationContext db)
        {
            _context = db;
            _dbSet = _context.Set<T>();
        }

        public static Repository<T> GetRepo(DBApplicationContext db)
        {
            if (_instanse == null)
                _instanse = new Repository<T>(db);

            return _instanse;
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate = null)
        {
            try
            {
                if (predicate == null)
                    return _dbSet;

                return _dbSet.AsEnumerable().Where(item => predicate(item));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading: {0}", ex.Message);
                return null;
            }
        }

        public void Create(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating: {0}", ex.Message);
            }
        }
        public void Update(T updatedEntity)
        {
            try
            {
                T entity = _dbSet.FirstOrDefault(item => updatedEntity.Key == item.Key);
                _context.Entry(entity).CurrentValues.SetValues(updatedEntity);
                _context.Entry(entity).State = EntityState.Modified;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating: {0}", ex.Message);
            }
        }

        public void Delete(Guid key)
        {
            try
            {
                T entity = _dbSet.FirstOrDefault(item => item.Key == key);


                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting: {0}", ex.Message);
            }
        }

        public T GetFirst(Func<T, bool> predicate)
        {
            try
            {
                return _dbSet.AsEnumerable().FirstOrDefault(item => predicate(item));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error looking: {0}", ex.Message);
                return null;
            }
        }

        //public EPatient GetPatientKey()
        //{
        //    using (var db = new DBApplicationContext())
        //    {
        //        EPatient result = db.Patients.FirstOrDefault(k => k.Key == Patient_Key);

        //        return result;
        //    }
        //}

        //public EDoctor GetDoctorKey()
        //{
        //    using (var db = new DBApplicationContext())
        //    {
        //        EDoctor result = db.Doctors.FirstOrDefault(k => k.Key == Doctor_Key);

        //        return result;
        //    }
        //}
    }
}

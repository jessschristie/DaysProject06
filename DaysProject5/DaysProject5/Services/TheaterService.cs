using DaysProject5.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;

namespace DaysProject5.Services
{
    public class TheaterService 
    {
        private MovieDBContext db;
        //private ModelStateDictionary modelState;

        public TheaterService()
        {
            db = new MovieDBContext();
        }

        public TheaterService(MovieDBContext dbc)
        {
            db = dbc;
        }

        public IEnumerable<Theater> Read()
        {
            return GetData();
        }

        public List<Theater> CreateData(Theater obj)
        {
            db.Theaters.Add(obj);
            db.SaveChanges();
            return db.Theaters.ToList();
        }

        public Theater DeleteData(int? id)
        {
            Theater theater = db.Theaters.Find(id);
            db.Theaters.Remove(theater);
            db.SaveChanges();
            return theater;
        }

        public Movie EditData(Movie obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            return obj;
        }

        public Theater FindData(int? id)
        {
            Theater theater = db.Theaters.Find(id);
            return theater;
        }

        public List<Theater> GetData()
        {
            return db.Theaters.ToList();
        }

        public void DestroyData(Theater obj)
        {
            var target = GetData().FirstOrDefault(p => p.ID == obj.ID);
            if (target != null)
            {
                db.Theaters.Remove((Theater)target);
                db.SaveChanges();
            }
        }

        //void IService<Theater>.CreateData(Theater obj)
        //{
        //    throw new NotImplementedException();
        //}

        //void IService<Theater>.GetData()
        //{
        //    throw new NotImplementedException();
        //}

        //public void FindData(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //void IService<Theater>.EditData(Theater obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeleteData(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //Theater IService<Theater>.FindData(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
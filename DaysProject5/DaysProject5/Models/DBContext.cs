﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DaysProject5.Models
{
    public class DBContext
    {
    }

    //public class TheaterDBContext : DbContext
    //{
    //    public virtual DbSet<Theater> Theaters { get; set; }
    //}

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Theater> Theaters { get; set; }
    }

}
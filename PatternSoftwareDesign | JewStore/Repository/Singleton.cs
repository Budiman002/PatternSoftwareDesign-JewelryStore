using ProjectLabPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSD.Repository
{
    public class Singleton
    {
        private static DatabaseJawelEntities db;

        public static DatabaseJawelEntities GetDatabase()
        {
            if (db == null)
            {
                db = new DatabaseJawelEntities();
            }
            return db;
        }
    }
}
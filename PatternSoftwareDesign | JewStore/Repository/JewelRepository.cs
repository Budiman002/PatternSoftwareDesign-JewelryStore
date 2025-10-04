using ProjectLabPSD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectLabPSD.Repository
{
    public class JewelRepository
    {
        private static DatabaseJawelEntities db = Singleton.GetDatabase();

        public static bool PostNewJewel(MsJewel newJewel)
        {
            db.MsJewels.Add(newJewel);
            return db.SaveChanges() > 0;
        }

        public static List<MsJewel> GetAllJewels()
        {
            return (from jewel in db.MsJewels select jewel).ToList();
        }

        public static MsJewel GetJewelById(int id)
        {
            return (from jewel in db.MsJewels where jewel.JewelID == id select jewel).FirstOrDefault();
        }

        public static bool UpdateJewel(MsJewel updatedJewel)
        {
            MsJewel existingJewel = db.MsJewels.FirstOrDefault(j => j.JewelID == updatedJewel.JewelID);

            if (existingJewel != null)
            {
                db.Entry(existingJewel).CurrentValues.SetValues(updatedJewel);
                db.Entry(existingJewel).State = EntityState.Modified;

                return db.SaveChanges() > 0;

            }
            return false;
        }

        public static List<MsCategory> GetAllCategories()
        {
            return db.MsCategories.ToList();
        }

        public static List<MsBrand> GetAllBrands()
        {
            return db.MsBrands.ToList();
        }

    }
}
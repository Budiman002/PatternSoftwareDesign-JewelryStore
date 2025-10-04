using ProjectLabPSD.Factory;
using ProjectLabPSD.Models;
using ProjectLabPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSD.Handler
{
    public class JewelHandler
    {
        public static bool InsertJewel(string name, int categoryId, int brandId, int price, int year)
        {
            MsJewel newJewel = JewelFactory.CreateJewel(name, categoryId, brandId, price, year);
            return JewelRepository.PostNewJewel(newJewel);
        }

        public static List<MsJewel> GetAllJewels()
        {
            return JewelRepository.GetAllJewels();
        }


        #region Update Jewel
        public static MsJewel GetJewelById(int jewelId)
        {

            MsJewel jewel = JewelRepository.GetJewelById(jewelId);

            if (jewel == null)
            {
                throw new Exception("Jewel not found.");
            }

            return jewel;
        }

        // Dari input user
        public static string ValidateAndUpdateJewel(int id, string name, int categoryId, int brandId, int price, int year)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 25)
                return "Jewel name must be 3 to 25 characters (inclusive).";

            if (price <= 25)
                return "Price must be greater than 25.";

            if (year >= DateTime.Now.Year)
                return "Year must be less than current year.";

            MsJewel jewel = new MsJewel
            {
                JewelID = id,
                JewelName = name,
                CategoryID = categoryId,
                BrandID = brandId,
                JewelPrice = price,
                JewelReleaseYear = year
            };

            bool success = JewelRepository.UpdateJewel(jewel);
            return success ? null : "Failed to update jewel.";
        }
        #endregion

        // Untuk internal
        public static bool UpdateJewel(int jewelId, string name, int categoryId, int brandId, int price, int year)
        {
            if (jewelId <= 0)
            {
                throw new ArgumentException("Jewel ID must be greater than zero.");
            }

            MsJewel existingJewel = JewelRepository.GetJewelById(jewelId);

            if (existingJewel == null)
            {
                throw new Exception("Jewel not found.");
            }

            existingJewel.JewelName = name;
            existingJewel.CategoryID = categoryId;
            existingJewel.BrandID = brandId;
            existingJewel.JewelPrice = price;
            existingJewel.JewelReleaseYear = year;

            return JewelRepository.UpdateJewel(existingJewel);
        }


        #region Add Jewel (Add Jewel Page)
        public static List<MsCategory> GetAllCategories()
        {
            return JewelRepository.GetAllCategories();
        }

        public static List<MsBrand> GetAllBrands()
        {
            return JewelRepository.GetAllBrands();
        }

        public static string ValidateAndAddJewel(string name, int categoryId, int brandId, int price, int year)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 25)
                return "Jewel name must be between 3 and 25 characters.";

            if (price <= 25)
                return "Price must be greater than 25.";

            if (year >= DateTime.Now.Year)
                return "Release year must be less than current year.";

            MsJewel jewel = JewelFactory.CreateJewel(name, categoryId, brandId, price, year);
            bool success = JewelRepository.PostNewJewel(jewel);
            return success ? null : "Failed to add jewel.";
        }
        #endregion

    }
}
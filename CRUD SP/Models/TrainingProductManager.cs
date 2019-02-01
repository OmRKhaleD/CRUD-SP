using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD_SP.Models
{
    public class TrainingProductManager
    { 
        public TrainingProductManager()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
            db = new CURDDbContext();
        }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }
        CURDDbContext db ;
        public List<TrainingProduct> Get(TrainingProduct entity)
        {
            List<TrainingProduct> ret = db.Products.ToList();
            if (!string.IsNullOrEmpty(entity.ProductName))
            {
                ret = ret.FindAll(p => p.ProductName.ToLower().StartsWith(entity.ProductName,StringComparison.CurrentCultureIgnoreCase));
            }

            return ret;
        }

        public bool Validate(TrainingProduct entity)
        {
            ValidationErrors.Clear();
            if (!string.IsNullOrEmpty(entity.ProductName))
            {
                if (entity.ProductName.ToLower() == entity.ProductName)
                {
                    ValidationErrors.Add(new KeyValuePair<string, string>("ProductName", "Product Name must not be all lower case"));
                }
            }

            return (ValidationErrors.Count == 0);
        }

        public bool Insert(TrainingProduct entity)
        {
            bool ret = Validate(entity);
            if (ret)
            {
                db.Products.Add(entity);
                db.SaveChanges();
                //insert database
            }
            return ret;

        }

        public TrainingProduct Get(int productId)
        {
            TrainingProduct ret = db.Products.Find(productId);
            return ret;
        }

        public bool Update(TrainingProduct entity)
        {
            bool ret = Validate(entity);
            if (ret)
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
            return ret;
        }

        public bool Delete(TrainingProduct entity)
        {
            db.Products.Remove(entity);
            db.SaveChanges();
            return true;
        }
    }
}
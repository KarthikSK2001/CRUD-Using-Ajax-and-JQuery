using CRUDUsingAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDUsingAjax.Controllers
{
    public class ProductController : ApiController
    {
        Entities db = new Entities();

        // Post Method 
        public string Post(tbl_product product)
        {
            db.tbl_product.Add(product);
            db.SaveChanges();
            return "Product Added";
        }

        // Get Method
        public IEnumerable<tbl_product> Get()
        {
            var data = db.tbl_product.ToList();
            return data;
        }

        // Get Single Record
        public tbl_product Get(int id)
        {
            tbl_product product = db.tbl_product.Find(id);
            return product;
        }

        // Update Record
        public string Put(int id , tbl_product product)
        {
            var product_ = db.tbl_product.Find(id);
            product_.Name = product.Name;
            product_.Price = product.Price;
            product_.Quantity = product.Quantity;
            product_.Active = product.Active;

            db.Entry(product_).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return "Product Updated";
        }

        // Delete Record
        public string Delete(int id)
        {
            tbl_product product = db.tbl_product.Find(id);
            db.tbl_product.Remove(product);
            db.SaveChanges();
            return "Product Deleted";
        }
    }
}

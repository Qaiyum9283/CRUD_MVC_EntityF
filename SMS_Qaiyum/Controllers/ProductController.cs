using PM_Qaiyum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PM_Qaiyum.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Product
        public ActionResult ProductDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetProducts()
        {
            List<Product> products = db.Products.ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetProductById(int ProductId)
        {
            Product product = db.Products.FirstOrDefault(e => e.ProductId == ProductId);
            return Json(product,JsonRequestBehavior.AllowGet);   
        }

        [HttpPut]
        public ActionResult Update(Product updatedProduct)
        {
            Product existingProduct = db.Products.FirstOrDefault(x => x.ProductId == updatedProduct.ProductId);

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.QuantityInStock = updatedProduct.QuantityInStock;

            db.Entry(existingProduct).State = EntityState.Modified;
            db.SaveChanges();

            return Json(existingProduct, JsonRequestBehavior.AllowGet);
               
        }

        public ActionResult DeleteProduct(int ProductId)
        {
            Product product = db.Products.FirstOrDefault(x => x.ProductId == ProductId);

            db.Products.Remove(product);
            db.SaveChanges();

            return GetProducts();
        }

        [HttpPut]
        public ActionResult ReplaceProduct(Product initial_product, Product new_product )
        {
            Product productToUpdate = db.Products.FirstOrDefault(p => p.ProductId == initial_product.ProductId);


            productToUpdate.Name = initial_product.Name;
            productToUpdate.Description = initial_product.Description;
            productToUpdate.Price = initial_product.Price;
            productToUpdate.QuantityInStock = initial_product.QuantityInStock;

            db.SaveChanges();

            return GetProducts();
        }

    }
}
using AspNetMvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AspNetMvc.Controllers
{
    public class ProductsController : Controller
    {
        // GET: ProductsController
        public async Task<ActionResult> Index()
        {
            var http = new HttpClient();
            var products = await http.GetFromJsonAsync<List<Product>>("https://localhost:44353/api/Products");

            return View(products);
        }

        // GET: ProductsController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var http = new HttpClient();
            var products = await http.GetFromJsonAsync<List<Product>>("https://localhost:44353/api/Products");

            var product = products.FirstOrDefault(m => m.Id == id);

            if (products == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Short,Description,Price,SubCategoryId,ImageUrl")] ProductCreateModel product)
        {
            if (ModelState.IsValid)
            {
                string p = JsonConvert.SerializeObject(product);
                HttpContent c = new StringContent(p, Encoding.UTF8, "application/json");

                var http = new HttpClient();
                var response = await http.PostAsync("https://localhost:44353/api/Products", c);

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

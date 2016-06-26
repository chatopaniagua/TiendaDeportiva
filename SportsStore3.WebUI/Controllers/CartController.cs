using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore3.Domain.Abstract;
using SportsStore3.Domain.Entities;
using SportsStore3.WebUI.Models;

namespace SportsStore3.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private IOrderProcesor orderProcessor;

        public CartController(IProductRepository repoParam, IOrderProcesor processor)
        {
            repository = repoParam;
            orderProcessor = processor;
            // Comentario de prueba
        }

        public RedirectToRouteResult AddToCart(int productID, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(x => x.ProductID == productID);
            if (product != null) {
                GetCart().AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int productID, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(x => x.ProductID == productID);
            if (product != null)
            {
                GetCart().RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });

        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            CartIndexViewModel model = new CartIndexViewModel();
            model.Cart = cart;
            model.ReturnUrl = returnUrl;
            return View(model);
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails details)
        {
            if(cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, details);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(details);
            }
        }
    }
}
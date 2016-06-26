using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore3.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public IEnumerable<CartLine> Lines {
            get { return lineCollection; }
        }

        public void AddItem(Product product, int qty)
        {
            CartLine cartline = lineCollection
                .Where(x => x.Product.ProductID == product.ProductID)
                .FirstOrDefault();
            if (cartline == null) {
                lineCollection.Add(new CartLine {
                    Product = product,
                    Quantity = qty
                });
            }
            else
            {
                cartline.Quantity += qty;
            }
        }

        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(x => x.Product.ProductID == product.ProductID);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(x => x.Product.Price * x.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore3.Domain.Abstract;
using SportsStore3.Domain.Entities;

namespace SportsStore3.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        // dbContext must be a private field in repositories, not exposed
        // Architecture is should be independent of frameworks
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products {
            get{
                return context.Products;
            }
        }
    }
}

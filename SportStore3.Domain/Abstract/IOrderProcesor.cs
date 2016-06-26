using SportsStore3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore3.Domain.Abstract
{
    public interface IOrderProcesor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}

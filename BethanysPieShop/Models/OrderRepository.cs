using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;


        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }


        public void CreateOrder(Order order)
        {
            try
            {
                order.OrderPlaced = DateTime.Now;

              var Order =  _appDbContext.Orders.Add(order).Entity;
                _appDbContext.SaveChanges();


                var shoppingCartItems = _shoppingCart.ShoppingCartItems;

                foreach (var shoppingCartItem in shoppingCartItems)
                {
                    var orderDetail = new OrderDetail()
                    {
                        Amount = shoppingCartItem.Amount,
                        PieId = shoppingCartItem.Pie.PieId,
                        OrderId = Order.OrderId,
                        Price = shoppingCartItem.Pie.Price
                    };

                    _appDbContext.OrderDetails.Add(orderDetail);
                }

                _appDbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

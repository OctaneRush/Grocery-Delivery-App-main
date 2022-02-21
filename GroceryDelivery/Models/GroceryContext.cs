#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GroceryDelivery.Models
{
    public class GroceryDbContext : DbContext
    {
        public GroceryDbContext (DbContextOptions<GroceryDbContext> options)
                : base(options)
                {
                }

                public DbSet<Customer> Customers {get; set;}
                public DbSet<DeliveryPerson> DeliveryPeople {get; set;}
                public DbSet<Item> Items {get; set;}
                public DbSet<Order> Orders {get; set;}
                public DbSet<Store> Stores {get; set;}
                public DbSet<OrderDelivery> OrderDeliveries {get; set;}

                public async virtual Task AddItemAsync(Item items)
                {
                    Items.Add(items);
                    await SaveChangesAsync();
                }

                public async virtual Task AddOrderAsync(Order orders)
                {
                    Orders.Add(orders);
                    await SaveChangesAsync();
                }
    }
}
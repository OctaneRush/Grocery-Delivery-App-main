using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GroceryDelivery.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GroceryDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<GroceryDbContext>>()))
                {
                    // Look for customers, orders, stores, items
                    if (context.Customers.Any() && context.Orders.Any() && context.Stores.Any() && context.Items.Any())
                    {
                        return; // db seeded
                    }

                    List<Customer> CustomersAdd = new List<Customer>() {
                        new Customer // Index[0]
                        {
                            FirstName = "Joe",
                            LastName = "Bob",
                            Address = "1234 That St.",
                            PhoneNumber = "1234567890",
                            Email = "thisperson@thatemail.com",
                            CreditCard = 459823423
                        },
                        new Customer // Index[1]
                        {
                            FirstName = "Michelle",
                            LastName = "Wilson",
                            Address = "5678 This St.",
                            PhoneNumber = "01234567897",
                            Email = "thatperson@thisemail.com",
                            CreditCard = 89897863
                        }
                    };

                    context.Customers.AddRange(CustomersAdd);

                    List<Store> StoresAdd = new List<Store>() {
                        new Store // Index[0]
                        {
                            Name = "LowCost Shop",
                            Address = "5678 Mountain Dr",
                            PhoneNumber = "5486548932"
                        },
                        new Store //Index[1]
                        {
                            Name = "Premium Deals Plus",
                            Address = "4621 Beach Dr",
                            PhoneNumber = "2785461524"
                        }
                    };

                    context.Stores.AddRange(StoresAdd);

                    List<Order> OrdersAdd = new List<Order>() {
                        new Order
                        {
                            PricePaid = 50.14,
                            Customer = CustomersAdd[0]
                        },
                        new Order
                        {
                            PricePaid = 90.56,
                            Customer = CustomersAdd[1]
                        }
                    };

                    context.Orders.AddRange(OrdersAdd);

                    List<Item> ItemsAdd = new List<Item>() {
                        new Item
                        {
                            ItemName = "Discount Oranges",
                            ItemType = "Produce",
                            Quantity = 5,
                            Price = 2.50,
                            Store = StoresAdd[0],
                            Order = OrdersAdd[0]
                        },
                        new Item
                        {
                            ItemName = "Premium Soda",
                            ItemType = "Beverage",
                            Quantity = 12,
                            Price = 7.25,
                            Store = StoresAdd[1],
                            Order = OrdersAdd[1]
                        }
                    };

                    context.Items.AddRange(ItemsAdd);

                    context.SaveChanges();
                }
        }
    }
}
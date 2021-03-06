using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroceryDelivery;
using Xunit;

namespace GroceryDelivery.Models
{
    public class DataAccessLayerTest
    {
        [Fact]
        public async Task AddItemAsync_ItemIsAdded()
        {
            using (var db = new GroceryDbContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var recId = 10;
                var expectedItem = new Item()
                {
                    ItemID = recId,
                    ItemName = "New Item",
                    ItemType = "Some Type",
                    Quantity = 3,
                    Price = 4.00
                };
                
                // Act
                await db.AddItemAsync(expectedItem);

                // Assert
                var actualItem = await db.FindAsync<Item>(10);
                Assert.Equal(expectedItem, actualItem);
                
            }
        }

        // [Fact]
        // public async Task AddMessageAsync_MessageIsAdded()
        // {
        //     using (var db = new AppDbContext(Utilities.TestDbContextOptions()))
        //     {
        //         // Arrange
        //         var recId = 10;
        //         var expectedMessage = new Message() { Id = recId, Text = "Message" };

        //         // Act
        //         await db.AddMessageAsync(expectedMessage);

        //         // Assert
        //         var actualMessage = await db.FindAsync<Message>(recId);
        //         Assert.Equal(expectedMessage, actualMessage);
        //     }
        // }
    }
}
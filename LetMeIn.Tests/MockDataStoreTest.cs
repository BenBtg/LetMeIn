using LetMeIn.Models;
using LetMeIn.Services;
using NuGet.Frameworks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LetMeIn.Tests
{
    public class MockDataStoreTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task AddItemTestAsync()
        {
            // Arrange
            MockDataStore dataStore = new MockDataStore();
            var item = new Item {Id="1", Text = "Test" };

            // Act
            var added = await dataStore.AddItemAsync(item);

            // Asset
            Assert.IsTrue(added);
            var item2 = await dataStore.GetItemAsync(item.Id);
            Assert.AreEqual(item, item2);
        }
    }
}

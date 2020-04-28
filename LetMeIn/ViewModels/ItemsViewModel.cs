using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using LetMeIn.Models;
using LetMeIn.Views;
using LetMeIn.Services;

namespace LetMeIn.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private readonly AuthService _authService;
        private readonly SimpleGraphService _simpleGraphService;

        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public bool IsSignedIn { get; set; }
        public bool IsSigningIn { get; set; }
        public string Name { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            _authService = new AuthService();
            _simpleGraphService = new SimpleGraphService();

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {

            IsSigningIn = true;

            if (await _authService.SignInAsync())
            {
                Name = await _simpleGraphService.GetNameAsync();
                IsSignedIn = true;
            }

            IsSigningIn = false;

            //IsBusy = true;

            //try
            //{
            //    Items.Clear();
            //    var items = await DataStore.GetItemsAsync(true);
            //    foreach (var item in items)
            //    {
            //        Items.Add(item);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex);
            //}
            //finally
            //{
            //    IsBusy = false;
            //}
        }
    }
}
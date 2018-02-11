﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBookie.Models;
using TechBookie.Views;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace TechBookie.ViewModels
{
	class AllBooksPageViewModel : ViewModelBase
	{
		public AllBooksPageViewModel()
		{
			if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
			{
				// DesignTime values
			}
			else
			{
				LoadBooks();
			}
		}

		public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
		{
			if (state.Any())
			{
				// Get Value
				state.Clear();
			}
			return Task.CompletedTask;
		}

		public override Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending)
		{
			if (suspending)
			{
				// Handle Suspending
			}
			return Task.CompletedTask;
		}

		public override Task OnNavigatingFromAsync(NavigatingEventArgs args)
		{
			args.Cancel = false;
			return Task.CompletedTask;
		}

		public async void LoadBooks()
		{
			var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/booksdata.json"));
			var fileContents = await FileIO.ReadTextAsync(file);

			var books = JsonConvert.DeserializeObject<List<Book>>(fileContents);
			Books = new ObservableCollection<Book>(books);
		}

		private ObservableCollection<Book> books;

		public ObservableCollection<Book> Books
		{
			get { return books; }
			set { Set(ref books, value); }
		}

		public void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var gv = sender as GridView;
			if (gv.SelectedIndex != -1)
			{
				NavigationService.Navigate(typeof(SingleBook), gv.SelectedItem);
			}
		}

	}
}

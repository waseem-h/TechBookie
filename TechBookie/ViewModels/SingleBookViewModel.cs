using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechBookie.Models;
using TechBookie.Services.FileService;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace TechBookie.ViewModels
{
	public class SingleBookViewModel : ViewModelBase
	{
		public SingleBookViewModel()
		{

		}

		private Book book;

		public Book Book
		{
			get { return book; }
			set
			{
				Set(ref book, value);
				SetFavoriteText();
			}
		}

		private string bookDescription;

		public string BookDescription
		{
			get { return bookDescription; }
			set { Set(ref bookDescription, value); }
		}



		public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
		{
			if (state.Any())
			{
				// Get Value
				state.Clear();
			}
			Book = parameter as Book;

			SetFavoriteText();
			GetBookDescription();


			return Task.CompletedTask;
		}

		private async void GetBookDescription()
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					string webpage = await client.GetStringAsync("http://it-ebooks.info/book/" + Book.BookNumber + "/");
					string descParse1 = webpage.Substring(webpage.IndexOf("<span itemprop=\"description\"") + 29);
					string descParse2 = descParse1.Substring(0, descParse1.Length - descParse1.Substring(descParse1.IndexOf("</span>")).Length);
					BookDescription = Regex.Replace(Regex.Replace(descParse2, "<.*?>", string.Empty), "&quot;", @"'");
				}
			}
			catch (Exception ex)
			{
				await new MessageDialog("An Error Occured").ShowAsync();
			}
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

		public async void DownloadBookButtonClick(object sender, RoutedEventArgs e)
		{
			await Windows.System.Launcher.LaunchUriAsync(Book.DownloadLink);
		}

		public void FavoriteButtonClick(object sender, RoutedEventArgs e)
		{
			bool found = false;
			foreach (var book in Globals.Favorites)
			{
				if (book.BookNumber == Book.BookNumber)
				{
					Globals.Favorites.Remove(book);
					found = true;
					break;
				}
			}
			if (!found)
			{
				Globals.Favorites.Add(book);
			}
			SetFavoriteText();
			SaveFavorites();
		}

		private void SaveFavorites()
		{
			var fileService = new FileService();
			fileService.WriteFileAsync("favorites.json", Globals.Favorites);
		}

		private TextBlock favoritesButton;

		public void FavoriteButtonLoaded(object sender, RoutedEventArgs e)
		{
			favoritesButton = sender as TextBlock;
			SetFavoriteText();
		}

		private void SetFavoriteText()
		{
			if (Book != null)
			{
				bool found = false;
				foreach (var book in Globals.Favorites)
				{
					if (book.BookNumber == Book.BookNumber && favoritesButton != null)
					{
						favoritesButton.Text = "Remove From Favorites";
						found = true;
						break;
					}
				}
				if (!found && favoritesButton != null)
				{
					favoritesButton.Text = "Add To Favorites";
				}
			}

		}
	}
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TechBookie.Models;
using TechBookie.Services.FileService;
using TechBookie.Views;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.Storage;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace TechBookie.ViewModels
{
	public class MainPageViewModel : ViewModelBase
	{
		public MainPageViewModel()
		{
			if(Windows.ApplicationModel.DesignMode.DesignModeEnabled)
			{
				// DesignTime values
			}
			else
			{
				LoadBooks();
				LoadFavorites();
				AskForRating();
			}
		}

		private async void AskForRating()
		{
			if(Globals.AskForRating && !Globals.Rated)
			{
				var con = new ContentDialog();
				con.Content = "Do you want to Rate our App?";
				con.PrimaryButtonText = "Yes";
				con.SecondaryButtonText = "No";
				con.PrimaryButtonClick += (s, e) => { Rate(); };
				con.SecondaryButtonClick += (s, e) => { con.Hide();  ShowFeedback(); };
				await con.ShowAsync();
				Globals.Rated = true;
			}
		}

		private async void ShowFeedback()
		{
			
			var con1 = new ContentDialog();
			var sp = new StackPanel();
			sp.Children.Add(new TextBlock { Text = "Can you give Feedback Please?" });
			con1.Content = sp;
			con1.PrimaryButtonText = "Send";
			con1.SecondaryButtonText = "Cancel";
			con1.PrimaryButtonClick += (s, e) => { Send(); };
			con1.SecondaryButtonClick += (s, e) => { con1.Hide(); };
			await con1.ShowAsync();
		}

		private async void Send()
		{
			await Windows.System.Launcher.LaunchUriAsync(new Uri(@"mailto:waseemhassan@outlook.com"));
		}

		private async void Rate()
		{
			await Launcher.LaunchUriAsync(new Uri(string.Format("ms-windows-store:REVIEW?PFN={0}", Windows.ApplicationModel.Package.Current.Id.FamilyName)));
		}

		private async void LoadFavorites()
		{
			Globals.Favorites = await new FileService().ReadFileAsync<ObservableCollection<Book>>("favorites.json") ?? new ObservableCollection<Book>();
		}

		public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
		{
			if(state.Any())
			{
				// Get Value
				state.Clear();
			}
			return Task.CompletedTask;
		}

		public override Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending)
		{
			if(suspending)
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

			var books = JsonConvert.DeserializeObject <List<Book>>(fileContents);
			Books = new ObservableCollection<Book>(books);
			LatestBooks = new ObservableCollection<Book>(Books.Reverse().Take(20));
			Globals.AllBooks = Books;
		}

		private ObservableCollection<Book> latestBooks;

		public ObservableCollection<Book> LatestBooks
		{
			get { return latestBooks; }
			set { Set(ref latestBooks, value); }
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
			if(gv.SelectedIndex != -1)
			{
				NavigationService.Navigate(typeof(SingleBook), gv.SelectedItem);
			}
		}

		public void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
		{

		}

	}
}

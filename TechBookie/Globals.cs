using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBookie.Models;

namespace TechBookie
{
	public static class Globals
	{
		public static ObservableCollection<Book> Favorites { get; set; } 
			= new ObservableCollection<Book>();
		public static bool Rated = false;

		public static bool AskForRating = false;

		public static ObservableCollection<Book> AllBooks { get; set; }
	}
}

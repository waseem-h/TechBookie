using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;

namespace TechBookie.Models
{
	public class Book : BindableBase
	{
		private string bookName;

		public string BookName
		{
			get { return bookName; }
			set { Set(ref bookName, value); }
		}

		private Uri downloadLink;

		public Uri DownloadLink
		{
			get { return downloadLink; }
			set { Set(ref downloadLink, value); }
		}

		private int id;

		public int Id
		{
			get { return id; }
			set { Set(ref id, value); }
		}

		private int bookNumber;

		public int BookNumber
		{
			get { return bookNumber; }
			set { Set(ref bookNumber, value); }
		}

		private string bookImageLink;

		public string BookImageLink
		{
			get { return bookImageLink; }
			set { Set(ref bookImageLink, value); }
		}
	}
}

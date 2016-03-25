using System;
using EloBuddy.SDK.Events;

namespace CarryMe_Collection
{
	class Program
	{
		static void Main(string[] args)
		{
			Loading.OnLoadingComplete += Loading_OnLoadingComplete;
		}
		private static void Loading_OnLoadingComplete(EventArgs args)
		{
			new Champions();
		}
	}
}

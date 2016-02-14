using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Janglin.GlassDoor.Api;
using System;

namespace GlassDoorUnitTest
{
	[TestClass]
	public class CompaniesUnitTests
	{
		const string PartnerId = "xxxxx";
		const string Key = "xxxxxxxxxxxxxxxxxxxxx";

		[TestMethod]
		public void GetCompaniesTestMethod()
		{
			var client = new Client(PartnerId, Key);

			var result = client.GetCompanies();

			foreach (var detailedemployer in result)
				System.Diagnostics.Debug.WriteLine(detailedemployer.Name + " " + detailedemployer.NumberOfRatings);
		}
	}
}
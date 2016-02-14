using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Janglin.GlassDoor.Api;
using System;

namespace GlassDoorUnitTest
{
	[TestClass]
	public class JobStatsUnitTests
	{
		const string PartnerId = "xxxxx";
		const string Key = "xxxxxxxxxxxxxxxxxxxxx";

		[TestMethod]
		public void JobStatsQueryPhraseTestMethod()
		{
			var client = new Client(PartnerId, Key);

			var jobstats = client.GetJobsStatsAsync(queryPhrase: "Developer", returnEmployers: true, returnCities: true, returnJobTitles: true, returnStates: true);

			jobstats.Wait();

			var result = jobstats.Result;

			Assert.IsTrue(result.AttributionUrl.StartsWith("http://www.glassdoor.com/"));
			Assert.IsNotNull(result.Employers);
			Assert.IsNotNull(result.JobTitles);
			Assert.IsNotNull(result.States);
			Assert.IsNotNull(result.States.Count);
		}

		[TestMethod]
		public void JobStatsReturnStatesTestMethod()
		{
			var client = new Client(PartnerId, Key);

			var jobstats = client.GetJobsStatsAsync(returnStates: true);

			jobstats.Wait();

			var result = jobstats.Result;

			Assert.IsTrue(result.AttributionUrl.StartsWith("http://www.glassdoor.com/"));
			Assert.IsNull(result.Employers);
			Assert.IsNull(result.JobTitles);
			Assert.IsNotNull(result.States);
			Assert.IsTrue(result.States.Count > 40);
		}

		[TestMethod]
		public void JobStatsReturnCitiesTestMethod()
		{
			var client = new Client(PartnerId, Key);

			var jobstats = client.GetJobsStatsAsync(returnCities: true);

			jobstats.Wait();

			var result = jobstats.Result;

			Assert.IsTrue(result.AttributionUrl.StartsWith("http://www.glassdoor.com/"));
			Assert.IsNull(result.Employers);
			Assert.IsNull(result.JobTitles);
			Assert.IsNull(result.States);
			Assert.IsNotNull(result.Cities);
			Assert.IsTrue(result.Cities.Count() > 500);
		}

		[TestMethod]
		public void JobStatsReturnJobTitlesTestMethod()
		{
			var client = new Client(PartnerId, Key);

			var jobstats = client.GetJobsStatsAsync(returnCities: true);

			jobstats.Wait();

			var result = jobstats.Result;

			//Assert.IsTrue(result.AttributionUrl.StartsWith("http://www.glassdoor.com/"));
			//Assert.IsNull(result.Employers);
			//Assert.IsNull(result.Cities);
			//Assert.IsNull(result.States);
			//Assert.IsNotNull(result.JobTitles);
			//Assert.IsTrue(result.JobTitles.Count() > 10);

			foreach (var city in result.Cities.OrderBy(c=>c.Name))
				System.Diagnostics.Debug.WriteLine(city.Name + " " + city.NumberOfJobs);
		}

		[TestMethod]
		public void JobStatsReturnEmployersTestMethod()
		{
			var client = new Client(PartnerId, Key);

			var jobstats = client.GetJobsStatsAsync(returnEmployers: true);

			jobstats.Wait();

			var result = jobstats.Result;

			Assert.IsTrue(result.AttributionUrl.StartsWith("http://www.glassdoor.com/"));
			Assert.IsNull(result.JobTitles);
			Assert.IsNull(result.Cities);
			Assert.IsNull(result.States);
			Assert.IsNotNull(result.Employers);
			Assert.IsTrue(result.Employers.Count() > 10);
		}

		[TestMethod]
		public void JobStatsEmployerTestMethod()
		{
			var client = new Client(PartnerId, Key);

			var jobstats = client.GetJobsStatsAsync(employer: "IBM", returnEmployers: true);

			jobstats.Wait();

			var result = jobstats.Result;

			Assert.IsTrue(result.AttributionUrl.StartsWith("http://www.glassdoor.com/"));
			Assert.IsNull(result.JobTitles);
			Assert.IsNull(result.Cities);
			Assert.IsNull(result.States);
			Assert.AreEqual(1, result.Employers.Count());
			Assert.AreEqual(303, result.Employers.First().Id);
		}

		[TestMethod]
		public void JobStatsCityTestMethod()
		{
			var client = new Client(PartnerId, Key);

			var jobstats = client.GetJobsStatsAsync(city: 1128808);

			jobstats.Wait();

			var result = jobstats.Result;

			Assert.IsTrue(result.AttributionUrl.StartsWith("http://www.glassdoor.com/"));
			Assert.IsNull(result.JobTitles);
			Assert.IsNull(result.Employers);
			Assert.IsNull(result.States);
			Assert.AreEqual(1, result.Cities.Count());
			Assert.AreEqual(303, result.Cities.First().Id);
		}

		[TestMethod]
		public void JobStatsStateTestMethod()
		{
			var client = new Client(PartnerId, Key);

			var jobstats = client.GetJobsStatsAsync(state: "South Carolina", returnStates: true);

			jobstats.Wait();

			var result = jobstats.Result;

			Assert.IsTrue(result.AttributionUrl.StartsWith("http://www.glassdoor.com/"));
			Assert.IsNull(result.JobTitles);
			Assert.IsNull(result.Employers);
			Assert.IsNull(result.Cities);
			Assert.AreEqual(1, result.States.Count());
			Assert.AreEqual("South Carolina", result.States.First().Key);
		}
	}
}
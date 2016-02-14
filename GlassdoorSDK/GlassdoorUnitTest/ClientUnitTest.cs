using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Janglin.Glassdoor.Api;
using System;

namespace GlassdoorUnitTest
{
	[TestClass]
	public class ClientUnitTest
	{
		const string PartnerId = "43473";
		const string Key = "iuYKOFxTrMe";

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

			var something = jobstats.Result;

			Assert.IsTrue(something.AttributionUrl.StartsWith("http://www.glassdoor.com/"));
			Assert.IsNull(something.Employers);
			Assert.IsNull(something.JobTitles);
			Assert.IsNull(something.States);
			Assert.IsNotNull(something.Cities);
			Assert.IsTrue(something.Cities.Count() > 500);
		}

		[TestMethod]
		public void JobStatsReturnJobTitlesTestMethod()
		{
			var client = new Client(PartnerId, Key);

			var jobstats = client.GetJobsStatsAsync(returnJobTitles: true);

			jobstats.Wait();

			var something = jobstats.Result;

			Assert.IsTrue(something.AttributionUrl.StartsWith("http://www.glassdoor.com/"));
			Assert.IsNull(something.Employers);
			Assert.IsNull(something.Cities);
			Assert.IsNull(something.States);
			Assert.IsNotNull(something.JobTitles);
			Assert.IsTrue(something.JobTitles.Count() > 10);
		}

		[TestMethod]
		public void JobStatsReturnEmployersTestMethod()
		{
			var client = new Client(PartnerId, Key);

			var jobstats = client.GetJobsStatsAsync(returnEmployers: true);

			jobstats.Wait();

			var something = jobstats.Result;

			Assert.IsTrue(something.AttributionUrl.StartsWith("http://www.glassdoor.com/"));
			Assert.IsNull(something.JobTitles);
			Assert.IsNull(something.Cities);
			Assert.IsNull(something.States);
			Assert.IsNotNull(something.Employers);
			Assert.IsTrue(something.Employers.Count() > 10);
		}

		[TestMethod]
		public void JobStatsEmployerTestMethod()
		{
			var client = new Client(PartnerId, Key);

			var jobstats = client.GetJobsStatsAsync(employer: "IBM", returnEmployers: true);

			jobstats.Wait();

			var something = jobstats.Result;

			Assert.IsTrue(something.AttributionUrl.StartsWith("http://www.glassdoor.com/"));
			Assert.IsNull(something.JobTitles);
			Assert.IsNull(something.Cities);
			Assert.IsNull(something.States);
			Assert.AreEqual(1, something.Employers.Count());
			Assert.AreEqual(303, something.Employers.First().Id);
		}

		[TestMethod]
		public void JobStatsCityTestMethod()
		{
			var client = new Client(PartnerId, Key);

			var jobstats = client.GetJobsStatsAsync(city: 1128808);

			jobstats.Wait();

			var something = jobstats.Result;

			Assert.IsTrue(something.AttributionUrl.StartsWith("http://www.glassdoor.com/"));
			Assert.IsNull(something.JobTitles);
			Assert.IsNull(something.Employers);
			Assert.IsNull(something.States);
			Assert.AreEqual(1, something.Cities.Count());
			Assert.AreEqual(303, something.Cities.First().Id);
		}

		[TestMethod]
		public void JobStatsStateTestMethod()
		{
			var client = new Client(PartnerId, Key);

			var jobstats = client.GetJobsStatsAsync(state: "South Carolina", returnStates: true);

			jobstats.Wait();

			var something = jobstats.Result;

			Assert.IsTrue(something.AttributionUrl.StartsWith("http://www.glassdoor.com/"));
			Assert.IsNull(something.JobTitles);
			Assert.IsNull(something.Employers);
			Assert.IsNull(something.Cities);
			Assert.AreEqual(1, something.States.Count());
			Assert.AreEqual("South Carolina", something.States.First().Key);
		}

		[TestMethod]
		public void GlassdoorExceptionTestMethod()
		{
			try
			{
				var client = new Client("", Key);

				var jobstats = client.GetJobsStatsAsync(state: "-1");

				jobstats.Wait();

				var something = jobstats.Result;

				Assert.IsTrue(something.AttributionUrl.StartsWith("http://www.glassdoor.com/"));
				Assert.IsNull(something.JobTitles);
				Assert.IsNull(something.Employers);
				Assert.IsNull(something.Cities);
				Assert.AreEqual(1, something.States.Count());
				Assert.AreEqual(303, something.States.First().Key);
			}
			catch (AggregateException ex)
			{
				var glassdoorexception = ex.InnerException as GlassdoorException;

				if (glassdoorexception != null)
				{
					Assert.AreEqual(false, glassdoorexception.Success);
					Assert.AreEqual("Access-Denied", glassdoorexception.Status);
				}
				else
					Assert.IsNotNull(ex.InnerException);
			}
		}

		[TestMethod]
		public void GlassdoorException2TestMethod()
		{
			try
			{
				var client = new Client(PartnerId, Key);

				var jobstats = client.GetJobsStatsAsync(employer: "-1");

				jobstats.Wait();

				var something = jobstats.Result;

				Assert.IsTrue(something.AttributionUrl.StartsWith("http://www.glassdoor.com/"));
				Assert.IsNull(something.JobTitles);
				Assert.IsNull(something.Employers);
				Assert.IsNull(something.Cities);
				Assert.IsNull(something.States);
			}
			catch (AggregateException ex)
			{
				var glassdoorexception = ex.InnerException as GlassdoorException;

				if (glassdoorexception != null)
				{
					Assert.AreEqual(false, glassdoorexception.Success);
					Assert.AreEqual("Access-Denied", glassdoorexception.Status);
				}
				else
					Assert.IsNotNull(ex.InnerException);
			}
		}

		[TestMethod]
		public void JobsProgressionTestMethod()
		{
			var client = new Client(PartnerId, Key);

			var jobstats = client.GetJobsProgressionAsync(jobTitle:"Technician");

			jobstats.Wait();

			var something = jobstats.Result;

			//Assert.IsTrue(something.AttributionUrl.StartsWith("http://www.glassdoor.com/"));
			//Assert.IsNull(something.Employers);
			//Assert.IsNull(something.JobTitles);
			//Assert.IsNotNull(something.States);
			//Assert.IsTrue(something.States.Count > 40);
		}

        [TestMethod]
        public void CompanySearchAsyncTestMethod()
        {
            var client = new Client(PartnerId, Key);

            var companiestask = client.GetCompaniesAsync(1, 50);
            companiestask.Wait();
            var companies = companiestask.Result;

            foreach (var company in companies)
                System.Diagnostics.Debug.WriteLine(company.Name);
        }

        [TestMethod]
        public void CompanySearchTestMethod()
        {
            var client = new Client(PartnerId, Key);

            var companies = client.GetCompanies();

            foreach (var company in companies)
                System.Diagnostics.Debug.WriteLine(company.Name);
        }
    }
}

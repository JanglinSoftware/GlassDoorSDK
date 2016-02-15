using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Janglin.Glassdoor.Api;
using System;

namespace GlassdoorUnitTest
{
	[TestClass]
	public class ClientUnitTest
	{
		const string PartnerId = "asdf";
		const string Key = "asdf";

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

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Janglin.Glassdoor.Client.Classic;

namespace GlassdoorUnitTest
{
    [TestClass]
    public class ClientUnitTest
    {
        const string PartnerId = "43473";
        const string Key = "iuYKOFxTrMe";

        [TestMethod]
        public void JobStatsEmployerTestMethod()
        {
			var client = new Client(PartnerId, Key);

			var jobstats = client.GetJobsStatsAsync(callback: null,
				queryPhrase: null,
				employer: null,
				location:null,
				city: null,
				state:null,
				country:null,
				fromAgeDays:null,
				jobType:null,
				minRating:null,
				radius:null,
				jobTitle:null,
				jobCategory:null,
				returnCities:null,
				returnStates:true,
				returnJobTitles:null,
				returnEmployers:null,
				admLevelRequested:1
				//userIp:
				//userAgent:
				);

			jobstats.Wait();

			var something = jobstats.Result;
        }
    }
}

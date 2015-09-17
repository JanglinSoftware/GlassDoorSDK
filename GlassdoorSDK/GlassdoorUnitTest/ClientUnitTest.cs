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
        public void JobStatsReturnStatesTestMethod()
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

        [TestMethod]
        public void JobStatsReturnCitiesTestMethod()
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
				returnCities: true,
				returnStates: null,
				returnJobTitles:null,
				returnEmployers:null,
				admLevelRequested:1
				//userIp:
				//userAgent:
				);

			jobstats.Wait();

			var something = jobstats.Result;
        }

        [TestMethod]
        public void JobStatsReturnJobTitlesTestMethod()
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
				returnCities: null,
				returnStates: null,
				returnJobTitles:true,
				returnEmployers:null,
				admLevelRequested:1
				//userIp:
				//userAgent:
				);

			jobstats.Wait();

			var something = jobstats.Result;
        }
 
        [TestMethod]
        public void JobStatsReturnEmployersTestMethod()
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
				returnCities: null,
				returnStates: null,
				returnJobTitles: null,
				returnEmployers: true,
				admLevelRequested: null
				//userIp:
				//userAgent:
				);

			jobstats.Wait();

			var something = jobstats.Result;
        }
 
        [TestMethod]
        public void JobStatsEmployerTestMethod()
        {
			var client = new Client(PartnerId, Key);

			var jobstats = client.GetJobsStatsAsync(callback: null,
				queryPhrase: null,
				employer: 303,
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
				returnCities: true,
				returnStates: true,
				returnJobTitles: true,
				returnEmployers: true,
				admLevelRequested: null
				//userIp:
				//userAgent:
				);

			jobstats.Wait();

			var something = jobstats.Result;
        }
 
        [TestMethod]
        public void JobStatsCityTestMethod()
        {
			var client = new Client(PartnerId, Key);

			var jobstats = client.GetJobsStatsAsync(callback: null,
				queryPhrase: null,
				employer: null,
				location:null,
				city: 1132348,
				state:null,
				country:null,
				fromAgeDays:null,
				jobType:null,
				minRating:null,
				radius:null,
				jobTitle:null,
				jobCategory:null,
				returnCities: true,
				returnStates: true,
				returnJobTitles: true,
				returnEmployers: true,
				admLevelRequested: null
				//userIp:
				//userAgent:
				);

			jobstats.Wait();

			var something = jobstats.Result;
        }
   }
}

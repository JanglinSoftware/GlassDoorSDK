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
        public void JobStatsTestMethod()
        {
			var client = new Client(PartnerId, Key);

			var jobstats = client.GetJobs(
				null, 
				null, 
				null, 
				null, 
				null, 
				null, 
				null, 
				null, 
				null,
				null,
				null, 
				null, 
				null, 
				null, 
				null, 
				null, 
				null, 
				null);

			var something = jobstats.Test;
        }
    }
}

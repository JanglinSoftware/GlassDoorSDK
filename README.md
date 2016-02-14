# GlassDoor .NET SDK
A .NET-based SDK for the GlassDoor API which separates HTTP request overhead from business logic and front end formatting.
Intended to become a NuGet package.

Hello World Sample:

      // Get your partnerid and key from GlassDoor
			var client = new Client(PartnerId, Key);

      // The methods all tend to have large parameter lists with most parameters having default (usually null) values,
      // So we recommend using named parameter syntax.
			var jobstats = client.GetJobsStatsAsync(returnStates: true);
      
      // Make sure that you specify what information you want returned. If you don't ask for Employer or City information,
      // nothing will be returned.
			var developerjobstats = client.GetJobsStatsAsync(queryPhrase: "Developer", 
			    returnEmployers: true, 
			    returnCities: true, 
			    returnJobTitles: true, 
			    returnStates: true);

      // Do other work here.
      
      // All calls are asychronous, so either call them in an async method, or wait for the task result.
			jobstats.Wait();
      developerjobstats.Wait();
      
			var result = jobstats.Result;

			foreach (var state in result.States)
				System.Diagnostics.Debug.WriteLine(state.Value.Name + " " + state.Value.NumberOfJobs);


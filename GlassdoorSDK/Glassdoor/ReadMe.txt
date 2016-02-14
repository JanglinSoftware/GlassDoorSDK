GlassDoor .NET SDK

A .NET-based SDK for the GlassDoor API which separates HTTP request overhead from business logic and front end formatting.
Optimized for application development, the creation of URLs, HTTP Requests, managing of paginated responses and even HTTP
exceptions are all managed by this SDK so you can get on with your XAML based app development.

Hello World Sample:

	////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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

	// Depagination

	// Some calls are not asynchronous as they are designed to handle multiple calls to request data that has been 
	// paginated by the API. You can specify a page size (or leave it blank to get the default 1000 record page size)
	// and the enumerator will make as many calls to the API sequentially returning the pages concatenated into a single
	// collection.
	var result = client.GetCompanies(pageSize: 1000);

	foreach (var detailedemployer in result)
		System.Diagnostics.Debug.WriteLine(detailedemployer.Name + " " + detailedemployer.NumberOfRatings);

	////////////////////////////////////////////////////////////////////////////////////////////////////////////////


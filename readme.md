# Crunchbase v3 C# API

C# API wrapper for [CrunchBase API](http://data.crunchbase.com/) version 3. 
The models are Entity Data Models and can immediately be leveraged for Code First Migrations in Entity Framework.
The APIs are also async.

## Installation

* Download
* Add project as a reference 
* Build

## Usage

```
var crunchBase = new CrunchBase("<API_TOKEN>")

do
{
	var tuple = crunchBase.GetOrganizationsAsync().Result;
	var organizationSummaryList = tuple.Item1;
	var paging = tuple.Item2;
	nextPage = paging.SelectToken("next_page_url").ToString();

	foreach (var organizationSummary in organizationSummaryList)
	{
		var organization = crunchBase.GetOrganizationAsync(organizationSummary.Permalink).Result;

		// Your code here.
	}
} while (!String.IsNullOrEmpty(nextPage));
```

## Caveats

* Several of the models are still to be implemented. Feel free to send a PR if you would like to add more :)

## License
Copyright (c) Microsoft Corporation, licensed under [The MIT License (MIT)](https://github.com/jpoon/crunchbase/blob/master/LICENSE).

Markit
======

C# implementation of Markit Data APIs

## References
- http://dev.markitondemand.com/

## Example
### Client
	using (var client = new MarkitClient()) {
		var companies = await client.GetCompanyAsync("MSFT");
		var quote = await client.GetQuoteAsync("MSFT");
		var timeseries = await client.GetTimeseriesAsync("MSFT", 10);	
	}
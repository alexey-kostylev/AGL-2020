# AGL-2020

a test for AGL.

Test requirements: http://agl-developer-test.azurewebsites.net/

The solution is implemented in ASP.NET Core 2.2 API. It contains a single endpoint that returns an html list of cat names along with a gender of their owner:
Male
	Angel
	Molly
	Tigger
Female
	Gizmo
	Jasper
	
The project consumes an external API to get people.json as specifiedf in the spec:	http://agl-developer-test.azurewebsites.net/people.json
The solution has an XUnit unit test project to test the functionality.
	
To run the test, open the solution in VS2017 and hit F5. A new window will open by url https://localhost:44351/api/people/cats with test results.

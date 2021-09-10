# AGL-2020

a test for AGL.

## Test [requirements](http://agl-developer-test.azurewebsites.net):

Programming challenge
A json web service has been set up at the url: http://agl-developer-test.azurewebsites.net/people.json

You need to write some code to consume the json and output a list of all the cats in alphabetical order under a heading of the gender of their owner.

You can write it in any language you like. You can use any libraries/frameworks/SDKs you choose.

Example:
Male
Angel
Molly
Tigger
Female
Gizmo
Jasper
Notes
Submissions will only be accepted via github or bitbucket
Use industry best practices
Use the code to showcase your skill.

## Implementation
The solution is implemented in ASP.NET Core 2.2 API. It contains a single endpoint that returns an html list of cat names along with a gender of their owner:
<h5>Male</h5>
<ul>
  <li>Angel</li>
  <li>Molly</li>
  <li>Tigger</li>
</ul>
<h5>Female</h5>
<ul>
  <li>Gizmo</li>
  <li>Jasper</li>
</ul>
	
The project consumes an external API to get people.json as specifiedf in the spec:	http://agl-developer-test.azurewebsites.net/people.json
The solution has an XUnit unit test project to test the functionality.
	
To run the test, open the solution in VS2017 and hit F5. A new window will open by url https://localhost:44351/api/people/cats with test results.

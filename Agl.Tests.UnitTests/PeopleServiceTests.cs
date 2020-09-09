using Agl.Api.Models;
using Agl.Api.Services;
using Agl.Api.Services.Implementation;
using Agl.Tests.UnitTests.Properties;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Agl.Tests.UnitTests
{
    public class PeopleServiceTests : TestBase
    {
        private readonly Mock<IDataService> _dataServiceMock = new Mock<IDataService>();

        private string _peopleJson = Properties.Resources.people;

        private ICollection<Person> _people;

        public PeopleServiceTests()
        {
            _people = Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<Person>>(_peopleJson);
        }

        private PeopleService CreateService()
        {
            return new PeopleService(_dataServiceMock.Object);
        }

        [Fact]
        public async Task ShouldGetPetsByGender()
        {
            _dataServiceMock.Setup(x => x.GetPeopleAsync())
                .ReturnsAsync(() => _people);

            var service = CreateService();

            var response = await service.GetCatsByGender();

            var catsByMen = response.Single(x => x.Gender == Gender.Male).CatNames;
            catsByMen.Should().BeEquivalentTo(new[] { "Garfield", "Jim", "Max", "Tom" });
            string.Join(',', catsByMen).Should().Be("Garfield,Jim,Max,Tom", "cats should be in alphabetical order");

            var catsByWomen = response.Single(x => x.Gender == Gender.Female).CatNames;
            catsByWomen.Should().BeEquivalentTo(new[] { "Garfield", "Tabby", "Simba" });
            string.Join(',', catsByWomen).Should().Be("Garfield,Simba,Tabby", "cats should be in alphabetical order");
        }
    }
}

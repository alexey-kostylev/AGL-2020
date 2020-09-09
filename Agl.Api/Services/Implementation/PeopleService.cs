using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agl.Api.Models;
using Agl.Api.ViewModels;

namespace Agl.Api.Services.Implementation
{
    public class PeopleService : IPeopleService
    {
        private readonly IDataService _dataService;

        public PeopleService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<ICollection<PetByGenderViewModel>> GetCatsByGender()
        {
            var data = await _dataService.GetPeopleAsync();

            if (data == null)
            {
                throw new NullReferenceException(nameof(data));
            }

            var model = data
                .Where(person => person.Pets?.Any() == true)
                .SelectMany(person => person.Pets
                    .Where(pet => pet.Type == PetType.Cat)?
                    .Select(pet => (gender: person.Gender, name: pet.Name)))
                .ToArray();

            return model.GroupBy(k => k.gender, v => v.name).Select(x => new PetByGenderViewModel
            {
                Gender = x.Key, CatNames = x.OrderBy(cat => cat).ToList()
            }).ToList();
        }
    }
}

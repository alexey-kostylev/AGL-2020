using Agl.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agl.Api.Services
{
    public interface IPeopleService
    {
        Task<ICollection<PetByGenderViewModel>> GetCatsByGender();
    }
}

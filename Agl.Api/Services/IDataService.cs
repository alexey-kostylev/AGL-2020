using Agl.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agl.Api.Services
{
    public interface IDataService
    {
        Task<ICollection<Person>> GetPeopleAsync();
    }
}

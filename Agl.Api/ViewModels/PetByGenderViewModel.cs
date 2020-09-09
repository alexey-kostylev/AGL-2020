using Agl.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agl.Api.ViewModels
{
    public class PetByGenderViewModel
    {
        public Gender Gender { get; set; }
        public ICollection<string> CatNames { get; set; }
    }
}

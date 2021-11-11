using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public class CompoundForCreationDto
    {
        [Required]
        public string Name { get; set; }

        public string MolecularFormula { get; set; }

    }
}

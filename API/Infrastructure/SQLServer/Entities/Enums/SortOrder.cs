using System.ComponentModel.DataAnnotations;

namespace Entities.Enums
{
    public enum SortOrder
    {
        [Display(Name = "descending")]
        Descending,

        [Display(Name = "ascending")]
        Ascending
    }
}

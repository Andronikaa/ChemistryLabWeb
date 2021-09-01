using System.ComponentModel.DataAnnotations;

namespace MongoDbBased.API.Models
{
    public enum CompoundName
    {
        [Display(Name = "Węglowodory")]
        Węglowodory,
        
        [Display(Name = "Hydroksylowe pochodne węglowodorów")]
        Hydroksylowe_Pochodne_Węglowodorów
    }
}

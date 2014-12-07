using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Forms.Repository
{
    public static class CountriesRepository
    {
        public static readonly ICollection<string> Countries =
            new Collection<string> {"Russia", "Belarus", "Ukraine"};
    }
}
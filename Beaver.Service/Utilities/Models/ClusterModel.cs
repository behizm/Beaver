using System.Collections.Generic;

namespace Beaver.Service.Utilities.Models
{
    public class Cluster<T>
    {
        public IEnumerable<T> List { get; set; }

        public int CountAll { get; set; }
    }
}

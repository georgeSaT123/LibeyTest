using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Domain
{
    public class Region
    {
        public string RegionCode { get; private set; }
        public string RegionDescription { get; private set; }

        public Region(string regionCode, string regionDescription)
        {
            RegionCode = regionCode;
            RegionDescription = regionDescription;
        }
    }
}

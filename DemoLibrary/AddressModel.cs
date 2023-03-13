using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class AddressModel
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }

        public string FullAddressValue() => $"{StreetAddress}, {City}, {County}, {PostCode}";
    }
}

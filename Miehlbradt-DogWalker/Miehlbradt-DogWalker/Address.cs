using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker
{
    public class Address
    {
        #region private attributes
        private string _street;
        private string _number;
        private int _zipcode;
        private string _locality;
        private int zipcodeComplement;
        #endregion private attributes

        #region public methods
        public Address(string street, string number)
        {
            _street = street;
            _number = number;
        }

        public void SetZipcode(int zipcode)
        {
            _zipcode = zipcode;
        }

        public void SetLocality(string locality)
        {
            _locality = locality;
        }

        public string ToString()
        {
            throw new NotImplementedException();
        }
        #endregion public methods
    }
}

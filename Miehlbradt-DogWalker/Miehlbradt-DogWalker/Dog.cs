using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker
{
    public class Dog
    {
        #region private attributes
        private string _noun;
        private DateOnly _birthdate;
        private string _breed;
        private Address _address;
        #endregion private attributes

        #region public methods
        public Dog(string noun, DateOnly birthdate, string breed)
        {
            _noun = noun;
            _birthdate = birthdate;
            _breed = breed;
        }

        public string Noun
        {
            get
            {
                return _noun;
            }
        }

        public DateOnly Birthdate
        {
            get
            {
                return _birthdate;
            }
        }

        public Address Address
        {
            set
            {
                _address = value;
            }
        }

        public string ToString()
        {
            throw new NotImplementedException();
        }
        #endregion public methods
    }
}
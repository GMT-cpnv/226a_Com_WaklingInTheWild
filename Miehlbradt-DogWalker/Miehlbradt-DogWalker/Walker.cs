using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker
{
    public class Walker
    {
        #region private attributes
        private string _fullname;
        private DateOnly _birthdate;
        private List<Dog> _dogs;
        #endregion private attributes

        #region public methods
        public Walker(string fullname, DateOnly birthdate)
        {
            _fullname = fullname;
            _birthdate = birthdate;
        }

        public bool IsAdult()
        {
            throw new NotImplementedException();
        }

        public void AddDog(Dog dog)
        {
            _dogs.Add(dog);
        }

        public List<Dog> Dogs
        {
            get
            {
                return _dogs;
            }
        }
        #endregion public methods

        #region private methods
        private List<Dog> GetOldDogs(int minAge)
        {
            throw new NotImplementedException();
        }
        #endregion private methods
    }
}

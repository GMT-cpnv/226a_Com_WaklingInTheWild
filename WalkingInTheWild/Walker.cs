namespace WalkingInTheWild
{
    public class Walker
    {
        #region private attributes
        private string _pseudo;
        private Bagpack? _bagpack = null;
        #endregion private attributes

        #region public methods
        public Walker(string pseudo)
        {
            _pseudo = pseudo;
        }

        public string Pseudo
        {
            get
            {
                return _pseudo;
            }
        }

        public Bagpack? Bagpack
        {
            get
            {
                return _bagpack;
            }
        }

        public void TakeBagpack(Bagpack bagpack)
        {
            if (_bagpack != null) throw new WalkerAlreadyCarriesABagpackException();
            _bagpack = bagpack;
        }

        public void DropBagpack()
        {
            if (_bagpack == null) throw new WalkerDoesntCarryABagpackException();
            _bagpack = null;
        }

        public void LoadBagpack(List<Cloth> cloths)
        {
            if (_bagpack == null) throw new WalkerDoesntCarryABagpackException();
            foreach (Cloth clothToAdd in cloths)
            {
                _bagpack.Add(clothToAdd);
            }
        }

        public void LoadBagpack(List<Equipment> equipments)
        {
            if (_bagpack == null) throw new WalkerDoesntCarryABagpackException();
            foreach (Equipment equipmentToAdd in equipments)
            {
                _bagpack.Add(equipmentToAdd);
            }
        }

        public void EmptyBagpack()
        {
            if (_bagpack.Equipments.Count == 0 && _bagpack.Clothes.Count == 0) throw new EmptyBagpackException();
            _bagpack.Equipments.RemoveAll(x => x != null);
            _bagpack.Clothes.RemoveAll(x => x != null);
        }
        #endregion public methods

        #region private methods
        #endregion private methods

        #region nested classes
        public class WalkerException:Exception{}
        public class WalkerAlreadyCarriesABagpackException : Exception { }
        public class WalkerDoesntCarryABagpackException : Exception { }
        public class EmptyBagpackException : WalkerException { }
        #endregion nested classes
    }
}
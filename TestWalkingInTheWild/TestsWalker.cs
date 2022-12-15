using WalkingInTheWild;
using static WalkingInTheWild.Cloth;
using static WalkingInTheWild.Walker;

namespace TestWalkingInTheWild
{
    public class TestsWalker
    {
        //region private attributes
        private Walker _walker;
        private string _pseudo;
        private Bagpack _bagpack = null;
        private float _maxLoad = 25.50f;
        //endregion private attributes

        [SetUp]
        public void Setup()
        {
            _pseudo = "Pseudo";
            _walker = new Walker(_pseudo);
            _bagpack = new Bagpack(_maxLoad);
        }

        [Test]
        public void Properties_AfterInstantiationDefaultValues_PropertiesAreCorrecltyReturned()
        {
            //given
            //refer to Setup()

            //when
            //constructor is called in Setup() 

            //then
            Assert.AreEqual(_pseudo, _walker.Pseudo);
            Assert.IsNull(_walker.Bagpack);
        }

        [Test]
        public void TakeBagpack_WalkerDoesntCarryABagpack_BagpackTaken()
        {
            //given
            //refer to Setup()
            Assert.Null(_walker.Bagpack);

            //when
            _walker.TakeBagpack(_bagpack);

            //then
            Assert.AreEqual(_bagpack, _walker.Bagpack);
        }

        [Test]
        public void TakeBagpack_WalkerAlreadyCarriesABagpack_ThrowException()
        {
            //given
            //refer to Setup()
            _walker.TakeBagpack(_bagpack);
            Assert.NotNull(_walker.Bagpack);

            //when
            //Event is called by the assertion

            //then
            Assert.Throws<WalkerAlreadyCarriesABagpackException>(() => _walker.TakeBagpack(_bagpack));
        }

        [Test]        
        public void DropBagpack_WalkerIsAlreadyCarringABagpack_WalkerDropsTheBagpack()
        {
            //given
            _walker.TakeBagpack(_bagpack);
            Assert.NotNull(_walker.Bagpack);

            //when
            _walker.DropBagpack();

            //then
            Assert.IsNull(_walker.Bagpack);
        }

        [Test]
        public void DropBagpack_WalkerIsNotCarringABagpack_ThrowException()
        {
            //given
            Assert.Null(_walker.Bagpack);

            //when
            //Event is called by the assertion

            //then
            Assert.Throws<WalkerDoesntCarryABagpackException>(() => _walker.DropBagpack());
        }

        [Test]
        public void LoadBagpack_BagpackAvailableLoadSingleCloth_ClothIsLoadedInBagpack()
        {
            //given
            _walker.TakeBagpack(_bagpack);
            Assert.NotNull(_walker.Bagpack);
            Assert.AreEqual(0, _walker.Bagpack.Clothes.Count);
            Assert.AreEqual(_maxLoad, _walker.Bagpack.RemainingLoadCapacity);

            //when
            _walker.LoadBagpack(Utils.GenerateClothes(1));

            //then
            Assert.AreEqual(1, _walker.Bagpack.Clothes.Count);
            Assert.AreEqual(_maxLoad, _walker.Bagpack.RemainingLoadCapacity);
        }

        [Test]
        public void LoadBagpack_BagpackAvailableLoadMultipleCloths_ClothsAreLoadedInBagpack()
        {
            //given
            _walker.TakeBagpack(_bagpack);
            Assert.NotNull(_walker.Bagpack);
            Assert.AreEqual(0, _walker.Bagpack.Clothes.Count);
            Assert.AreEqual(_maxLoad, _walker.Bagpack.RemainingLoadCapacity);

            //when
            _walker.LoadBagpack(Utils.GenerateClothes(10));

            //then
            Assert.AreEqual(10, _walker.Bagpack.Clothes.Count);
            Assert.AreEqual(_maxLoad, _walker.Bagpack.RemainingLoadCapacity);
        }

        [Test]
        public void LoadBagpack_ClothBagpackNotAvailable_ThrowException()
        {
            //given
            Assert.Null(_walker.Bagpack);

            //when
            //Event is called by the assertion

            //then
            Assert.Throws<WalkerDoesntCarryABagpackException>(() => _walker.LoadBagpack(Utils.GenerateClothes(1)));
        }

        [Test]
        public void LoadBagpack_BagpackAvailableLoadSingleEquipment_EquipmentIsLoadedInBagpack()
        {
            //given
            _walker.TakeBagpack(_bagpack);
            Assert.NotNull(_walker.Bagpack);
            Assert.AreEqual(0, _walker.Bagpack.Equipments.Count);
            Assert.AreEqual(_maxLoad, _walker.Bagpack.RemainingLoadCapacity);

            //when
            _walker.LoadBagpack(Utils.GenerateEquipment(1));

            //then
            Assert.AreEqual(1, _walker.Bagpack.Equipments.Count);
            Assert.AreEqual(_maxLoad-1, _walker.Bagpack.RemainingLoadCapacity);
        }

        [Test]
        public void LoadBagpack_BagpackAvailableLoadMultipleEquipments_EquipmentAreLoadedInBagpack()
        {
            //given
            _walker.TakeBagpack(_bagpack);
            Assert.NotNull(_walker.Bagpack);
            Assert.AreEqual(0, _walker.Bagpack.Equipments.Count);
            Assert.AreEqual(_maxLoad, _walker.Bagpack.RemainingLoadCapacity);

            //when
            _walker.LoadBagpack(Utils.GenerateEquipment(10));

            //then
            Assert.AreEqual(1, _walker.Bagpack.Equipments.Count);
            Assert.AreEqual(_maxLoad - 55, _walker.Bagpack.RemainingLoadCapacity);
        }
    }
}
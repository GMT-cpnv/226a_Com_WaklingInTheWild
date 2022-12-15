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
            //refer to Setup()
            Bagpack bagpack = new Bagpack(20.00f);
            _walker.TakeBagpack(bagpack);
            Assert.NotNull(_walker.Bagpack);
            List<Cloth> clothes = Utils.GenerateClothes(1);

            //when
            _walker.LoadBagpack(clothes);

            //then
            Assert.That(this._walker.Bagpack.Clothes.Count, Is.EqualTo(1));
        }

        [Test]
        public void LoadBagpack_BagpackAvailableLoadMultipleCloths_ClothsAreLoadedInBagpack()
        {
            //given
            //refer to Setup()
            Bagpack bagpack = new Bagpack(20.00f);
            _walker.TakeBagpack(bagpack);
            Assert.NotNull(_walker.Bagpack);
            List<Cloth> clothes = Utils.GenerateClothes(4);

            //when
            _walker.LoadBagpack(clothes);

            //then
            Assert.That(_walker.Bagpack.Clothes.Count, Is.EqualTo(4));
        }

        [Test]
        public void LoadBagpack_ClothBagpackNotAvailable_ThrowException()
        {
            //given
            //refer to Setup()
            Assert.Null(_walker.Bagpack);
            List<Cloth> clothes = Utils.GenerateClothes(4);

            //when
            //Event is called by the assertion

            //then
            Assert.Throws<WalkerDoesntCarryABagpackException>(() => _walker.LoadBagpack(clothes));
        }

        [Test]
        public void LoadBagpack_BagpackAvailableLoadSingleEquipment_EquipmentIsLoadedInBagpack()
        {
            //given
            //refer to Setup()
            Bagpack bagpack = new Bagpack(20.00f);
            _walker.TakeBagpack(bagpack);
            Assert.NotNull(_walker.Bagpack);
            List<Equipment> equipments = Utils.GenerateEquipment(1);

            //when
            _walker.LoadBagpack(equipments);

            //then
            Assert.That(_walker.Bagpack.Equipments.Count, Is.EqualTo(1));
        }

        [Test]
        public void LoadBagpack_BagpackAvailableLoadMultipleEquipments_EquipmentAreLoadedInBagpack()
        {
            //given
            //refer to Setup()
            Bagpack bagpack = new Bagpack(20.00f);
            _walker.TakeBagpack(bagpack);
            Assert.NotNull(_walker.Bagpack);
            List<Equipment> equipments = Utils.GenerateEquipment(4);

            //when
            _walker.LoadBagpack(equipments);

            //then
            Assert.That(_walker.Bagpack.Equipments.Count, Is.EqualTo(4));
        }

        [Test]
        public void LoadBagpack_EquipmentBagpackNotAvailable_ThrowException()
        {
            //given
            //refer to Setup()
            Assert.Null(_walker.Bagpack);
            List<Equipment> equipments = Utils.GenerateEquipment(4);

            //when
            //Event is called by the assertion

            //then
            Assert.Throws<WalkerDoesntCarryABagpackException>(() => _walker.LoadBagpack(equipments));
        }

        [Test]
        public void EmptyBagpack_BagpackContainsClothsAndEquipment_BackpackIsEmpty()
        {
            //given
            //refer to Setup()
            Bagpack bagpack = new Bagpack(20.00f);
            _walker.TakeBagpack(bagpack);
            Assert.NotNull(_walker.Bagpack);
            List<Equipment> equipments = Utils.GenerateEquipment(4);
            List<Cloth> clothes = Utils.GenerateClothes(1);
            _walker.LoadBagpack(equipments);
            _walker.LoadBagpack(clothes);

            //when
            _walker.EmptyBagpack();

            //then
            Assert.That(_walker.Bagpack.Equipments.Count, Is.EqualTo(0));
            Assert.That(_walker.Bagpack.Clothes.Count, Is.EqualTo(0));
        }

        [Test]
        public void EmptyBagpack_BagpackDoesntContainNeitherClothsOrEquipment_ThrowException()
        {
            //given
            //refer to Setup()
            Bagpack bagpack = new Bagpack(20.00f);
            _walker.TakeBagpack(bagpack);
            Assert.NotNull(_walker.Bagpack);

            //when
            //Event is called by the assertion

            //then
            Assert.Throws<EmptyBagpackException>(() => _walker.EmptyBagpack());
        }
    }
}
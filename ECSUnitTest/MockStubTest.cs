using System;
using NUnit.Framework;
using ECSNew;
using NSubstitute;

namespace ECSUnitTest
{
    [TestFixture]
    public class MockStubTest
    {
        private int _thr;
        private FakeSensor25deg _fakeSensor;
        private FakeHeater _fakeHeater;

        //private IHeater _fakeHeater1;

        private ECS UUT;


        [SetUp]
        public void Setup()
        {
            _thr = 35;
            _fakeHeater = new FakeHeater();
            _fakeSensor = new FakeSensor25deg();

            //_fakeHeater1 = Substitute.For<IHeater>();

            UUT = new ECS(_thr,_fakeSensor,_fakeHeater);
        }


        [Test]
        public void Test_TurnOn_Called_1()
        {
            UUT.Regulate();

            Assert.That(_fakeHeater.TurnedOn, Is.EqualTo(1));
        }
    }

    //Stub
    public class FakeSensor25deg : ISensor
    {
        //public int testRun { get; private set; }

        public FakeSensor25deg()
        {
            //testRun = 0;
        }

        public int GetTemp()
        {
            return 25;
        }

        public bool RunSelfTest()
        {
            //testRun++;
            return true;
        }
    }


    //Mock
    public class FakeHeater : IHeater
    {
        public int TurnedOn { get; private set; }
        public int TurnedOff { get; private set; }
        public int TestRun { get; private set; }

        public FakeHeater()
        {
            TurnedOn = 0;
            TurnedOff = 0;
            TestRun = 0;
        }

        public void TurnOn()
        {
            TurnedOn++;
        }

        public void TurnOff()
        {
            TurnedOff++;
        }

        public bool RunSelfTest()
        {
            TestRun++;
            return true;
        }
    }
}

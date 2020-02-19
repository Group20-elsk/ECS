using System;
using NUnit.Framework;
using ECSNew;

namespace ECSUnitTest
{
    [TestFixture]
    public class UnitTest1
    {
        private int _thr;
        private ISensor _fakeSensor;
        private IHeater _fakeHeater;
        private ECS UUT;


        [SetUp]
        public void Setup()
        {
            _thr = 1;
            _fakeHeater = new FakeHeater();
            _fakeSensor = new FakeSensor25deg();
            UUT = new ECS(_thr,_fakeSensor,_fakeHeater);
        }


        [Test]
        public void TestMethod1()
        {
            
        }
    }

    public class FakeSensor25deg : ISensor
    {
        public int testRun { get; private set; }

        public FakeSensor25deg()
        {
            testRun = 0;
        }

        public int GetTemp()
        {
            return 25;
        }

        public bool RunSelfTest()
        {
            testRun++;
            return true;
        }
    }

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

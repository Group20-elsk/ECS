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
            _fakeSensor = new FakeSensor1();
            UUT = new ECS(_thr,_fakeSensor,_fakeHeater);
        }


        [Test]
        public void TestMethod1()
        {
            
        }
    }

    public class FakeSensor1 : ISensor
    {
        public int GetTemp()
        {
            throw new NotImplementedException();
        }

        public bool RunSelfTest()
        {
            throw new NotImplementedException();
        }
    }

    public class FakeHeater : IHeater
    {
        public void TurnOn()
        {
            throw new NotImplementedException();
        }

        public void TurnOff()
        {
            throw new NotImplementedException();
        }

        public bool RunSelfTest()
        {
            throw new NotImplementedException();
        }
    }
}

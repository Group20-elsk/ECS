using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECSNew;
using NSubstitute;
using NUnit.Framework;

namespace ECSUnitTest
{
    public class SubstituteTest
    {
        public class UnitTest1
        {
            private int _thr;
            private ISensor _fakeSensor;
            private IHeater _fakeHeater;
            private ECS UUT;


            [SetUp]
            public void Setup()
            {
                _thr = 25;
                _fakeSensor = Substitute.For<ISensor>(); //Create substitute, indeholder inddirekte "new" 
                _fakeHeater = Substitute.For<IHeater>();

                UUT = new ECS(_thr, _fakeSensor, _fakeHeater);
            }


            [Test]
            public void TestWithSub()//Da vi asserter på en mock er det en interaction-based test
            {
                //setup
                _fakeSensor.GetTemp().Returns(20);//fakeSensor fungerer som stub i denne test

                //Act
                UUT.Regulate();

                //Assert
                _fakeHeater.Received(1).TurnOn();//fakeHeater fungerer som en mock i denne test
            }

            [TestCase(1,1)]
            [TestCase(4,4)]
            [TestCase(-10,-10)]
            public void TestWith(int th, int result)//State based test
            {
                //setup
                UUT.SetThreshold(th);

                //Act
                int threshold = UUT.GetThreshold();

                //Assert
                Assert.That(threshold,Is.EqualTo(result));
            }

        }
    }
}

using System;
using MyQueue;
using NUnit.Framework;

namespace NUnitTestMyQueueExpectedException
{
    [TestFixture]
    public class NUnitTestMyQueue
    {
        static MyQueue<string> myCollection = new MyQueue<string>();

        [SetUp]
        public static void SetUp_Tests_Method()
        {
            myCollection = new MyQueue<string>();
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Create_New_MyQueue_with_capacity_lower0()
        {
            MyQueue<string> myCollection = new MyQueue<string>(-5);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_when_count_equals0()
        {
            MyQueue<string> myCollection = new MyQueue<string>();

            myCollection.Dequeue();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_when_count_equals0()
        {
            MyQueue<string> myCollection = new MyQueue<string>();

            myCollection.Peek();
        }

        [TearDown]
        public static void Tear_Down_Test_Method()
        {
            myCollection = null;
        }
    }
}

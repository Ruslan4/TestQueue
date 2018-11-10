using System;
using NUnit.Framework;
using MyQueue;
using System.Collections.Generic;

namespace TestMyQueueAddNewItems
{
    [TestFixture]
    public class TestMyQueue_Add_Clear
    {
        static MyQueue<string> myCollection = new MyQueue<string>();

        [SetUp]
        public static void SetUp_Tests_Method()
        {
            myCollection = new MyQueue<string>();
        }

        [Test]
        public static void Adding_New_Element_To_UserQueue()
        {
            myCollection.Enqueue("First");
            myCollection.Enqueue("Second");
            myCollection.Enqueue("Theerd");

            Assert.AreEqual(3, myCollection.Count);
        }

        [Test]
        public static void Dequeue_1Element_From_UserQueue_Return2()
        {
            //arrange 
            myCollection.Enqueue("First");
            myCollection.Enqueue("Second");
            myCollection.Enqueue("Theerd");

            //act
            myCollection.Dequeue();

            //assert
            Assert.AreEqual(2, myCollection.Count);
        }

        [Test]
        public static void Remove_All_Element_From_UserQueue_Return_0()
        {
            //arrange 
            myCollection.Enqueue("First");
            myCollection.Enqueue("Second");
            myCollection.Enqueue("Third");

            //act
            myCollection.Clear();

            //assert
            Assert.AreEqual(0, myCollection.Count);
        }

        [TearDown]
        public static void Tear_Down_Test_Method()
        {
            myCollection = null;
        }
    }
}

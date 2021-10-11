using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Business.Tests
{
    public class MyStackTests
    {
        MyStack<int> stack;

        [SetUp]
        public void SetUp()
        {
            stack = new MyStack<int>();
        }
        [Test]
        public void IsEmpty_EmptyStack_ReturnsTrue()
        {
            Assert.IsTrue(stack.IsEmpty);
        }

        [Test]
        public void Count_PushOneItem_ReturnsOne()
        {
            stack.Push(1);
            Assert.AreEqual(1, stack.Count);
            Assert.IsFalse(stack.IsEmpty);            
        }

        [Test]
        public void Pop_EmptyStack_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public void Peek_PushTwoITems_ReturnsHeadItem()
        {
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(2, stack.Peek());
        }
        [Test]
        public void Peek_PushTwoITemsPopOne_ReturnsHeadItem()
        {
            stack.Push(1);
            stack.Push(2);
            stack.Pop();

            Assert.AreEqual(1, stack.Peek());
        }
    }
}

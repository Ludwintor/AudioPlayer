using System;
using System.Linq;
using NUnit.Framework;

namespace Collections.Tests
{
    public class LinkedListTests
    {
        [Test]
        public void Test_AppendFirst()
        {
            LinkedList<int?> list = new();
            list.AppendFirst(55);
            list.AppendFirst(null);
            list.AppendFirst(101);
            int?[] expected = { 101, null, 55 };
            Assert.True(expected.SequenceEqual(list));
        }

        [Test]
        public void Test_AppendLast()
        {
            LinkedList<int?> list = new();
            list.AppendLast(null);
            list.AppendLast(4912);
            list.AppendLast(42);
            int?[] expected = { null, 4912, 42 };
            Assert.True(expected.SequenceEqual(list));
        }

        [Test]
        public void Test_GetFirstNode_NotNull()
        {
            LinkedList<int?> list = new();
            list.Add(999);
            list.Add(null);
            list.Add(2);
            Assert.NotNull(list.First);
            Assert.AreEqual(999, list.First!.Value);
        }

        [Test]
        public void Test_GetFirstNode_IsNull()
        {
            LinkedList<int?> list = new();
            Assert.Null(list.First);
        }

        [Test]
        public void Test_GetLastNode_NotNull()
        {
            LinkedList<int?> list = new();
            list.Add(999);
            list.Add(null);
            list.Add(2);
            Assert.NotNull(list.Last);
            Assert.AreEqual(2, list.Last!.Value);
        }

        [Test]
        public void Test_GetLastNode_IsNull()
        {
            LinkedList<int?> list = new();
            Assert.Null(list.Last);
        }

        [Test]
        public void Test_Count()
        {
            LinkedList<int?> list = new();
            Assert.AreEqual(0, list.Count, "Count must be zero in the empty list");
            list.Add(42);
            list.Add(999);
            list.Add(322);
            list.Add(null);
            Assert.AreEqual(4, list.Count, "List count isn't matches with actual objects count in the list");
        }

        [Test]
        public void Test_Clear()
        {
            LinkedList<int?> list = new() { 1, 2, 3, 4, 5, 6, 7 };
            list.Clear();
            Assert.Zero(list.Count);
        }

        [Test]
        public void Test_AppendBefore_ValidNode()
        {
            LinkedList<int?> list = new();
            LinkedListItem<int?> node = list.AppendLast(592);
            list.AppendBefore(node, 42);
            int?[] expected = { 42, 592 };
            Assert.True(expected.SequenceEqual(list));
            list.AppendBefore(node, 322);
            expected = new int?[] { 42, 322, 592};
            Assert.True(expected.SequenceEqual(list));
        }

        [Test]
        public void Test_AppendBefore_NodeFromAnotherList()
        {
            LinkedList<int?> list = new();
            LinkedList<int?> anotherList = new();
            LinkedListItem<int?> node = anotherList.AppendLast(592);
            Assert.Throws<InvalidOperationException>(() =>
            {
                list.AppendBefore(node, 42);
            });
        }

        [Test]
        public void Test_AppendBefore_NodeIsNull()
        {
            LinkedList<int?> list = new();
            Assert.Throws<ArgumentNullException>(() =>
            {
                list.AppendBefore(null!, 42);
            });
        }

        [Test]
        public void Test_AppendAfter_ValidNode()
        {
            LinkedList<int?> list = new();
            LinkedListItem<int?> node = list.AppendLast(592);
            list.AppendAfter(node, 24);
            int?[] expected = { 592, 24 };
            Assert.True(expected.SequenceEqual(list));
            list.AppendAfter(node, 322);
            expected = new int?[] { 592, 322, 24 };
            Assert.True(expected.SequenceEqual(list));
        }

        [Test]
        public void Test_AppendAfter_NodeFromAnotherList()
        {
            LinkedList<int?> list = new();
            LinkedList<int?> anotherList = new();
            LinkedListItem<int?> node = anotherList.AppendLast(592);
            Assert.Throws<InvalidOperationException>(() =>
            {
                list.AppendAfter(node, 512);
            });
        }

        [Test]
        public void Test_AppendAfter_NodeIsNull()
        {
            LinkedList<int?> list = new();
            Assert.Throws<ArgumentNullException>(() =>
            {
                list.AppendAfter(null!, 512);
            });
        }

        [Test]
        public void Test_Find_NotNull()
        {
            LinkedList<int?> list = new() { 349, 129, null, 39 };
            LinkedListItem<int?>? result = list.Find(null);
            Assert.NotNull(result);
        }

        [Test]
        public void Test_Find_IsNull()
        {
            LinkedList<int?> list = new() { 349, 129, null, 39 };
            LinkedListItem<int?>? result = list.Find(5555);
            Assert.Null(result);
        }

        [Test]
        public void Test_Remove_ByItem_Valid()
        {
            LinkedList<int?> list = new() { 349, 129, null, 39 };
            list.Remove(129);
            int?[] expected = { 349, null, 39 };
            Assert.True(expected.SequenceEqual(list));
        }

        [Test]
        public void Test_Remove_ByItem_NoSuchItem()
        {
            LinkedList<int?> list = new() { 349, 129, null, 39 };
            Assert.Throws<ArgumentNullException>(() =>
            {
                list.Remove(5555);
            });
        }

        [Test]
        public void Test_Remove_ByNode_NodeFromAnotherList()
        {
            LinkedList<int?> list = new() { 25, 39, null };
            LinkedList<int?> anotherList = new();
            LinkedListItem<int?> node = anotherList.AppendLast(592);
            Assert.Throws<InvalidOperationException>(() =>
            {
                list.Remove(node);
            });
        }

        [Test]
        public void Test_GetNode_ValidIndex()
        {
            LinkedList<int?> list = new();
            list.AppendLast(582);
            list.AppendLast(23);
            LinkedListItem<int?> expected = list.AppendLast(42);
            list.AppendLast(322);
            LinkedListItem<int?> result = list.GetNode(2);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_GetNode_InvalidIndex()
        {
            LinkedList<int?> list = new();
            list.AppendLast(582);
            list.AppendLast(23);
            list.AppendLast(42);
            list.AppendLast(322);
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                list.GetNode(-2);
            });
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                list.GetNode(8);
            });
        }

        [Test]
        public void Test_IndexOf_ExistingItem()
        {
            LinkedList<int?> list = new();
            list.AppendLast(582);
            list.AppendLast(23);
            list.AppendLast(42);
            list.AppendLast(322);
            int result = list.IndexOf(42);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Test_IndexOf_NotExistingItem()
        {
            LinkedList<int?> list = new();
            list.AppendLast(582);
            list.AppendLast(23);
            list.AppendLast(42);
            list.AppendLast(322);
            int result = list.IndexOf(912);
            Assert.AreEqual(-1, result);
        }
    }
}
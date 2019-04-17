using Microsoft.VisualStudio.TestTools.UnitTesting;
using LL;
using System;

namespace TestLinkedList
{
    [TestClass]
    public class LLTest
    {
        [TestMethod]
        public void After_two_insertion_has_Count_equal_two()
        {
            LinkedList<string> ll = new LinkedList<string>();

            ll.Add("Fabio");
            ll.Add("Dario");
            Assert.IsTrue(ll.Count == 2);
        }

        [TestMethod]
        public void A_new_LL_has_counter_equal_zero()
        {
            LinkedList<string> ll = new LinkedList<string>();

            Assert.IsTrue(ll.Count == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]

        public void Cannot_get_an_item_from_empty_LL()
        {
            LinkedList<string> ll = new LinkedList<string>();

            ll.Get(1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]

        public void Cannot_get_not_existent_item()
        {
            LinkedList<string> ll = new LinkedList<string>();

            ll.Add("Fabio");
            ll.Add("Dario");
            ll.Get(3);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]

        public void Cannot_access_negative_index()
        {
            LinkedList<string> ll = new LinkedList<string>();

            ll.Get(-5);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]

        public void Cannot_insert_at_negative_index()
        {
            LinkedList<string> ll = new LinkedList<string>();

            ll.Insert("Prova",-5);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]

        public void Cannot_insert_beyond_the_last_inserted()
        {
            LinkedList<string> ll = new LinkedList<string>();

            ll.Add("Fabio");
            ll.Add("Dario");
            ll.Insert("Prova", 4);
        }

        [TestMethod]
        public void Can_insert_as_last_element()
        {
            LinkedList<string> ll = new LinkedList<string>();

            ll.Add("Fabio");
            ll.Add("Dario");
            ll.Insert("Prova", 2);
            Assert.IsTrue(ll.Get(2).Equals("Prova"));
        }

        [TestMethod]
        public void Inserting_shifts_the_items_that_follow()
        {
            LinkedList<string> ll = new LinkedList<string>();

            ll.Add("Fabio");
            ll.Add("Dario");
            ll.Insert("Prova", 0);
            Assert.IsTrue(ll.Get(1).Equals("Fabio"));
        }

        [TestMethod]
        public void Inserting_increases_Count()
        {
            LinkedList<string> ll = new LinkedList<string>();

            ll.Add("Fabio");
            ll.Add("Dario");
            ll.Insert("Prova", 0);
            Assert.IsTrue(ll.Count == 3);
        }

        [TestMethod]
        public void Remove_unexistent_item()
        {
            LinkedList<string> ll = new LinkedList<string>();

            ll.Add("Fabio");
            ll.Add("Dario");
            ll.Insert("Prova", 0);

            ll.Remove("Giulio");
            Assert.IsTrue(ll.Count == 3);
        }

        [TestMethod]
        public void Remove_item()
        {
            LinkedList<string> ll = new LinkedList<string>();

            ll.Add("Fabio");
            ll.Add("Dario");
            ll.Insert("Prova", 0);

            ll.Remove("Dario");
            Assert.IsTrue(ll.Count == 2);
        }

        [TestMethod]
        public void Removing_shifts_the_items_that_follow()
        {
            LinkedList<string> ll = new LinkedList<string>();

            ll.Add("Fabio");
            ll.Add("Dario");
            ll.Insert("Prova", 0);
            ll.Remove("Dario");

            Assert.IsTrue(ll.Get(1).Equals("Prova"));
        }
    }
}

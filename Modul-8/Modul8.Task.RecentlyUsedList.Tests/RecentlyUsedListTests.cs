using Xunit;

namespace Modul8.Task.RecentlyUsedList.Tests
{
    public class RecentlyUsedListTests
    {
        private RecentlyUsedList _list;

        public RecentlyUsedListTests()
        {
            _list = new RecentlyUsedList();
        }

        [Fact]
        public void List_IsEmpty_OnInitialize()
        {
            Assert.Equal(0, _list.Count);
        }

        [Fact]
        public void List_Inserts_Items_InCorrectOrder()
        {
            _list.Add("Item1");
            _list.Add("Item2");
            Assert.Equal("Item2", _list[0]);
        }

        [Fact]
        public void List_Allows_UniqueInsertions_Only()
        {
            _list.Add("Item1");
            _list.Add("Item1");
            Assert.Equal(1, _list.Count);
        }

        [Fact]
        public void List_Does_Not_Allow_Null_Insertions()
        {
            Assert.Throws<ArgumentNullException>(() => _list.Add(null));
        }

        [Fact]
        public void List_Does_Not_Allow_Empty_String_Insertions()
        {
            Assert.Throws<ArgumentNullException>(() => _list.Add(""));
        }

        [Fact]
        public void List_Respects_Specified_Capacity()
        {
            _list = new RecentlyUsedList(2);
            _list.Add("Item1");
            _list.Add("Item2");
            _list.Add("Item3");
            Assert.Equal(2, _list.Count);
            Assert.Equal("Item3", _list[0]);
            Assert.Equal("Item2", _list[1]);
        }

        [Fact]
        public void List_Throws_Exception_On_Invalid_Index()
        {
            _list.Add("Item1");
            Assert.Throws<IndexOutOfRangeException>(() => _list[-1]);
            Assert.Throws<IndexOutOfRangeException>(() => _list[1]);
        }
    }
}

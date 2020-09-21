using System;
using NUnit.Framework;
using System.Threading.Tasks;
using TheGoodAsyncWrapper;

namespace TheGoodAsyncWrapperTests
{
    public class RunAsync_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test_ToReturnFromFunction()
        {
            //Async Calls
            var t1 = await ((Func<int, int>)TestAdd).RunAsync(2);
            Assert.AreEqual(t1, 2);

            var t2 = await ((Func<int, int, int>)TestAdd).RunAsync(2, 2);
            Assert.AreEqual(t2, 4);

            var t3 = await ((Func<int, int, int, int>)TestAdd).RunAsync(2, 2, 2);
            Assert.AreEqual(t3, 6); 

            var t4 = await ((Func<int, int, int, int, int>)TestAdd).RunAsync(2, 2, 2, 2);
            Assert.AreEqual(t4, 8); 

            var t5 = await ((Func<int, int, int, int, int, int>)TestAdd).RunAsync(2, 2, 2, 2, 2);
            Assert.AreEqual(t5, 10); 

            var t6 = await ((Func<int, int, int, int, int, int, int>)TestAdd).RunAsync(2, 2, 2, 2, 2, 2);
            Assert.AreEqual(t6, 12); 

            var t7 = await ((Func<int, int, int, int, int, int, int, int>)TestAdd).RunAsync(2, 2, 2, 2, 2, 2, 2);
            Assert.AreEqual(t7, 14); 

            var t8 = await ((Func<int, int, int, int, int, int, int, int, int>)TestAdd).RunAsync(2, 2, 2, 2, 2, 2, 2, 2);
            Assert.AreEqual(t8, 16);

            var del = (Action<bool>)TossErrorHandle;

            var F1 = del.RunAsync(true);
            Assert.IsTrue(F1.IsFaulted);

            var F2 = del.RunAsync(false);
            Assert.IsTrue(F2.IsCompleted);
        }

        public void TossErrorHandle(bool tossException)
        {
            if (tossException) 
            {
                throw new System.Exception();
            }
            {
                return;
            }
        }

        public int TestAdd(int value1)
        {
            return value1;
        }
        public int TestAdd(int value1, int value2)
        {
            return value1 + value2;
        }
        public int TestAdd(int value1, int value2, int value3)
        {
            return value1 + value2 + value3;
        }
        public int TestAdd(int value1, int value2, int value3, int value4)
        {
            return value1 + value2 + value3 + value4;
        }
        public int TestAdd(int value1, int value2, int value3, int value4, int value5)
        {
            return value1 + value2 + value3 + value4 + value5;
        }
        public int TestAdd(int value1, int value2, int value3, int value4, int value5, int value6)
        {
            return value1 + value2 + value3 + value4 + value5 + value6;
        }
        public int TestAdd(int value1, int value2, int value3, int value4, int value5, int value6, int value7)
        {
            return value1 + value2 + value3 + value4 + value5 + value6 + value7;
        }
        public int TestAdd(int value1, int value2, int value3, int value4, int value5, int value6, int value7, int value8)
        {
            return value1 + value2 + value3 + value4 + value5 + value6 + value7 + value8;
        }


    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using TheGoodReturnModel;

namespace TheGoodReturnModelTests
{
    public class ToReturn_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test_ToReturnFromFunction()
        {
            var t1 = await ((Func<int, int, int>)TestAddReturn).RunAsync(2, 2).ToReturn(ReturnState.Success, "Test");
            Assert.AreEqual(await t1.ReturnData, 4);
            Assert.AreEqual(t1.Status, ReturnState.Success);
            Assert.AreEqual(t1.Metadata.message, "Test");

            var t2 = await TestAddReturnAsync(2, 2).ToReturn(ReturnState.Cancelled, "");
            Assert.AreEqual(await t2.ReturnData, 4);
            Assert.AreEqual(t2.Status, ReturnState.Cancelled);
            Assert.AreEqual(t2.Metadata.message, "");

            var t3 = await TestAddReturnAsync(2, 2, ReturnState.Failed, "Burp");
            Assert.AreEqual(t3.ReturnData, 4);
            Assert.AreEqual(t3.Status, ReturnState.Failed);
            Assert.AreEqual(t3.Metadata.message, "Burp");

            var t4 = await TestAddReturnAsync(2, 2, true).ToReturn("Success","Fail","Cancel");
            Assert.AreEqual(t4.ReturnData, 4);
            Assert.AreEqual(t4.Status, ReturnState.Success);
            Assert.AreEqual(t4.Metadata.message, "Success");

            var t5 = await TestAddReturnAsync(2, 3, false).ToReturn("Success", "Fail", "Cancel");
            Assert.AreNotEqual(t5.ReturnData, 4);
            Assert.AreEqual(t5.Status, ReturnState.Cancelled);
            Assert.AreEqual(t5.Metadata.message, "Cancel");
        }

        public int TestAddReturn(int value1, int value2)
        {
            return value1 + value2;
        }

        public async Task<int> TestAddReturnAsync(int value1, int value2)
        {
            Func<int, int, int> call = TestAddReturn;
            var ret = await call.RunAsync(value1, value2);
            return ret;
        }

        public Task<int> TestAddReturnAsync(int value1, int value2, bool isPass)
        {
            Func<int, int, int> call = TestAddReturn;
            var x = call.Invoke(value1, value2);

            Task<int> ret = null;

            if (isPass) 
            {
                ret = Task.FromResult(x);
            } 
            else 
            {
                ret = Task.FromCanceled<int>(new CancellationToken(true));
            }

            return ret;
        }

        public async Task<Return<int>> TestAddReturnAsync(int value1, int value2, ReturnState state, string msg)
        {
            var ret = await TestAddReturnAsync(value1, value2);
            return await ret.ToReturn(state, msg);
        }

    }
}
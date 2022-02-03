# TheGoodCode
Libraries to simplify basic standardizations.
* ![.NET Core](https://github.com/LibertyEngineeringMovement/TheGoodCode/workflows/.NET%20Core/badge.svg)
* ![Attention Level](https://img.shields.io/badge/My%20Attention%20Level-Medium-blue)
* Note: ToReturn has been changed in V1.1.0
* Please read notes below.

## Code implementations review
### RunAsync Extension
#### Sample Code/Tests
```
    var t8 = await ((Func<int, int, int, int, int, int, int, int, int>)TestAdd).RunAsync(2, 2, 2, 2, 2, 2, 2, 2);
    Assert.AreEqual(t8, 16);

    var del = (Action<bool>)TossErrorHandle;
    var F1 = del.RunAsync(true);
    Assert.IsTrue(F1.IsFaulted);
```
### ToReturn<> Extension
#### Sample Code/Tests
```
    var t3 = await TestAddReturnAsync(2, 2, ReturnState.Failed, "Burp");
    Assert.AreEqual(t3.ReturnData, 4);
    Assert.AreEqual(t3.Status, ReturnState.Failed);
    Assert.AreEqual(t3.Metadata.message, "Burp");

    var t4 = await TestAddReturnAsync(2, 2, true).ToReturnAsync("Success","Fail","Cancel");
    Assert.AreEqual(t4.ReturnData, 4);
    Assert.AreEqual(t4.Status, ReturnState.Success);
    Assert.AreEqual(t4.Metadata.message, "Success");
```
#### Return Model
See bulleted note below.
```
    public class Return<T>
    {
        public T ReturnData { get; set; }
        public ReturnState Status { get; set; } = ReturnState.Indeterminate;
        public dynamic Metadata { get; set; } = new ExpandoObject();
    }
```
#### Note
Since you get to control the return state when coding for a Task, we have implemented more than one state return.
* ![Changes](https://img.shields.io/badge/Roadmap%20Change-Critical%20%7C%20Not%20Implimented-red) Note that this is changing to be a straight int. The reason is to support Http Response Status Codes.
```
    [Flags]
    public enum ReturnState
    {
        Indeterminate = 0,
        Success = 1,
        Failed = 2,
        Cancelled = 4,
        Custom1 = 8,
        Custom2 = 16,
        Custom3 = 32,
        Unhandled = 64
    }
```

# Other key notes
* [Code of Conduct](CODE_OF_CONDUCT.md)
* [CONTRIBUTING](CONTRIBUTING.md)
* [LICENSE](LICENSE)
* [SECURITY](SECURITY.md)

﻿using Fody;
using Xunit;
using Xunit.Abstractions;

public class AssemblyWithBlockingClassTests :
    XunitApprovalBase
{
    [Fact]
    public void TestClassIsNotBlocked()
    {
        var weavingTask = new ModuleWeaver();
        var testResult = weavingTask.ExecuteTestRun("AssemblyWithBlockingClass.dll");
        var instance = testResult.GetInstance("B");
        EventTester.TestProperty(instance, false);
    }

    public AssemblyWithBlockingClassTests(ITestOutputHelper output) :
        base(output)
    {
    }
}
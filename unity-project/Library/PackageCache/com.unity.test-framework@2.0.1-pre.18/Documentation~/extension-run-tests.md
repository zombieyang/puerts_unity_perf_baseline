# Running tests programmatically

You can run tests programmatically using the `TestRunnerApi`. The TestRunnerApi is a [ScriptableObject](https://docs.unity3d.com/ScriptReference/ScriptableObject.html) and it supports:

* **Running tests programatically** with custom execution settings in the form of a [Filter](https://docs.unity3d.com/Packages/com.unity.test-framework@latest/index.html?subfolder=/api/UnityEditor.TestTools.TestRunner.Api.Filter.html), to selectively include tests based on criteria such as test name, assembly name, and assemtly type.
* **Getting test results** by registering to receive callbacks at the start and finish of a test run or individual test. You can set a priority order for the invocation of callbacks and choose to get callbacks when a test run encounters an error.
* **Retrieving the test tree** based on execution settings in the form of a filter.

See the [TestRunnerApi](https://docs.unity3d.com/Packages/com.unity.test-framework@latest/index.html?subfolder=/api/UnityEditor.TestTools.TestRunner.Api.html) scripting reference for a full reference and code examples.


using UnityEngine;
using UnityEditor;
using UnityEditor.TestTools.TestRunner.Api;
using Puerts;
using System;
using System.IO;

public class PuertsTest : ScriptableObject
{

    private static TestRunnerApi testRunnerApi = null;
    [MenuItem("PuertsTest/Run")]
    static void DoIt()
    {
        if (testRunnerApi == null)
        {
            testRunnerApi = ScriptableObject.CreateInstance<TestRunnerApi>();
            testRunnerApi.RegisterCallbacks<TestCallback>(new TestCallback());
        }

        testRunnerApi.Execute(new ExecutionSettings(new Filter()
        {
            targetPlatform = BuildTarget.iOS,
            testMode = TestMode.PlayMode
        }));
    }

    private class TestCallback : ICallbacks
    {
        private JsEnv jsEnv;
        private Func<ITestResultAdaptor, string> parser;

        public TestCallback()
        {
            jsEnv = new JsEnv();
            parser = jsEnv.Eval<Func<ITestResultAdaptor, string>>(@"
                const results = {};
                function toJsArray(csArr) {
                    let arr = [];
                    for(var i = 0; i < csArr.Length; i++) {
                        arr.push(csArr.get_Item(i));
                    }
                    return arr;
                }

                function iterateTestResultAdaptor(testResultAdaptor) {
                    if (testResultAdaptor.HasChildren) {
                        toJsArray(testResultAdaptor.Children).forEach(testResultAdaptor => {
                            return iterateTestResultAdaptor(testResultAdaptor);
                        })
                        return;
                    }

                    if (testResultAdaptor.Test) {

                        let performance = testResultAdaptor.Output.match('##performancetestresult2:(.*)\n')
                        performance = JSON.parse(performance[1])

                        results[testResultAdaptor.FullName] = performance.SampleGroups[0].Average;
                    }
                }

                function parse(result) {
                    iterateTestResultAdaptor(result);
                    
                    let renderResult = '';
                    Object.keys(results).forEach(casekey => {
                        //replaceKeys.forEach((replaceKey, keyindex) => {
                        //    if (casekey.indexOf(replaceKey) != -1) {
                        //    }
                        //})
                        renderResult += `${casekey}, ${results[casekey]}\n`
                    });
                    return renderResult;
                }

                parse;
            ");
        }

        public void RunStarted(ITestAdaptor testsToRun)
        {

        }

        public void RunFinished(ITestResultAdaptor result)
        {
            string resultPath = Application.persistentDataPath + "/testResult-" + DateTime.Now.Ticks + ".log";
            FileStream fs = new FileStream(resultPath, FileMode.Create);
            var sw = new StreamWriter(fs);
            sw.Write(parser(result));
            sw.Close();
        }

        public void TestStarted(ITestAdaptor test)
        {

        }

        public void TestFinished(ITestResultAdaptor result)
        {
            if (!result.HasChildren/* && result.ResultState != "Passed"*/)
            {
                //Debug.Log(string.Format("Test {0} {1}", result.Test.Name, result.ResultState));
                //Debug.Log(result.m_Node.OuterXml);
            }
        }
    }
}

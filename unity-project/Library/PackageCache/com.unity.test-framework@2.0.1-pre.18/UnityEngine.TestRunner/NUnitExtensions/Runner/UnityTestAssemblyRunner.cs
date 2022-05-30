using System.Collections;
using System.Collections.Generic;
using NUnit;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using UnityEngine.TestTools.NUnitExtensions;

namespace UnityEngine.TestRunner.NUnitExtensions.Runner
{
    internal interface IUnityTestAssemblyRunner
    {
        ITest LoadedTest { get; }
        ITestResult Result { get; }
        bool IsTestLoaded { get; }
        bool IsTestRunning { get; }
        bool IsTestComplete { get; }
        UnityWorkItem TopLevelWorkItem { get; set; }
        UnityTestExecutionContext GetCurrentContext();
        ITest Load(AssemblyWithPlatform[] assemblies);
        void LoadTestTree(ITest testTree);
        IEnumerable Run(ITestListener listener, ITestFilter filter);
        void StopRun();
    }

    internal class UnityTestAssemblyRunner : IUnityTestAssemblyRunner
    {
        private readonly UnityTestAssemblyBuilder unityBuilder;
        private readonly WorkItemFactory m_Factory;

        protected UnityTestExecutionContext Context { get; set; }

        public UnityTestExecutionContext GetCurrentContext()
        {
            return UnityTestExecutionContext.CurrentContext;
        }

        protected IDictionary<string, object> Settings { get; set; }
        public ITest LoadedTest { get; protected set; }

        public ITestResult Result
        {
            get { return TopLevelWorkItem == null ? null : TopLevelWorkItem.Result; }
        }

        public bool IsTestLoaded
        {
            get { return LoadedTest != null; }
        }

        public bool IsTestRunning
        {
            get { return TopLevelWorkItem != null && TopLevelWorkItem.State == NUnit.Framework.Internal.Execution.WorkItemState.Running; }
        }
        public bool IsTestComplete
        {
            get { return TopLevelWorkItem != null && TopLevelWorkItem.State == NUnit.Framework.Internal.Execution.WorkItemState.Complete; }
        }

        public UnityTestAssemblyRunner(UnityTestAssemblyBuilder builder, WorkItemFactory factory, UnityTestExecutionContext context)
        {
            unityBuilder = builder;
            m_Factory = factory;
            Context = context;
        }

        public ITest Load(AssemblyWithPlatform[] assemblies)
        {
            return LoadedTest = unityBuilder.Build(assemblies);
        }

        public void LoadTestTree(ITest testTree)
        {
            LoadedTest = testTree;
        }

        public IEnumerable Run(ITestListener listener, ITestFilter filter)
        {
            TopLevelWorkItem = m_Factory.Create(LoadedTest, filter);
            TopLevelWorkItem.InitializeContext(Context);
            UnityTestExecutionContext.CurrentContext = Context;
            Context.Listener = listener;

            return TopLevelWorkItem.Execute();
        }

        public UnityWorkItem TopLevelWorkItem { get; set; }

        public void StopRun()
        {
            if (IsTestRunning)
            {
                TopLevelWorkItem.Cancel(false);
            }
        }
    }
}

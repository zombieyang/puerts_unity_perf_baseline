using System;
using UnityEngine;

public class ConcreteUnknown : IUnknown
{
    public override void Reset()
    {
        throw new NotImplementedException();
    }
}
/// <summary>
/// 因为 IUnknown 是可被Mock的，它需要可以替换，因此所有 IUnknown 实例都需要实现Dispose接口，以免同一个类型有多个实例时会有问题（如：同一个事件响应多次等）
/// </summary>
public abstract class IUnknown
{

    public virtual void Init()
    {
    }

    /// <summary>
    /// 切换账号时自动调用的，避免串数据，需要相应业务自行实现
    /// </summary>
    public abstract void Reset();

    /// <summary>
    /// Dispose表示析构，Dispose后就不要再Init了
    /// </summary>
    public virtual void Dispose()
    {
    }

    public static void DisposeAndNull(ref IUnknown obj)
    {
    }
}

/// <summary>
/// 业务能力的实例，他们需要被统一管理
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class UnknownInstance<T> : IUnknown where T : IUnknown, new()
{
    private static T _instance = null;

    /// <summary>
    /// 实例不在这里去创建，需要自己添加到相应的Manager里面去创建，以保证实例的创建、Reset、Dispose等操作是统一的、收敛的
    /// </summary>
    public static T Instance
    {
        get
        {
            return _instance;
        }
        set
        {
        }
    }

    public static int Instance1
    {
        get
        {
            return 4;
        }
        set
        {
        }
    }

    public override void Dispose()
    {
    }

    /// <summary>
    /// 当需要Mock对象时，使用此方法覆盖掉早前的实例
    /// 当方案应仅用于单元测试
    /// </summary>
    /// <param name="mockObj"></param>
    public static void MockInstance(T mockObj)
    {
    }
}
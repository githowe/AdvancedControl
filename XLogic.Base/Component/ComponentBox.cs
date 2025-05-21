namespace XLogic.Base.Component;

/// <summary>
/// 组件箱
/// </summary>
public class ComponentBox
{
    /// <summary>
    /// 添加初始组件
    /// </summary>
    public virtual void AddInitialComponent() { }

    /// <summary>
    /// 添加组件
    /// </summary>
    protected T AddComponent<T>(string name = "") where T : ComponentBase, new()
    {
        // 防止重复添加
        if (_componentDict.ContainsKey(typeof(T)))
            throw new Exception($"已包含类型为“{typeof(T)}”的组件");
        // 创建并添加组件实例
        T instance = new T() { Name = name, Box = this };
        _componentDict.Add(typeof(T), instance);
        // 返回组件实例
        return instance;
    }

    /// <summary>
    /// 移除组件
    /// </summary
    public void RemoveComponent<T>() where T : ComponentBase, new()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 清空组件
    /// </summary>
    public void ClearComponent()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 获取组件
    /// </summary>
    public T GetComponent<T>() where T : ComponentBase
    {
        if (!_componentDict.ContainsKey(typeof(T)))
            throw new Exception($"获取组件失败。组件类型：{typeof(T)}");
        return _componentDict[typeof(T)] as T;
    }

    /// <summary>
    /// 获取全部组件
    /// </summary>
    public List<T> GetAllComponent<T>() where T : ComponentBase
    {
        List<T> list = new List<T>();
        foreach (var item in _componentDict.Values)
            if (item is T t) list.Add(t);
        return list;
    }

    /// <summary>
    /// 初始化组件
    /// </summary>
    public void InitComponent()
    {
        foreach (var item in _componentDict.Values) item.Init();
    }

    /// <summary>
    /// 重置组件
    /// </summary>
    public void ResetComponent()
    {
        foreach (var item in _componentDict.Values) item.Reset();
    }

    /// <summary>
    /// 启用组件
    /// </summary>
    public void EnableComponent()
    {
        foreach (var item in _componentDict.Values) item.Enable();
    }

    /// <summary>
    /// 禁用组件
    /// </summary>
    public void DisableComponent()
    {
        foreach (var item in _componentDict.Values) item.Disable();
    }

    /// <summary>组件表</summary>
    private readonly Dictionary<Type, ComponentBase> _componentDict = new Dictionary<Type, ComponentBase>();
}
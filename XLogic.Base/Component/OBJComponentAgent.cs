namespace XLogic.Base.Component;

/// <summary>
/// 对象组件代理
/// </summary>
public static class OBJComponentAgent
{
    /// <summary>
    /// 添加组件
    /// </summary>
    public static void AddComponent(this object source, object component) => OBJComponentManager.Instance.AddComponent(source, component);

    /// <summary>
    /// 创建并添加组件
    /// </summary>
    public static T AddComponent<T>(this object source) where T : class, new()
    {
        T component = new T();
        OBJComponentManager.Instance.AddComponent(source, component);
        return component;
    }

    /// <summary>
    /// 移除组件
    /// </summary>
    public static void RemoveComponent(this object source, object component) => OBJComponentManager.Instance.RemoveComponent(source, component);

    /// <summary>
    /// 清空指定类型的组件
    /// </summary>
    public static void ClearComponent(this object source, Type type) => OBJComponentManager.Instance.ClearComponent(source, type);

    /// <summary>
    /// 清空全部组件
    /// </summary>
    public static void ClearComponent(this object source) => OBJComponentManager.Instance.ClearComponent(source);

    /// <summary>
    /// 获取组件
    /// </summary>
    public static T? GetComponent<T>(this object source) where T : class => OBJComponentManager.Instance.GetComponent<T>(source);

    /// <summary>
    /// 获取组件列表
    /// </summary>
    public static List<T>? GetComponentList<T>(this object source) where T : class => OBJComponentManager.Instance.GetComponentList<T>(source);
}
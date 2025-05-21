namespace XLogic.Base.Component;

/// <summary>
/// 对象组件盒
/// </summary>
public class OBJComponentBox
{
    /// <summary>
    /// 添加组件
    /// </summary>
    public void AddComponent(object component)
    {
        Type type = component.GetType();
        if (!_dict.ContainsKey(type)) _dict.Add(type, new List<object>());
        _dict[type].Add(component);
    }

    /// <summary>
    /// 移除组件
    /// </summary>
    public void RemoveComponent(object component)
    {
        Type type = component.GetType();
        if (_dict.ContainsKey(type)) _dict[type].Remove(component);
    }

    /// <summary>
    /// 清空组件
    /// </summary>
    public void ClearComponent(Type type)
    {
        if (!_dict.ContainsKey(type)) return;
        _dict[type].Clear();
    }

    /// <summary>
    /// 清空组件
    /// </summary>
    public void ClearComponent() => _dict.Clear();

    /// <summary>
    /// 获取组件
    /// </summary>
    public T? GetComponent<T>() where T : class
    {
        Type type = typeof(T);
        if (_dict.ContainsKey(type) && _dict[type].Count > 0)
            return (T)_dict[type][0];
        return null;
    }

    /// <summary>
    /// 获取组件列表
    /// </summary>
    public List<T>? GetComponentList<T>() where T : class
    {
        Type type = typeof(T);
        if (_dict.ContainsKey(type))
        {
            List<T> result = new List<T>();
            foreach (var item in _dict[type]) result.Add((T)item);
            return result;
        }
        return null;
    }

    private readonly Dictionary<Type, List<object>> _dict = new Dictionary<Type, List<object>>();
}
namespace XLogic.Base.Component;

/// <summary>
/// 对象组件管理器
/// </summary>
public class OBJComponentManager
{
    private OBJComponentManager() { }
    public static OBJComponentManager Instance { get; } = new OBJComponentManager();

    public void AddComponent(object source, object component)
    {
        if (!_boxDict.ContainsKey(source)) _boxDict.Add(source, new OBJComponentBox());
        _boxDict[source].AddComponent(component);
    }

    public void RemoveComponent(object source, object component)
    {
        if (!_boxDict.ContainsKey(source)) return;
        _boxDict[source].RemoveComponent(component);
    }

    public void ClearComponent(object source, Type type)
    {
        if (!_boxDict.ContainsKey(source)) return;
        _boxDict[source].ClearComponent(type);
    }

    public void ClearComponent(object source)
    {
        if (!_boxDict.ContainsKey(source)) return;
        _boxDict[source].ClearComponent();
    }

    public T? GetComponent<T>(object source) where T : class
    {
        if (!_boxDict.ContainsKey(source)) return null;
        return _boxDict[source].GetComponent<T>();
    }

    public List<T>? GetComponentList<T>(object source) where T : class
    {
        if (!_boxDict.ContainsKey(source)) return null;
        return _boxDict[source].GetComponentList<T>();
    }

    private readonly Dictionary<object, OBJComponentBox> _boxDict = new Dictionary<object, OBJComponentBox>();
}
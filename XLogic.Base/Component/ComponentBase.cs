namespace XLogic.Base.Component;

/// <summary>
/// 组件基类
/// </summary>
public class ComponentBase
{
    #region 属性

    /// <summary>组件名称</summary>
    public string Name { get; set; } = "";

    /// <summary>组件箱</summary>
    public ComponentBox Box { get; set; }

    /// <summary>是否启用</summary>
    public bool IsEnabled { get; private set; } = false;

    #endregion

    #region 生命周期

    /// <summary>初始化</summary>
    public virtual void Init() { }

    /// <summary>重置</summary>
    public virtual void Reset() { }

    /// <summary>启用</summary>
    public void Enable()
    {
        OnEnable();
        IsEnabled = true;
    }

    /// <summary>禁用</summary>
    public void Disable()
    {
        OnDisable();
        IsEnabled = false;
    }

    #endregion

    #region 内部方法

    /// <summary>
    /// 获取组件
    /// </summary>
    protected T GetComponent<T>() where T : ComponentBase => Box.GetComponent<T>();

    /// <summary>
    /// 启用组件时
    /// </summary>
    protected virtual void OnEnable() { }

    /// <summary>
    /// 禁用组件时
    /// </summary>
    protected virtual void OnDisable() { }

    #endregion
}
using UnityEngine;

/// <summary>
/// Transform がキャッシュされた MonoBehaivour 。
/// </summary>
public class CacheMonoBehaviourTransform : MonoBehaviour
{
    #region Field

    /// <summary>
    /// キャッシュされた Transform 。
    /// </summary>
    [HideInInspector]
    public new Transform transform;

    #endregion Field

    #region Method

    /// <summary>
    /// 初期化時に呼び出されます。
    /// </summary>
    protected virtual void Awake()
    {
        this.transform = base.transform;
    }

    #endregion Method
}
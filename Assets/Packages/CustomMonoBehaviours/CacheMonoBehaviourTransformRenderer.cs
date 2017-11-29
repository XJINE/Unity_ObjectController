using UnityEngine;

/// <summary>
/// Transform と Renderer がキャッシュされた MonoBehaivour 。
/// </summary>
public class CacheMonoBehaviourTransformRenderer : CacheMonoBehaviourTransform
{
    #region Field

    /// <summary>
    /// キャッシュされた Renderer 。
    /// </summary>
    [HideInInspector]
    public new Renderer renderer;

    #endregion Field

    #region Method

    /// <summary>
    /// 初期化時に呼び出されます。
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        this.renderer  = this.GetComponent<Renderer>();
    }

    #endregion Method
}
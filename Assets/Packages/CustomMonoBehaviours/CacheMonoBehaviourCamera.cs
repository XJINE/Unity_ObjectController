using UnityEngine;

/// <summary>
/// Camera がキャッシュされた MonoBehaivour 。
/// </summary>
[RequireComponent(typeof(Camera))]
public class CacheMonoBehaviourCamera : MonoBehaviour
{
    #region Field

    /// <summary>
    /// キャッシュされた Camera 。
    /// </summary>
    [HideInInspector]
    public new Camera camera;

    #endregion Field

    #region Method

    /// <summary>
    /// 初期化時に呼び出されます。
    /// </summary>
    protected virtual void Awake()
    {
        this.camera = base.GetComponent<Camera>();
    }

    #endregion Method
}
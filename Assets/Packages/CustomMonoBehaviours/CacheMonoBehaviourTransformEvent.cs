using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// CacheMonoBehaviourTransform に通知用のイベントを持たせたクラス。
/// </summary>
public class CacheMonoBehaviourTransformEvent : CacheMonoBehaviourTransform
{
    #region Class

    /// <summary>
    /// Transform が更新されたときに通知されるイベント。
    /// </summary>
    [System.Serializable]
    public class TransformUpdateEvent : UnityEvent<Transform> { }

    #endregion Class

    #region Field

    /// <summary>
    /// Transform が更新されたときに通知されるイベント。
    /// </summary>
    public TransformUpdateEvent transformUpdateEvent;

    #endregion Field
}
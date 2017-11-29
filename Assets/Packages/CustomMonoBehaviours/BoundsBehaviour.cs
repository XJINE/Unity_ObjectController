using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Bounds.size の変化も監視し, 変更を通知する機能を持った BoundsBehaviour です.
/// </summary>
public class BoundsBehaviour : BoundsBehaviourBase
{
    #region Class

    /// <summary>
    /// Bounds が更新されたときに通知されるイベントです.
    /// </summary>
    [System.Serializable]
    public class BoundsUpdateEvent : UnityEvent<BoundsBehaviour>
    {
    }

    #endregion Class

    #region Field

    /// <summary>
    /// Bounds が更新されたときに通知されるイベント.
    /// </summary>
    public BoundsUpdateEvent boundsUpdateEvent;

    /// <summary>
    /// 前回更新された Bounds.
    /// </summary>
    protected Bounds previousBouns;

    #endregion Field

    #region Method

    /// <summary>
    /// Bounds を更新します.Transform が更新されるときなどに任意に呼び出します.
    /// </summary>
    public override void UpdateBounds()
    {
        base.UpdateBounds();

        base.bounds.size = base.transform.localScale;

        if (this.previousBouns != base.bounds)
        {
            this.boundsUpdateEvent.Invoke(this);
        }

        this.previousBouns = this.bounds;
    }

    #endregion Method
}
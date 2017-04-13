using UnityEngine;

namespace ObjectController
{
    /// <summary>
    /// 軸を基準にその周囲を公転します。
    /// </summary>
    public class AxisAroundRotator : MonoBehaviour
    {
        #region Field

        /// <summary>
        /// 回転軸。
        /// </summary>
        public Vector3 rotateAxis = Vector3.up;

        /// <summary>
        /// 回転軸の位置。
        /// </summary>
        public Vector3 rotateAxisPosition = Vector3.zero;

        /// <summary>
        /// 回転する速度(角度)。
        /// </summary>
        public float rotateSpeedDegree = 1;

        #endregion Field

        /// <summary>
        /// 更新時に呼び出されます。
        /// </summary>
        protected virtual void Update()
        {
            base.transform.RotateAround(this.rotateAxisPosition,
                                        this.rotateAxis,
                                        this.rotateSpeedDegree);
        }
    }
}
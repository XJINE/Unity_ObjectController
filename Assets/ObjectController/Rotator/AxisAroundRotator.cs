using UnityEngine;

namespace ObjectController
{
    /// <summary>
    /// 軸を基準にその周囲を公転します。
    /// </summary>
    public class AxisAroundRotator : AxisRotator
    {
        #region Field

        /// <summary>
        /// 回転軸の位置。
        /// </summary>
        public Vector3 rotateAxisPosition = Vector3.zero;

        #endregion Field

        #region Method

        /// <summary>
        /// 回転します。
        /// </summary>
        /// <returns>
        /// 回転した量(degree)。
        /// </returns>
        protected override float Rotate()
        {
            float rotateAngleDegree = base.rotateSpeed * Time.deltaTime;

            base.transform.RotateAround(this.rotateAxisPosition,
                                        base.rotateAxis,
                                        rotateAngleDegree);

            return rotateAngleDegree;
        }

        #endregion Method
    }
}
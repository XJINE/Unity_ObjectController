using UnityEngine;

namespace ObjectController
{
    /// <summary>
    /// 軸を基準に回転させます。
    /// </summary>
    public class AxisRotator : Rotator
    {
        #region Field

        /// <summary>
        /// 回転軸。
        /// </summary>
        public Vector3 rotateAxis = Vector3.up;

        #endregion Field

        /// <summary>
        /// 回転します。
        /// </summary>
        /// <returns>
        /// 回転した角度(degree)。
        /// </returns>
        protected override float Rotate()
        {
            float rotateAngleDegree = base.rotateSpeed * Time.deltaTime;

            base.transform.RotateAround(base.transform.position,
                                        this.rotateAxis,
                                        rotateAngleDegree);
            return rotateAngleDegree;
        }
    }
}
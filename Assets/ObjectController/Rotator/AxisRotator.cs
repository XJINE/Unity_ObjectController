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
        public Vector3 rotationAxis = Vector3.up;

        /// <summary>
        /// ローカル座標での回転かどうか。
        /// </summary>
        public bool rotationAxisIsLocal = true;

        #endregion Field

        #region Method

        /// <summary>
        /// 回転します。
        /// </summary>
        /// <returns>
        /// 回転した角度(degree)。
        /// </returns>
        protected override float Rotate()
        {
            float rotateAngleDegree = base.rotateSpeed * Time.deltaTime;

            base.transform.RotateAround(GetRotationPoint(),
                                        GetRotationAxis(),
                                        rotateAngleDegree);

            return rotateAngleDegree;
        }

        /// <summary>
        /// 回転軸の位置を取得します。
        /// </summary>
        /// <returns>
        /// 回転軸の座標(World)。
        /// </returns>
        protected virtual Vector3 GetRotationPoint()
        {
            return base.transform.position;
        }

        /// <summary>
        /// 回転軸を取得します。
        /// </summary>
        /// <returns>
        /// 回転軸。
        /// </returns>
        protected virtual Vector3 GetRotationAxis()
        {
            return this.rotationAxisIsLocal ?
                   base.transform.localRotation * this.rotationAxis :
                   this.rotationAxis;
        }

        #endregion Method
    }
}
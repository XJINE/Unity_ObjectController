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
        /// 回転軸の位置を取得します。
        /// </summary>
        /// <returns>
        /// 回転軸の座標(World)。
        /// </returns>
        protected override Vector3 GetRotationPoint()
        {
            return base.localPosition ?
                   base.transform.parent ?
                       base.transform.parent.position + this.rotateAxisPosition :
                       base.transform.position + this.rotateAxisPosition :
                   this.rotateAxisPosition;
        }

        #endregion Method
    }
}
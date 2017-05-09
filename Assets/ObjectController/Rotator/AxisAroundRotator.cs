using UnityEngine;

namespace ObjectController
{
    /// <summary>
    /// 軸を基準にその周囲を回転します。
    /// </summary>
    public class AxisAroundRotator : AxisRotator
    {
        #region Field

        /// <summary>
        /// 回転軸の位置。
        /// </summary>
        public Vector3 rotationAxisPosition = Vector3.zero;

        /// <summary>
        /// ローカル座標を基準にした回転かどうか。
        /// </summary>
        public bool rotationAxisPositionIsLocal = true;

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
            // 回転軸がローカル座標基準のとき、
            // 
            // (1) 親がいれば、回転軸を親の座標からの位置に変換します。
            // (2) 親がなければ、回転軸は世界座標のままにします。
            // 
            // ローカル座標基準でないとき、世界座標で回転します。

            return this.rotationAxisPositionIsLocal ?
                   base.transform.parent ?
                       base.transform.parent.position + this.rotationAxisPosition :
                       this.rotationAxisPosition :
                   this.rotationAxisPosition;
        }

        #endregion Method
    }
}
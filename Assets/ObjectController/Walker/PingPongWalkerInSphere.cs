using UnityEngine;

namespace ObjectController
{
    /// <summary>
    /// 球の中をランダムに跳ね返りながら移動させます。
    /// </summary>
    public class PingPongWalkerInSphere : Walker
    {
        #region Field

        /// <summary>
        /// 移動範囲の原点。
        /// </summary>
        public Vector3 moveOrigin;

        /// <summary>
        /// 移動範囲の半径。
        /// </summary>
        public float moveRangeRadius = 5;

        #endregion Field

        #region Method

        /// <summary>
        /// 開始時に呼び出されます。
        /// </summary>
        protected override void Start()
        {
            SetNextTarget();
            base.Start();
        }

        /// <summary>
        /// Gizmo の描画時に呼び出されます。
        /// </summary>
        protected virtual void OnDrawGizmos()
        {
            Color previousGizmosColor = Gizmos.color;

            Gizmos.color = Color.white;

            Gizmos.DrawWireSphere(this.moveOrigin, this.moveRangeRadius);

            Gizmos.color = previousGizmosColor;
        }

        /// <summary>
        /// 次のターゲットの座標を取得します。
        /// </summary>
        /// <returns>
        /// 次のターゲットの座標。
        /// </returns>
        protected override Vector3 GetNextTarget()
        {
            return this.moveOrigin + Random.onUnitSphere * this.moveRangeRadius;
        }

        #endregion Method
    }
}
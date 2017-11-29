using UnityEngine;

namespace ObjectController
{
    /// <summary>
    /// 直方体の中をランダムに移動させます。
    /// </summary>
    public class RandomWalkerInRectangle : Walker
    {
        #region Field

        /// <summary>
        /// 移動範囲の最小座標(直方体の前方左下)。
        /// </summary>
        public Vector3 moveRangeMin = Vector3.zero;

        /// <summary>
        /// 移動範囲の最大座標(直方体の後方右上)。
        /// </summary>
        public Vector3 moveRangeMax = Vector3.one * 10f;

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
        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();

            Color previousGizmosColor = Gizmos.color;

            Gizmos.color = Color.white;

            Vector3 moveRange = this.moveRangeMax - this.moveRangeMin;

            Gizmos.DrawWireCube(this.moveRangeMin + (moveRange / 2), moveRange);

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
            return new Vector3()
            {
                x = Random.Range(this.moveRangeMin.x, this.moveRangeMax.x),
                y = Random.Range(this.moveRangeMin.y, this.moveRangeMax.y),
                z = Random.Range(this.moveRangeMin.z, this.moveRangeMax.z)
            };
        }

        #endregion Method
    }
}
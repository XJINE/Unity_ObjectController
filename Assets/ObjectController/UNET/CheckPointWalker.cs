using UnityEngine;
using UnityEngine.Networking;

namespace ObjectController.UNET
{
    /// <summary>
    /// 指定した座標を順に移動します。
    /// </summary>
    public class CheckPointWalker : NetworkBehaviour
    {
        #region Field

        /// <summary>
        /// 移動速度。
        /// </summary>
        public float moveSpeed = 1;

        /// <summary>
        /// 通過するチェックポイント。
        /// </summary>
        public Vector3[] checkPoints;

        /// <summary>
        /// 現在のチェックポイントを示すインデックス。
        /// </summary>
        public int checkPointIndex = 0;

        #endregion Filed

        #region Method

        /// <summary>
        /// 開始時に呼び出されます。
        /// </summary>
        protected virtual void Start()
        {
            if (this.checkPointIndex >= this.checkPoints.Length)
            {
                this.checkPointIndex = this.checkPointIndex % this.checkPoints.Length;
            }

            base.transform.position = this.checkPoints[this.checkPointIndex];
        }

        /// <summary>
        /// 更新時に呼び出されます。
        /// </summary>
        protected virtual void Update()
        {
            if (this.checkPoints == null)
            {
                return;
            }

            if (this.checkPointIndex >= this.checkPoints.Length)
            {
                this.checkPointIndex = this.checkPointIndex % this.checkPoints.Length;
            }

            Vector3 checkPoint = this.checkPoints[this.checkPointIndex];

            this.transform.position = Vector3.MoveTowards
                (this.transform.position, checkPoint, Time.deltaTime * this.moveSpeed);

            if (this.transform.position == checkPoint)
            {
                this.checkPointIndex = this.checkPointIndex + 1;
            }
        }

        /// <summary>
        /// Gizmo の描画時に呼び出されます。
        /// </summary>
        protected virtual void OnDrawGizmos()
        {
            Color previousGizmosColor = Gizmos.color;

            Gizmos.color = Color.white;

            foreach (Vector3 checkPoint in this.checkPoints)
            {
                Gizmos.DrawSphere(checkPoint, 0.25f);
            }

            if (this.checkPointIndex >= this.checkPoints.Length)
            {
                return;
            }

            Gizmos.DrawLine(base.transform.position,
                           (this.checkPoints[this.checkPointIndex] + base.transform.position) / 2f);

            Gizmos.color = previousGizmosColor;
        }

        #endregion Method
    }
}
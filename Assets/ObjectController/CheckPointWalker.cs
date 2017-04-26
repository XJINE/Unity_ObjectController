using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace ObjectController
{
    /// <summary>
    /// 指定した座標を順に移動します。
    /// </summary>
    public class CheckPointWalker : Walker
    {
        #region Field

        /// <summary>
        /// 通過するチェックポイント。
        /// </summary>
        public List<Vector3> checkPoints;

        /// <summary>
        /// 現在のチェックポイントを示すインデックス。
        /// </summary>
        public int checkPointIndex = 0;

        /// <summary>
        /// 次のループへ進むかどうか。
        /// </summary>
        public bool goToNextLoop = true;

        /// <summary>
        /// 最終目的地から最初の目的地まで移動するかどうか。
        /// </summary>
        public bool seamlessLoop = true;

        /// <summary>
        /// 最終目的地に到着したときのイベントハンドラ。
        /// </summary>
        public UnityEvent arrivedLastCheckPointEventHandler;

        #endregion Filed

        #region Method

        /// <summary>
        /// 開始時に呼び出されます。
        /// </summary>
        protected override void Start()
        {
            base.Start();
            base.arrivedEventHandler.AddListener(this.CheckArrivedLastCheckPoint);
        }

        /// <summary>
        /// 更新時に呼び出されます。
        /// </summary>
        protected override void Update()
        {
            if (this.checkPoints == null)
            {
                return;
            }

            if (this.checkPointIndex >= this.checkPoints.Count)
            {
                this.checkPointIndex = this.checkPointIndex % this.checkPoints.Count;
            }

            base.target = this.checkPoints[this.checkPointIndex];

            base.Update();
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

            if (this.checkPointIndex >= this.checkPoints.Count)
            {
                return;
            }

            Gizmos.DrawLine(base.transform.position,
                           (this.checkPoints[this.checkPointIndex] + base.transform.position) / 2f);

            Gizmos.color = previousGizmosColor;
        }

        /// <summary>
        /// 次のターゲットを設定します。
        /// </summary>
        protected override void SetNextTarget()
        {
            this.checkPointIndex = this.checkPointIndex + 1;
        }

        /// <summary>
        /// 最終目的地に到着したかどうかを判定し、
        /// 到達しているときは arrivedLastCheckPointEventHandler を実行します。
        /// </summary>
        protected void CheckArrivedLastCheckPoint()
        {
            if (this.checkPointIndex == this.checkPoints.Count - 1)
            {
                this.arrivedLastCheckPointEventHandler.Invoke();

                if (!this.goToNextLoop)
                {
                    base.goToNextTarget = false;
                }

                if (!this.seamlessLoop)
                {
                    base.transform.position = this.checkPoints[0];

                    SetNextTarget();

                    if (base.lookAtTarget)
                    {
                        base.transform.LookAt(base.target);
                    }
                }
            }
        }

        #endregion Method
    }
}
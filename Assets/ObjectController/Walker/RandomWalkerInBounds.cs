using UnityEngine;

namespace ObjectController
{
    /// <summary>
    /// 
    /// </summary>
    public class RandomWalkerInBounds : Walker
    {
        #region Field

        /// <summary>
        /// 移動する Bounds.
        /// </summary>
        public BoundsBehaviour[] boundsBehaviours;

        /// <summary>
        /// 移動してはいけない Bounds.
        /// </summary>
        public BoundsBehaviour[] boundsBehaviourKeepout;

        #endregion Field

        #region Method

        /// <summary>
        /// 次のターゲットの座標を取得します。
        /// </summary>
        /// <returns>
        /// 次のターゲットの座標。
        /// </returns>
        protected override Vector3 GetNextTarget()
        {
            int boundsBehaviourKeepoutLength = this.boundsBehaviourKeepout.Length;

            Vector3 randomPoint = this.boundsBehaviours[Random.Range(0, this.boundsBehaviours.Length)].bounds.GetRandomPoint();
            Ray ray = new Ray(this.transform.position, randomPoint - this.transform.position);

            bool loop = true;

            while (loop)
            {
                loop = false;

                for (int i = 0; i < boundsBehaviourKeepoutLength; i++)
                {
                    if (this.boundsBehaviourKeepout[i].bounds.IntersectRay(ray))
                    {
                        randomPoint = this.boundsBehaviours[Random.Range(0, this.boundsBehaviours.Length)].bounds.GetRandomPoint();
                        ray = new Ray(this.transform.position, randomPoint - this.transform.position);
                        loop = true;
                        break;
                    }
                }
            }

            return randomPoint;
        }

        #endregion Method
    }
}
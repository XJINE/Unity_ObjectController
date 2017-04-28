using UnityEngine;

namespace ObjectController
{
    /// <summary>
    /// 色を制御します。
    /// </summary>
    public class ColorController : MonoBehaviour
    {
        #region Field

        /// <summary>
        /// 設定する色。
        /// </summary>
        public Color color;

        /// <summary>
        /// このオブジェクトのレンダラ。
        /// </summary>
        protected new Renderer renderer;

        /// <summary>
        /// MaterialPropertyBlock.
        /// </summary>
        protected MaterialPropertyBlock materialPropertyBlock;

        #endregion Field

        /// <summary>
        /// 開始時に呼び出されます。
        /// </summary>
        protected virtual void Start()
        {
            this.renderer = base.GetComponent<Renderer>();
            this.materialPropertyBlock = new MaterialPropertyBlock();

            SetColor(this.color);
        }

        /// <summary>
        /// 色を設定します。
        /// </summary>
        /// <param name="color">
        /// 設定する色。
        /// </param>
        public virtual void SetColor(Color color)
        {
            this.renderer.GetPropertyBlock(this.materialPropertyBlock);
            this.materialPropertyBlock.SetColor("_Color", this.color);
            this.renderer.SetPropertyBlock(this.materialPropertyBlock);
        }
    }
}
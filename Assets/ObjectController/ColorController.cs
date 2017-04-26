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
        /// 共有される MaterialPropertyBlock.
        /// </summary>
        protected static MaterialPropertyBlock SharedMaterialPropertyBlock = new MaterialPropertyBlock();

        /// <summary>
        /// 設定する色。
        /// </summary>
        public Color color;

        /// <summary>
        /// このオブジェクトのレンダラ。
        /// </summary>
        protected new Renderer renderer;

        #endregion Field

        /// <summary>
        /// 開始時に呼び出されます。
        /// </summary>
        protected virtual void Start()
        {
            this.renderer = base.GetComponent<Renderer>();
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
            this.renderer.GetPropertyBlock(SharedMaterialPropertyBlock);

            ColorController.SharedMaterialPropertyBlock.SetColor("_Color", color);

            this.renderer.SetPropertyBlock(ColorController.SharedMaterialPropertyBlock);
        }
    }
}
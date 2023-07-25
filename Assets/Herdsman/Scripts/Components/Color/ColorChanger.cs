using UnityEngine;

namespace Components.Color
{
    public class ColorChanger : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Color defaultColor;
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void SetColor(UnityEngine.Color color)
        {
            spriteRenderer.color = color;
        }

        public void ResetColor()
        {
            spriteRenderer.color = defaultColor;
        }
    }
}
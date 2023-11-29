using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Image uiImage;
    public Canvas canvas;

    private Vector2 _point;

    void Start()
    {
        // Get the RectTransform of the UI element
        RectTransform uiRectTransform = uiImage.rectTransform;
        
    //    RectTransformUtility.PixelAdjustPoint(_point ,uiRectTransform , canvas);
        
        Debug.Log("World Position: " + Camera.main.ScreenToWorldPoint(uiRectTransform.position));
    }
}

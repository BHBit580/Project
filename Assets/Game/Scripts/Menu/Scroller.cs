using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private Vector2 speed;

    private float _divideFactor = 100;
    
    private RawImage _rawImage;
    private void Start()=> _rawImage = GetComponent<RawImage>();

    private void Update()=> _rawImage.uvRect = new Rect(_rawImage.uvRect.position + speed/_divideFactor * Time.deltaTime, _rawImage.uvRect.size);
}

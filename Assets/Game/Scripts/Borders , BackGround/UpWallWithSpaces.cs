using UnityEngine;
using UnityEngine.Serialization;


[ExecuteInEditMode]
public class UpWallWithSpaces : MonoBehaviour
{
    [SerializeField] private float scaleXMultiplier = 1f; // Multiplier for the scale of the child objects
    [SerializeField] private float offset = 0.5f;

    [SerializeField] private Transform leftBorder;
    [SerializeField] private Transform rightBorder;
    
    private Transform[] _childObjects;
    private Vector3 _leftBorderPosition, _rightBorderPosition;

    private void Start()
    {
        GetChildren();
    }

    void Update()
    {
        _leftBorderPosition =
            new Vector3(leftBorder.position.x + offset, leftBorder.position.y, leftBorder.position.z);
        _rightBorderPosition =
            new Vector3(rightBorder.position.x - offset, rightBorder.position.y, rightBorder.position.z);

        float distanceBetweenObjects = Vector3.Distance(_leftBorderPosition, _rightBorderPosition) / (_childObjects.Length - 1);

        for (int i = 0; i < _childObjects.Length; i++)
        {
            float normalizedX = (float)i / (_childObjects.Length - 1); // Normalized value between 0 and 1
            Vector3 targetPosition = Vector3.Lerp(_leftBorderPosition, _rightBorderPosition, normalizedX); // Calculate target position

            // Update position
            _childObjects[i].position =
                new Vector3(targetPosition.x, _childObjects[i].position.y, _childObjects[i].position.z);

            // Ensure child objects do not cross borders
            float clampedX = Mathf.Clamp(_childObjects[i].position.x, _leftBorderPosition.x, _rightBorderPosition.x);
            _childObjects[i].position = new Vector3(clampedX, _childObjects[i].position.y, _childObjects[i].position.z);

            // Update scale based on screen width and multiplier
            float targetScaleX = (distanceBetweenObjects / (_rightBorderPosition.x - _leftBorderPosition.x)) * scaleXMultiplier;
            Vector3 newScale = _childObjects[i].localScale;
            newScale.x = targetScaleX;
            _childObjects[i].localScale = newScale;
        }
    }

    private void GetChildren()
    {
        int childCount = transform.childCount;
        _childObjects = new Transform[childCount];

        // Automatically assign child objects based on their order in the hierarchy
        for (int i = 0; i < childCount; i++)
        {
            _childObjects[i] = transform.GetChild(i);
        }
    }
}

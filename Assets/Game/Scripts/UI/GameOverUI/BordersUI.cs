using DG.Tweening;
using UnityEngine;

namespace GameOverUI.BorderUI
{
    public class BordersUI : MonoBehaviour
    {
        [SerializeField] private float time = 0.5f;
        private void OnEnable()
        {
            GetComponent<RectTransform>().localScale = new Vector3(0, 1, 1);
            GetComponent<RectTransform>().DOScale(Vector3.one, time);
        }
    }
}

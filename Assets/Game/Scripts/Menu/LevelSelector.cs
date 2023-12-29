using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private Button[] levelButtons;
    [SerializeField] private float time = 0.5f;
    [SerializeField] private RectTransform playButton;
    [SerializeField]private Vector2 finalPosVector = new Vector2(-10 , -880);
    private float initialAlpha;
    private Button selectedButton;

    
    
    private void Start()
    {
        initialAlpha = levelButtons[0].GetComponent<Image>().color.a;

        foreach (Button button in levelButtons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    private void OnButtonClick(Button clickedButton)
    {
        if (selectedButton != null)
        {
            // Reset the alpha of the previously selected button
            Image prevButtonImage = selectedButton.GetComponent<Image>();
            if (prevButtonImage != null)
            {
                Color prevColor = prevButtonImage.color;
                prevColor.a = initialAlpha;
                prevButtonImage.color = prevColor;
            }
        }

        // Toggle the alpha of the clicked button
        Image clickedButtonImage = clickedButton.GetComponent<Image>();
        if (clickedButtonImage != null)
        {
            Color newColor = clickedButtonImage.color;
            newColor.a = (newColor.a == initialAlpha) ? 1f : initialAlpha;
            clickedButtonImage.color = newColor;
        }

        playButton.DOAnchorPos(finalPosVector, time);
        // Update the selected button
        selectedButton = clickedButton;
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Show the information to the user
/// </summary>
public class CanvasUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI noticeText;
    [SerializeField]
    TextMeshProUGUI coinsUI;
    [SerializeField]
    float timeToShow;
    [SerializeField]
    Slider healthBar;
    [SerializeField]
    Image cardImage;
    [SerializeField]
    Sprite[] cardsToDisplay;

    private void Start()
    {
        
    }

    /// <summary>
    /// Update the current quantity of coins that the player has
    /// </summary>
    /// <param name="_coins"></param>
    public void UpdateCoinsValue(int _coins)
    {
        coinsUI.text = "X " + _coins.ToString();
    }

    /// <summary>
    /// Coroutine that shows a massage during a certain time
    /// </summary>
    /// <param name="_message"></param>
    /// <returns></returns>
    public IEnumerator ShowMessageCoroutine(string _message)
    {
        noticeText.text = _message;
        yield return new WaitForSeconds(timeToShow);
        noticeText.text = "";
    }

    /// <summary>
    /// this function start the coroutine
    /// </summary>
    /// <param name="_message"></param>
    public void ShowMessage(string _message)
    {
        StartCoroutine(ShowMessageCoroutine(_message));
    }

    /// <summary>
    /// this function get the state of the health and change the color in a certain value.
    /// </summary>
    /// <param name="_health"></param>
    public void HealthBar(int _health)
    {
        healthBar.value = _health;
        if(_health > 50)
        {
            healthBar.GetComponentInChildren<Image>().color = Color.green;
            cardImage.sprite = cardsToDisplay[0];
        }
        else if (_health > 20 && _health <= 50)
        {
            healthBar.GetComponentInChildren<Image>().color = Color.yellow;
            cardImage.sprite = cardsToDisplay[0];
        }
        else
        {
            healthBar.GetComponentInChildren<Image>().color = Color.red;
            cardImage.sprite = cardsToDisplay[1];
        }

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}

using System.Collections;
using UnityEngine;


/// <summary>
/// Every llama has assigned this script to substract the llama health every 3 seconda.
/// When the llama has the 20% o less of health send a notice to the player
/// finaly when the llama has 0 of health the llama is removed to from the llama manager and 
/// is destroyed
/// </summary>
public class TimerToRemove : MonoBehaviour
{
    [Header("FX")]
    [Tooltip("Drag the audio clip")]
    [SerializeField]
    AudioClip dieClip;
    AudioSource audioSource;
    
    LlamaPenManager llamaPenManager;
    LlamaProperties llamaProperties;
    CanvasUI canvasUI;
    //cerate a delegates events to subscribe
    public delegate void ChangeLifeEvent(GameObject llama);
    public delegate void DeleteLlamaEvent(GameObject llama);
    public event ChangeLifeEvent updateEvent;
    public event DeleteLlamaEvent deleteEvent;

    /// <summary>
    /// Get the llama properties, llama manager and canvasUI references
    /// </summary>
    private void Start()
    {
        llamaProperties = GetComponent<LlamaProperties>();
        llamaPenManager = FindObjectOfType<LlamaPenManager>();
        canvasUI = FindObjectOfType<CanvasUI>();
        audioSource = GameObject.Find("SoundFX").GetComponent<AudioSource>();
    }

    /// <summary>
    /// In this coroutine start 3 variable to control the flow and get the initial health of the llama.
    /// next the while begins and wait 3 seconds, after substract one from the llama health, then check 
    /// whether the event was added update the information in the llama information UI. 
    /// </summary>
    /// <returns></returns>

    public IEnumerator LlamaTimer()
    {
        bool isDead = false;
        bool flagShowMessage = false;
        int initHealth = llamaProperties.GetHealth();
        while (!isDead)
        {
            yield return new WaitForSeconds(3);
            llamaProperties.SetHealth(llamaProperties.GetHealth() - 1);
            if (updateEvent != null)
            {
                updateEvent(gameObject);
            }
            flagShowMessage = ConditionToShowMessage(initHealth, flagShowMessage);
            isDead = ConditionToDestroy(isDead);
        }
    }
    /// <summary>
    /// Check whether the health is less or equal zero, after that check if is suscribed 
    /// to a function that notice to the llama information canvas and change the color 
    /// if the llama dies when the user is watching the information in the panel
    /// </summary>
    /// <param name="_isDead">bool to know if the llama die</param>
    /// <returns></returns>
    bool ConditionToDestroy(bool _isDead)
    {
        if (llamaProperties.GetHealth() <= 0)
        {
            audioSource.PlayOneShot(dieClip);
            if (deleteEvent != null)
            {
                deleteEvent(gameObject);
            }
            _isDead = true;
            llamaPenManager.RemoveLlama(gameObject);
            FindObjectOfType<PoolingSystem>().DestroyObjects(gameObject);
        }
        return _isDead;
    }

    /// <summary>
    /// after that verify if the health is less than 20% of the initial health and 
    /// if is true show the message.
    /// </summary>
    /// <param name="_initHealth">Initial llama health</param>
    /// <param name="_flagShowMessage">bool to check if the message was sended</param>
    /// <returns></returns>
    bool ConditionToShowMessage(int _initHealth, bool _flagShowMessage)
    {
        if (llamaProperties.GetHealth() <= _initHealth * 0.2f && !_flagShowMessage)
        {
            canvasUI.ShowMessage("Llama low health");
            _flagShowMessage = true;
        }
        return _flagShowMessage;
    }

    /// <summary>
    /// if a coin is created, start a timer and the coin is deleted after wait some seconds
    /// </summary>
    /// <param name="_time"></param>
    /// <returns></returns>
    public IEnumerator CoinTimer(int _time)
    {
        yield return new WaitForSeconds(_time);
        Destroy(gameObject);
    }

}

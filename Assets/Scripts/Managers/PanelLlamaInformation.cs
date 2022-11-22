using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Manage the information panel and the llama manager
/// </summary>
public class PanelLlamaInformation : MonoBehaviour
{
    [SerializeField]
    LlamaPenManager llamaPenManager;
    [SerializeField]
    List<GameObject> llamasProperties;
    [SerializeField]
    GameObject prefabUIPanel;
    [SerializeField]
    List<LlamaPanelClass> llamaPanel = new List<LlamaPanelClass>();

    /// <summary>
    /// Get the reference to the llama manager
    /// </summary>
    private void Awake()
    {
        llamaPenManager = FindObjectOfType<LlamaPenManager>();
    }

    /// <summary>
    /// Get the list of the llamas from the llama manager and create a panel for each
    /// llama. Suscribe the events to y update event and delete event to Update information 
    /// and change color when die functions. after that get the item property and add the 
    /// llama and the panel to the list llamapanel
    /// </summary>
    public void CreateInformation()
    {
        llamasProperties = llamaPenManager.GetLlamaPropertiesList();
        foreach (GameObject llama in llamasProperties)
        {
            llama.GetComponent<TimerToRemove>().updateEvent += UpdateInformation;
            llama.GetComponent<TimerToRemove>().deleteEvent += ChangeColorWhenDie;
            LlamaProperties propertie = llama.GetComponent<LlamaProperties>();
            llamaPanel.Add(new LlamaPanelClass(llama, CreatePanelLlama(propertie)));
        }
    }

    /// <summary>
    /// Create the panel with the properties from the llama properties and return the panel
    /// </summary>
    /// <param name="_property">llama property</param>
    /// <returns>Panel game object</returns>
    GameObject CreatePanelLlama(LlamaProperties _property)
    {
        GameObject panelCreated = Instantiate(prefabUIPanel, transform);
        Transform panelTransfrom = panelCreated.transform;
        FillProperties(panelTransfrom, _property);
        return panelCreated;
    }

    /// <summary>
    /// when the llama dies, find the llama in the list, and remove it from the list 
    /// from the llama panel. unsuscribe all the events and change te color of the panel to red
    /// </summary>
    /// <param name="_llama">llama game object</param>
    public void ChangeColorWhenDie(GameObject _llama)
    {
        LlamaPanelClass llamaSelected;
        llamaSelected = llamaPanel.Find(x => x.llama == _llama);
        llamaPanel.Remove(llamaSelected);
        TimerToRemove timer = llamaSelected.llama.GetComponent<TimerToRemove>();
        timer.updateEvent -= UpdateInformation;
        timer.deleteEvent -= ChangeColorWhenDie;
        GameObject panel = llamaSelected.panel;
        panel.GetComponent<Image>().color = Color.red;
        
    }

    /// <summary>
    /// Unsuscribe all the events in each llama. 
    /// clean all the list.
    /// delete all the objects in the UI.
    /// </summary>
    public void CleanList()
    {
        
        foreach (LlamaPanelClass obj in llamaPanel)
        {
            obj.llama.GetComponent<TimerToRemove>().deleteEvent -= ChangeColorWhenDie;
            obj.llama.GetComponent<TimerToRemove>().updateEvent -= UpdateInformation; 
        }
        llamaPanel.Clear();
        for (int i = 1; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        
    }

    /// <summary>
    /// This event update all the properties from the llama (health, diet, age).
    /// </summary>
    /// <param name="_llama">llama game object</param>
    public void UpdateInformation(GameObject _llama)
    {
        LlamaPanelClass llamaSelected;
        llamaSelected = llamaPanel.Find(x => x.llama == _llama);
        LlamaProperties llamaProperty = llamaSelected.llama.GetComponent<LlamaProperties>();
        Transform panelTransform = llamaSelected.panel.transform;
        FillProperties(panelTransform, llamaProperty);
    }

    /// <summary>
    /// Access to the child components and put the information in the panel
    /// </summary>
    /// <param name="_panelTransform">panel to access to the child</param>
    /// <param name="_property">the llama properties</param>
    void FillProperties(Transform _panelTransform, LlamaProperties _property)
    {
        _panelTransform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _property.GetHealth().ToString();
        _panelTransform.GetChild(1).GetComponent<TextMeshProUGUI>().text = _property.GetDietType().ToString();
        _panelTransform.GetChild(2).GetComponent<TextMeshProUGUI>().text = _property.GetAge().ToString();
    }
}

/// <summary>
/// Class to save the information of the llama corresponding to the panel
/// </summary>
[Serializable]
public class LlamaPanelClass
{
    public GameObject llama;
    public GameObject panel;

    public LlamaPanelClass(GameObject _llama,GameObject _panel)
    {
        llama = _llama;
        panel = _panel;
    }
}

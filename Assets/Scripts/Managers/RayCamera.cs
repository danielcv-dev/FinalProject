using UnityEngine;

public class RayCamera : MonoBehaviour
{
    
    [SerializeField] Camera camera;
    [Header("Canvas to show")]
    [Tooltip("drag the canvas inventory")]
    [SerializeField] GameObject canvasInventory;
    [Tooltip("drag the canvas Store")]
    [SerializeField] GameObject canvasShop;
    [Tooltip("drag the canvas llama information")]
    [SerializeField] GameObject LlamasInformation;
    [SerializeField] bool isCanvasInteracion = false;
    
    /// <summary>
    /// Check if the user user push the left mouse button
    /// create a ray from the camera in the mouse position
    /// if the ray hit with comething select a action to
    /// execute
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                SelectAction(hit);
            }
        }
    }

    /// <summary>
    /// first of all check if we can interact with other things in the world, when is true 
    /// the canvas is active and we can't inteact with other thing in the environment.
    /// next check whether the tag that we hit with the ray. 
    /// floot: move the player
    /// house: active the inventory canvas
    /// store: active the store canvas
    /// FarmHouse: active the canvas information
    /// </summary>
    /// <param name="_hit"></param>
    public void SelectAction(RaycastHit _hit)
    {
        if (!isCanvasInteracion) 
        {
            switch (_hit.collider.tag)
            {
                case "Floor":
                    FindObjectOfType<PlayerMovement>().MoveAgent(_hit.point);
                    break;
                case "House":
                    canvasInventory.SetActive(true);
                    canvasInventory.GetComponentInChildren<InventoryManager>().ShowInventory();
                    ChangeBoolToInteract();
                    break;
                case "Store":
                    canvasShop.SetActive(true);
                    ChangeBoolToInteract();
                    break;
                case "FarmHouse":
                    LlamasInformation.SetActive(true);
                    LlamasInformation.GetComponentInChildren<PanelLlamaInformation>().CreateInformation();
                    ChangeBoolToInteract();
                    break;
            }
        }
        
    }

    public void ChangeBoolToInteract()
    {
        isCanvasInteracion = !isCanvasInteracion;
    }
}

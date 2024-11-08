using UnityEngine;

public class CanvasLayerAS : MonoBehaviour
{
    public Canvas mainCanvas;

    // Assign references to UI elements
    
    public GameObject asteroid;


    void Awake()
    {
        if (mainCanvas == null)
        {
            mainCanvas = GetComponent<Canvas>();
        }
        OrganizeLayers();
    }

    private void OrganizeLayers()
    {
        // Set sorting orders for main UI elements
        
        SetLayer(asteroid, 1);
   

       
    }

    private void SetLayer(GameObject uiElement, int sortingOrder)
    {
        Canvas elementCanvas = uiElement.GetComponent<Canvas>();

        // If there's no Canvas component, add one
        if (elementCanvas == null)
        {
            elementCanvas = uiElement.AddComponent<Canvas>();
        }

        elementCanvas.overrideSorting = true;
        elementCanvas.sortingOrder = sortingOrder;
    }
}
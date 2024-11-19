using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private UIInventoryPage inventoryUI;

    [SerializeField]
    private InventorySO inventoryData;



    private void Start()
    {
        PrepareUI();
        //inventoryData.Initialize();
    }

    private void PrepareUI()
    {
        inventoryUI.InitializeInventoryUI(inventoryData.Size);
        //this.inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
        //this.inventoryUI.OnSwapItems += HandleSwapItems;
        //this.inventoryUI.OnStartDragging += HandleStartDragging;
        //this.inventoryUI.OnItemActionRequested += HandleItemActionRequested;

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryUI.isActiveAndEnabled == false)
            {
                inventoryUI.Show();
                foreach (var item in inventoryData.GetCurrentInventoryState())
                {
                    inventoryUI.UpdateData(item.Key, item.Value.item.ItemImage, item.Value.quantity);
                }

            }
            else
            {
                inventoryUI.Hide();
            }

        }
    }
}

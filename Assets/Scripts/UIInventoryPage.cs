using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIInventoryPage : MonoBehaviour
{
    [SerializeField] private UIInventoryItem itemPrefab;

    [SerializeField] private RectTransform contentPanel;

    [SerializeField] private UIInventoryDescription itemDescription;

    List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

    public Sprite image;
    public int quantity;
    public string title, description;

    private void Awake()
    {
        Hide();
        itemDescription.ResetDescription();
    }
    public void InitializeInventoryUI(int inventorysize)
    {
        for (int i = 0; i < inventorysize; i++)
        {
            UIInventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            uiItem.transform.localScale = new Vector3(1, 1, 1);
            listOfUIItems.Add(uiItem);
            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemActions;
        }
    }

    private void HandleShowItemActions(UIInventoryItem obj)
    {
        
    }

    private void HandleEndDrag(UIInventoryItem obj)
    {
       
    }

    private void HandleSwap(UIInventoryItem obj)
    {
        
    }

    private void HandleBeginDrag(UIInventoryItem obj)
    {
        
    }

    private void HandleItemSelection(UIInventoryItem obj)
    {
        itemDescription.SetDescription(image, title, description);
        listOfUIItems[0].Select();
    }

    public void Show()
    {
        gameObject.SetActive (true);
        itemDescription.ResetDescription();

        listOfUIItems[0].SetData(image, quantity);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}

using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUse : MonoBehaviour
{
    [SerializeField]
    private EquippableItemSO key;

    [SerializeField]
    private InventorySO inventoryData;

    [SerializeField]
    private List<ItemParameter> parametersToModify, itemCurrentState;

    public void SetKey(EquippableItemSO keyItemSO, List<ItemParameter> itemState)
    {
        if (key != null)
        {
            inventoryData.AddItem(key, 1, itemCurrentState);
        }

        this.key = keyItemSO;
        this.itemCurrentState = new List<ItemParameter>(itemState);
        ModifyParameters();
    }

    private void ModifyParameters()
    {
        foreach (var parameter in parametersToModify)
        {
            if (itemCurrentState.Contains(parameter))
            {
                int index = itemCurrentState.IndexOf(parameter);
                float newValue = itemCurrentState[index].value + parameter.value;
                itemCurrentState[index] = new ItemParameter
                {
                    itemParameter = parameter.itemParameter,
                    value = newValue
                };
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// not used by current project
public class MissionBoard : MonoBehaviour {

    GameObject inventoryPanel;
    GameObject slotPanel;
    public GameObject inventorySlot;
    public GameObject inventoryItem;
    int slotAmount;
    public List<GameObject> items = new List<GameObject>();

    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        inventoryPanel = GameObject.Find("ChalkBoard");
        slotPanel = inventoryPanel.transform.Find("MissionPanel").gameObject;
        slotAmount = 5;
        
        for (int i = 0; i < slotAmount; i++)
        {

            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(slotPanel.transform);
            items.Add(Instantiate(inventoryItem));
            items[i].transform.SetParent(slots[i].transform);
        }

    }

}

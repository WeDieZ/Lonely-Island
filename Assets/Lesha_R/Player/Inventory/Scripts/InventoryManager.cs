using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Transform inventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public GameObject Inventory_Menu;
    public bool isOpen;
    public Camera mainCamera;
    public float reachDistance = 3f;
    public GameObject AIM;
    public GameObject CamAxis;

    private void Awake()
    {
        Inventory_Menu.SetActive(true);
    }


    void Start()
    {
        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            if (inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }

        Inventory_Menu.SetActive(false);
    }

    void Update()
    {
        var RotateCam = CamAxis.GetComponent<CameraRotation>();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;
            if (isOpen == true)
            {
                Inventory_Menu.SetActive (true);
                AIM.SetActive(false);
                RotateCam.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Inventory_Menu.SetActive(false);
                AIM.SetActive(true);
                RotateCam.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(ray, out hit, reachDistance))
            {
                if (hit.collider.gameObject.GetComponent<WTI>() != null)
                {
                    AddItem(hit.collider.gameObject.GetComponent<WTI>().item, hit.collider.gameObject.GetComponent<WTI>().amount);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    private void AddItem(ItemScriptable _item, int _amount)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == _item)
            {
                if (slot.amount + _amount <= _item.maxAmount)
                {
                slot.amount += _amount;
                slot.itemAmount.text = slot.amount.ToString();
                return;
                }
            }
        }
        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty == true)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                slot.itemAmount.text = _amount.ToString();
                break;
            }
        }
    }
}

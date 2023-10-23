using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using StoreNS;

public class EquipmentSlot : MonoBehaviour , IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private GameObject MyBaseEquipmentSlot;
    public void OnDrop(PointerEventData eventData)
    {
        if(name == "DiceSlot1")
        {
            Constant.nowDice[0] = ((ItemS)inventoryManager.CurrentDragItem).ItemNumber;
            GetComponent<Image>().sprite = Resources.LoadAll<Sprite>(Constant.DiceInfo[Constant.nowDice[0]].Path)[0];
        }
        else if(name == "DiceSlot2")
        {
            Constant.nowDice[1] = ((ItemS)inventoryManager.CurrentDragItem).ItemNumber;
            GetComponent<Image>().sprite = Resources.LoadAll<Sprite>(Constant.DiceInfo[Constant.nowDice[1]].Path)[0];
        }
        else if(name == "GunSlot1")
        {
            Constant.nowGun[0] = ((ItemS)inventoryManager.CurrentDragItem).ItemNumber;
            if(Constant.nowGun[0] != -1)
            {
                GetComponent<Image>().sprite = Resources.LoadAll<Sprite>(Constant.GunInfo[Constant.nowGun[0]].Path)[0];
                GetComponent<Image>().color = Color.white;
            }
                
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MyBaseEquipmentSlot.GetComponent<Image>().color = new Color(190 / 255f, 197 / 255f, 253 / 255f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MyBaseEquipmentSlot.GetComponent<Image>().color = new Color(111 / 255f, 111 / 255f, 111 / 255f);
    }



    /*public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(MyBaseEquipmentSlot.name);
        
    }*/

    /*public void OnPointerExit(PointerEventData eventData)
    {
        MyBaseEquipmentSlot.GetComponent<Image>().color = new Color(111 / 255f, 111 / 255f, 111 / 255f);
    }*/

    private void Awake()
    {
        if (name == "DiceSlot1")
            GetComponent<Image>().sprite = Resources.LoadAll<Sprite>(Constant.DiceInfo[Constant.nowDice[0]].Path)[0];
        else if(name == "DiceSlot2")
            GetComponent<Image>().sprite = Resources.LoadAll<Sprite>(Constant.DiceInfo[Constant.nowDice[1]].Path)[0];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* 메모 1
 * 아이템을 드래그 시작하거나 드래그해서 놓으면 이 스크립트가 드래그 아이템을
 * 파악하여 자식으로 분류해줌
 */




public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    private Image imgSlot;
    RectTransform rect;

    private Color saveColor;

    private void Awake()
    {
        imgSlot = GetComponent<Image>();
        rect = GetComponent<RectTransform>();

        saveColor = imgSlot.color;
    }
    
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        imgSlot.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        imgSlot.color = saveColor;
    }


    /// <summary>
    /// 이벤트 시스템으로 인해 드래그 되는 대상이 이 스크립트 위에서 드롭 되게 되면,
    /// 해당 드롭 오브젝트를 나의 자식으로 변경합니다
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (transform.childCount == 0)
            {
                Transform trsPointerDrag = eventData.pointerDrag.transform;
                trsPointerDrag.SetParent(transform);
                trsPointerDrag.position = rect.position;
            }
            else if (transform.childCount == 1) 
            {
                Transform OldItem = transform.GetChild(0);

                Transform trsHolding = eventData.pointerDrag.transform;
                ItemUI itemUI = trsHolding.GetComponent<ItemUI>();
                Transform BeforeParent = itemUI.BeforeParent;

                trsHolding.SetParent(transform);
                trsHolding.position = rect.position;
                
                RectTransform OldItemRect = BeforeParent.GetComponent<RectTransform>();
                OldItem.SetParent(BeforeParent);
                OldItem.position = OldItemRect.position;


                
            }
        }
    }


}

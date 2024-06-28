using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* �޸� 1
 * �������� �巡�� �����ϰų� �巡���ؼ� ������ �� ��ũ��Ʈ�� �巡�� ��������
 * �ľ��Ͽ� �ڽ����� �з�����
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
    /// �̺�Ʈ �ý������� ���� �巡�� �Ǵ� ����� �� ��ũ��Ʈ ������ ��� �ǰ� �Ǹ�,
    /// �ش� ��� ������Ʈ�� ���� �ڽ����� �����մϴ�
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

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
            Transform trsPointerDrag = eventData.pointerDrag.transform;
            trsPointerDrag.SetParent(transform);
            trsPointerDrag.position = rect.position;
        }
    }


}

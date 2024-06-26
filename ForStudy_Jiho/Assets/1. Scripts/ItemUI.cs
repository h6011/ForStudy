using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


// 드래그 가능한 인벤토리 아이템


public class ItemUI : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Transform canvas; // 드래그 할때 슬롯 UI뒤로 그려지는것을 방지하기 위해 잠깐 이용할 캔버스
    private Transform beforeParent; // 혹시 잘못된 위치에 드롭 하게되면 돌아오게 만들 위치

    private CanvasGroup canvasGroup; // 자식들을 통합 관리하는 컴포넌트
    private Image imgItem;
    [SerializeField] private string idx;

    public Transform BeforeParent => beforeParent;

    private void Awake()
    {
        initVars();
    }

    private void Start()
    {
        canvas = InventoryManager.Instance.CanvasInventory;
    }

    public void initVars()
    {
        if(canvasGroup == null) { canvasGroup = GetComponent<CanvasGroup>(); }
        if(imgItem == null) { imgItem = GetComponent<Image>(); }
    }

    /// <summary>
    /// idx 넘버를 전달 받으면 해당 아이템을 Json 으로 부터 검색하여 찾고,
    /// 해당 아이템 데이터에서 필요한 정보만을 가져와서 해당 스크립트에 채워줌
    /// </summary>
    /// <param name="_idx">아이템의 인덱스 넘버</param>
    public void SetItem(string _idx)
    {
        idx = _idx;
        string spriteName = JsonManager.Instance.GetSpriteNameFromIdx(_idx);
        Sprite sprite = SpriteManager.Instance.GetSprite(spriteName);

        initVars();
        imgItem.sprite = sprite;

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        beforeParent = transform.parent;

        transform.SetParent(canvas);

        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.parent == canvas)
        {
            transform.SetParent(beforeParent);
            transform.position = beforeParent.position;
        }

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
}

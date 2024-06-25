using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [SerializeField] GameObject viewInventory; // �κ��丮 ��
    [SerializeField] GameObject fabItem; // �κ��丮�� ������ ������

    List<Transform> listTrsInventory = new List<Transform>();




    private void Awake() { singletonAction(); }

    private void Start() { initInventory(); }

    /// <summary>
    /// �κ��丮 �ʱ�ȭ �Լ�
    /// </summary>
    private void initInventory()
    {
        listTrsInventory.Clear();
        Transform[] childs = viewInventory.transform.GetComponentsInChildren<Transform>();

        listTrsInventory.AddRange(childs);
        listTrsInventory.RemoveAt(0);

        


    }

    /// <summary>
    /// �̱��� ���� (InventoryManager.Instance)
    /// </summary>
    private void singletonAction()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }


    /// <summary>
    /// �κ��丮�� �����ִٸ� ����, ���� �ִٸ� ������ (Toggle)
    /// </summary>
    public void InActiveInventory()
    {
        if (viewInventory.activeSelf)
        {
            viewInventory.SetActive(false);

        }
        else
        {
            viewInventory.SetActive(true);

        }


    }


    /// <summary>
    /// ����ִ� �κ��丮 �ѹ��� ���� �մϴ�.
    /// </summary>
    /// <returns>����ִ� ������ ���� ��ȣ</returns>
    private int getEmptyItemSlot()
    {
        int count = listTrsInventory.Count;
        for (int iNum = 0; iNum < count; iNum++)
        {
            Transform trsSlot = listTrsInventory[iNum];
            if (trsSlot.childCount == 0)
            {
                return iNum;
            }


        }

        return -1;


    }



}
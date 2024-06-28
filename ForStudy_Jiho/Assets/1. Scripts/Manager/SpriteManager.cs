using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public static SpriteManager Instance;

    [SerializeField] List<Sprite> allSprites;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }


    /// <summary>
    /// [New!] ���ٽ����� ��������Ʈ ���ϴ� ���
    /// </summary>
    /// <param name="_spriteName">��������Ʈ �̸�</param>
    /// <returns></returns>
    public Sprite GetSprite(string _spriteName)
    {
        return allSprites.Find(a => a.name == _spriteName);
    }

    /// <summary>
    /// for �� ��������Ʈ ���ϴ� ��� (����)
    /// </summary>
    /// <param name="_spriteName">��������Ʈ �̸�</param>
    /// <returns></returns>
    public Sprite OldGetSprite(string _spriteName)
    {
        int count = allSprites.Count;

        for (int iNum = 0; iNum < count; iNum++)
        {
            Sprite sprite = allSprites[iNum];
            if (sprite.name == _spriteName)
            {
                return sprite;
            }
        }
        return null;

    }



}

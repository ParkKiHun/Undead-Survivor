using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // ��������� ������ ����
    public GameObject[] prefabs;

    // Ǯ ����� �ϴ� ����Ʈ
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for(int index = 0; pools.Length > index; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // ������ Ǯ�� ���(��Ȱ��ȭ ��) �ִ� ���ӿ�����Ʈ ����
        foreach(GameObject item in pools[index])
        {
            // �߰��ϸ� select ������ �Ҵ�
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // �� ã������?
        if (select == null)
        {
            // ���Ӱ� �����ؼ� select�� ������ �Ҵ�
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }
        
        return select;
    }
}

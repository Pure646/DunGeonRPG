using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScrollerScript : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab; // �츮�� ���� "Item"
    [SerializeField] private Transform content;      // Scroll View > Viewport > Content

    private void Start()
    {
        //for (int i = 0; i < 20; i++)
        //{
        //    GameObject item = Instantiate(itemPrefab, content); // �����ؼ� content�� ���̱�
        //    item.GetComponentInChildren<Text>().text = $"������ {i + 1}"; // �ؽ�Ʈ �ٲٱ�
        //}
    }
}

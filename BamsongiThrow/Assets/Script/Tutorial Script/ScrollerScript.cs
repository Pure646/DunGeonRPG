using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScrollerScript : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab; // 우리가 만든 "Item"
    [SerializeField] private Transform content;      // Scroll View > Viewport > Content

    private void Start()
    {
        //for (int i = 0; i < 20; i++)
        //{
        //    GameObject item = Instantiate(itemPrefab, content); // 복사해서 content에 붙이기
        //    item.GetComponentInChildren<Text>().text = $"아이템 {i + 1}"; // 텍스트 바꾸기
        //}
    }
}

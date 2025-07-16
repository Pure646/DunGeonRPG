using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InstanScroll : MonoBehaviour
{
    [SerializeField] private Transform Content;

    [SerializeField] private RectTransform RectContent;

    [SerializeField] private ScrollRect ScrollView;

    [SerializeField] private GameObject[] Skill_Image;

    [SerializeField] private Scrollbar VerticalScroll;

    private int ContentChild_Count = 9;
    private enum ScrollEdgeState
    {
        None,     // 중간
        AtTop,    // 맨 위
        AtBottom  // 맨 아래
    }
    private ScrollEdgeState scrollState = ScrollEdgeState.None;

    private void Start()
    {
        //ScrollView.onValueChanged.AddListener(Jex);         // 스크롤 값이 바뀔 때 이벤트 발생
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            RandomImage();
        }
        ImageCounting();

        if (VerticalScroll.value <= 0.002f && scrollState != ScrollEdgeState.AtBottom)
        {
            scrollState = ScrollEdgeState.AtBottom;
            Debug.Log("Down");
        }
        else if(VerticalScroll.value >= 0.998f && scrollState != ScrollEdgeState.AtTop)
        {
            scrollState = ScrollEdgeState.AtTop;
            Debug.Log("Up");
        }
        else if(VerticalScroll.value > 0.002f && VerticalScroll.value < 0.998f && scrollState != ScrollEdgeState.None)
        {
            scrollState = ScrollEdgeState.None;
        }
    }
    private void Jex(Vector2 Vec)
    {
        Debug.Log("안녕");
    }
    private void RandomImage()
    {
        int random = Random.Range(0, Skill_Image.Length);
        GameObject Instan = Instantiate(Skill_Image[random], Content, false);
    }
    private void ImageCounting()
    {
        if (Content.childCount >= ContentChild_Count)
        {
            ContentChild_Count += 3;
            Vector2 size = RectContent.sizeDelta;
            size.y += 52f;
            RectContent.sizeDelta = size;
        }
    }
}

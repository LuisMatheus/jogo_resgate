using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public GameObject icon;
    List<QuestMarks> marks = new List<QuestMarks>();
     public RawImage compassImage;
    public Transform player;
    private float compassUnit;
    public float distance = 200f;
    public QuestMarks one;
    public QuestMarks two;

    private void Start()
    {
        compassUnit = compassImage.rectTransform.rect.width / 360f;
        
        AddQuestMark(one);
        AddQuestMark(two);
    }

    // Update is called once per frame
    void Update()
    {
        // make sprite have 0 degree to 360 degree -> cyclone sprite
        compassImage.uvRect = new Rect(player.localEulerAngles.y / 360f, 0f, 1f, 1f);
        foreach (var mark in marks)
        {
            mark.image.rectTransform.anchoredPosition = positionOnCompass(mark);
            float dst = Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.z),
                mark.position);
            float scale = 0f;

            if (dst < distance)
            {
                scale = 1f - (dst / distance);
            }
            mark.image.rectTransform.localScale = Vector3.one * scale;
        }
    }

    // Add new marks to compass
    public void AddQuestMark(QuestMarks mark)
    {
        GameObject newMarker = Instantiate(icon, compassImage.transform);
        mark.image = newMarker.GetComponent<Image>();
        mark.image.sprite = mark.icon;
        
        marks.Add(mark);
    }
    
    // Get position of marks based on player position on compass
    Vector2 positionOnCompass(QuestMarks mark)
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.z);
        Vector2 playerFwd = new Vector2(player.transform.forward.x, player.transform.forward.z);

        float angle = Vector2.SignedAngle(mark.position - playerPos, playerFwd);

        return new Vector2(compassUnit*angle, 0f);
    }
}

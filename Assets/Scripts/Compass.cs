using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public GameObject markPrefab;
    public List<Marks> marks = new List<Marks>();
    public RawImage compassImg;
    public Transform player;
    public float maxDistance;
    private float compassUnit;
    

    public Marks any1;
    public Marks any2;
    public Marks any3;

    public void Start()
    {
        // Give degree of rotation to the compass image
        compassUnit = compassImg.rectTransform.rect.width / 360;

        AddMarks(any1);
        AddMarks(any2);
        AddMarks(any3);

        // if not set above 0 in public Unity auto-cast to 200
        if (maxDistance == 0)
        {
            maxDistance = 200f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // command to make compass loop in a 360 degree -> img start on 0 until 360
        compassImg.uvRect = new Rect(player.localEulerAngles.y / 360, 0f, 1f, 1f);

        foreach (Marks m in marks)
        {
            m.image.rectTransform.anchoredPosition = PositionOnCompass(m);

            // Scale image based on distance of the player from mark
            var position = player.transform.position;
            float distance = Vector2.Distance(new Vector2(position.x, position.z), m.position);
            float scale = 0f;
            if (distance < maxDistance)
            {
                scale = 1f - (distance / maxDistance);
            }

            // command to modify the scale of Marks
            m.image.rectTransform.localScale = Vector3.one * scale;
        }
    }

    // add marks
    public void AddMarks(Marks mark)
    {
        // get prefab to init in compass in game
        GameObject newMark = Instantiate(markPrefab, compassImg.transform);
        mark.image = newMark.GetComponent<Image>();
        mark.image.sprite = mark.icon;
        marks.Add(mark);
    }

    Vector2 PositionOnCompass(Marks mark)
    {
        var playerTransform = player.transform;
        var position = playerTransform.position;
        var forward = playerTransform.forward;

        Vector2 playerPosition = new Vector2(position.x, position.z);
        Vector2 playerForward = new Vector2(forward.x, forward.z);

        float angle = Vector2.SignedAngle(mark.position - playerPosition, playerForward);

        return new Vector2(compassUnit * angle, 0f);
    }
}
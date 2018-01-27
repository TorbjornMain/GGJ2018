﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PosessionUIManager : MonoBehaviour {
    List<PosessionWidget> widgets;
    public PosessionWidget widgetPrefab;
    PosessionManager pm;
    RectTransform r;
    public Color posessableColour = Color.green;
    public Color nonPosessableColour = Color.red;
    public AnimationCurve distanceScaleCurve;
    public float distanceScale = 100.0f;

    void Start()
    {
        pm = FindObjectOfType<PosessionManager>();
        r = GetComponent<RectTransform>();
        widgets = new List<PosessionWidget>();
        foreach (var item in pm.levelPawns)
        {
            PosessionWidget pw = Instantiate(widgetPrefab, r);
            pw.gameObject.SetActive(false);
            widgets.Add(pw);
        }
    }

    void Update()
    {
        if (pm.WidgetPositions == null)
            return;
        for(int i = 0; i < pm.WidgetPositions.Count; i++)
        {
            widgets[i].gameObject.SetActive(true);
            Vector2 viewportPosToScreenPos = new Vector2((pm.WidgetPositions[i].screenSpacePosition.x * r.sizeDelta.x) - (r.sizeDelta.x * 0.5f), (pm.WidgetPositions[i].screenSpacePosition.y * r.sizeDelta.y) - (r.sizeDelta.y * 0.5f));
            widgets[i].image.rectTransform.localPosition = viewportPosToScreenPos;
            widgets[i].image.color = widgets[i].text.color = pm.WidgetPositions[i].isPossessable ? posessableColour : nonPosessableColour;
            widgets[i].image.rectTransform.localScale = Vector3.one *  distanceScaleCurve.Evaluate(pm.WidgetPositions[i].distance / distanceScale);
            widgets[i].text.text = pm.WidgetPositions[i].ID.ToString("000");
        }
        for(int i = pm.WidgetPositions.Count; i < widgets.Count; i++)
        {
            widgets[i].gameObject.SetActive(false);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public float maxValue;
    private float currentValue = 1f;
    public RectTransform fill;
    private Transform player;

    void Start(){
        player = FindObjectOfType<PlayerController>().transform;
    }

    void Update(){
        this.transform.LookAt(player, Vector3.up);

        fill.localScale = new Vector3(currentValue, 1f, 1f);
    }

    public void SetValue(float value){
        currentValue = value / maxValue;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RacketController : MonoBehaviour
{
    [SerializeField] private Slider RocketSlider = null;
    [SerializeField] private Transform BorderLeft = null;
    [SerializeField] private Transform BorderRight = null;
  
    private float MinX, MaxX;
   
    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        MinX = BorderLeft.position.x - spriteRenderer.bounds.min.x;
        MaxX = BorderRight.position.x + spriteRenderer.bounds.min.x;
        RocketSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }
    private void ValueChangeCheck()
    {
        Vector3 position = transform.position;
        float distance = MaxX - MinX;
        transform.position = new Vector3(MinX + distance * RocketSlider.value, position.y, position.z);
    }
}

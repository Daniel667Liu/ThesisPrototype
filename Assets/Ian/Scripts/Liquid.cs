using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : MonoBehaviour
{
    public float fillSpeed;
    public float filledY;
    public Transform currentLiquid;

    public bool fill;
    public Color fillingColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fill)
        {
            if (currentLiquid.localScale.y < filledY)
            {
                FillCurrentLiquid();
            }
        }
    }

    public void FillCurrentLiquid()
    {
        float currentLiquidAmount = currentLiquid.localScale.y;

        float delta = Time.deltaTime * fillSpeed;
        currentLiquid.localScale += Vector3.up * delta;
        currentLiquid.position += Vector3.up * delta / 2f;

        Color oldColorPortion = (currentLiquidAmount / currentLiquid.localScale.y) * currentLiquid.GetComponent<SpriteRenderer>().color;
        Color newColorPortion = (delta / currentLiquid.localScale.y) * fillingColor;

        currentLiquid.GetComponent<SpriteRenderer>().color = oldColorPortion + newColorPortion;

    }

    public void StartFilling(Color col)
    {
        fillingColor = col;
        fill = true;
    }

    public void EndFilling()
    {
        fill = false;
    }
}

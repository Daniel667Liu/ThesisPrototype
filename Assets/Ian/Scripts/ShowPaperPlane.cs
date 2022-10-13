using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPaperPlane : MonoBehaviour
{
    public GameObject paperplane;

    public void ShowPP()
    {
        paperplane.SetActive(true);
    }
}

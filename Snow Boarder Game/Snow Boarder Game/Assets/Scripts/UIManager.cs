using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image[] healthIcons;

    public void SetHealth(int newHp)
    {
        for (int i = 0; i < healthIcons.Length; i++)
        {
            if (newHp > i)
            {
                healthIcons[i].gameObject.SetActive(true);
            }
            else
            {
                healthIcons[i].gameObject.SetActive(false);
            }
        }
    }
}

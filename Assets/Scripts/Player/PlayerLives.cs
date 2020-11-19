using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int maxLives = 4;
    public int currentPlayerLives;

    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;

    void Start()
    {
        currentPlayerLives = maxLives;
        image1.color = new Color(145f / 255f, 203f / 255f, 250f / 255f);
        image2.color = new Color(145f / 255f, 203f / 255f, 250f / 255f);
        image3.color = new Color(145f / 255f, 203f / 255f, 250f / 255f);
        image4.color = new Color(145f / 255f, 203f / 255f, 250f / 255f);
    }

    void Update()
    {
        if (currentPlayerLives > 4)
        {
            currentPlayerLives = 4;
            image1.color = new Color(145f / 255f, 203f / 255f, 250f / 255f);
            image2.color = new Color(145f / 255f, 203f / 255f, 250f / 255f);
            image3.color = new Color(145f / 255f, 203f / 255f, 250f / 255f);
            image4.color = new Color(145f / 255f, 203f / 255f, 250f / 255f);
        }

        if (currentPlayerLives == 4)
        {
            image1.color = new Color(145f / 255f, 203f / 255f, 250f / 255f);
            image2.color = new Color(145f / 255f, 203f / 255f, 250f / 255f);
            image3.color = new Color(145f / 255f, 203f / 255f, 250f / 255f);
            image4.color = new Color(145f / 255f, 203f / 255f, 250f / 255f);
            return;
        }

        if (currentPlayerLives == 3)
        {
            image1.color = new Color(130f / 255f, 130f / 255f, 130f / 255f);
        }

        if (currentPlayerLives == 2)
        {
            image2.color = new Color(130f / 255f, 130f / 255f, 130f / 255f);
        }

        if (currentPlayerLives == 1)
        {
            image3.color = new Color(130f / 255f, 130f / 255f, 130f / 255f);
        }

        if (currentPlayerLives == 0)
        {
            image4.color = new Color(130f / 255f, 130f / 255f, 130f / 255f);
        }
    }
}

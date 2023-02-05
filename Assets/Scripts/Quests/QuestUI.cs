using System.Collections;
using System.Collections.Generic;
using Pickups;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    public Image slot1;
    public Image slot2;
    public Image slot3;
    public Image slot4;
    public Image slot5;

    public void FillQuestUI(List<PickupType> tasks)
    {
        if (tasks.Count >= 1)
        {
            slot1.sprite = (tasks[0]) ? tasks[0].image : null;
        }
        else
        {
            slot1.sprite = null;
        }

        if (tasks.Count >= 2)
        {
            slot2.sprite = (tasks[1]) ? tasks[1].image : null;
        }
        else
        {
            slot2.sprite = null;
        }

        if (tasks.Count >= 3)
        {
            slot3.sprite = (tasks[2]) ? tasks[2].image : null;
        }
        else
        {
            slot3.sprite = null;
        }

        if (tasks.Count >= 4)
        {
            slot4.sprite = (tasks[3]) ? tasks[3].image : null;
        }
        else
        {
            slot4.sprite = null;
        }

        if (tasks.Count >= 5)
        {
            slot5.sprite = (tasks[4]) ? tasks[4].image : null;
        }
        else
        {
            slot5.sprite = null;
        }
    }
}
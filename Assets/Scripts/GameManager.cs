using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] ConvManager convManager;

    private void Update()
    {
        ActionStop();
    }

    void ActionStop()
    {
        if (convManager.isAction) return;

        
    }
}

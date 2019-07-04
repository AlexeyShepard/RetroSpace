using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultSelection : MonoBehaviour
{
    public static int difficultValue = 2;

    public void SetUpDifficult(int Index)
    {
        difficultValue = Index;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSetActiveFalse : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject pausePanel = GameObject.FindGameObjectWithTag("PauseMenu");

        pausePanel.SetActive(false);
    }
}

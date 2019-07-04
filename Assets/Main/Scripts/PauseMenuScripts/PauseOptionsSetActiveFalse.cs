using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOptionsSetActiveFalse : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject pauseOptions = GameObject.FindGameObjectWithTag("PauseOptions");

        pauseOptions.SetActive(false);
    }
}

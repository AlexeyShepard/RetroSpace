using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject mainPanel = GameObject.FindGameObjectWithTag("PauseMenu");
        GameObject optionsPanel = GameObject.FindGameObjectWithTag("PauseOptions");
        GameObject canvas = GameObject.FindGameObjectWithTag("PauseMenuAll");

        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        canvas.SetActive(false);
    }
}

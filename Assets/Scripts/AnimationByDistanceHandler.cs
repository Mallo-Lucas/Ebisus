using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationByDistanceHandler : MonoBehaviour
{
    [SerializeField] private List<AnimationNode> animationLine = new();

    private void Start()
    {
        StartCoroutine(CheckAnimationTimeline());
    }

    private IEnumerator CheckAnimationTimeline()
    {
        while(animationLine.Count > 0)
        {
            for (int i = 0; i < animationLine.Count; i++)
            {
                if (animationLine[i].CanExecuteAnimation())
                {
                    animationLine[i].ExecuteAnimation();
                    animationLine.Remove(animationLine[i]);
                }
            }
            yield return null;
        }
    } 
}

[Serializable]
public class AnimationNode
{
    public Transform targetToCompareDistance;
    public Animator animatorToExecute;
    public string animationNodeName;
    public float distanceToExecute;

    public bool CanExecuteAnimation()
    {
        float distance = Vector3.Distance(targetToCompareDistance.position, animatorToExecute.transform.position);

        if (distance <= distanceToExecute)
            return true;

        return false;
    }

    public void ExecuteAnimation()
    {
        animatorToExecute.CrossFade(animationNodeName,0.2f);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class DialogueHolder : MonoBehaviour
    {
        [SerializeField] GameObject _introShopPanel;
        [SerializeField] GameObject _shopMenuPanel;
        private void Awake()
        {
            StartCoroutine(DialogueSequence());
        }
        private IEnumerator DialogueSequence()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Deactivate();
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().IsFinished);
            }
            _introShopPanel.SetActive(false);
            _shopMenuPanel.SetActive(true);
        }

        private void Deactivate()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
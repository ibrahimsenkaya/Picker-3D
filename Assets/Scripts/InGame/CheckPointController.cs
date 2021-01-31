using System;
using System.Collections;
using System.Collections.Generic;
using InGame;
using UnityEngine;
using TMPro;


public class CheckPointController : MonoBehaviour
{
    [SerializeField] int Counter;
    [SerializeField] private IS_VoidEvent levelLoseEvent;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI CounterText;
    [SerializeField] Transform Picker;
    private List<GameObject> collactables=new List<GameObject>();
    private int MinCount = 15;
    private Animator animator;

    private void Start()
    {
        Picker = transform.parent.GetComponent<CreateLevelForStart>().picker.transform;
        animator = GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Collectable")
        {
            Counter++;
            CounterText.text = Counter.ToString();
            collactables.Add(col.gameObject);
        }
    }

    public IEnumerator CheckLetPickerMove()
    {
        yield return new WaitForSeconds(3f);
        foreach (var item in collactables)
        {
           
            Destroy(item);
     
        }

        if (Counter >= MinCount)
        {
            animator.SetTrigger("Up");
            foreach (var item in GetComponentsInChildren<ParticleSystem>())
            {
                item.Play();
            }
            yield return new WaitForSeconds(2f);
            Picker.GetComponent<PickerMove>().Stop = false;
            
        }
        else
        {
            levelLoseEvent.Raise();
        }
    }
}
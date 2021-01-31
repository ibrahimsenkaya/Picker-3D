using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PickerMove : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] IS_VoidEvent LevelEndEvent;
    [SerializeField] IS_VoidEvent nextlevelEvent;
    [SerializeField] IS_VoidEvent CheckPointEvent;
    [SerializeField] LevelAsset levelAsset;
    private TouchController touchcontroller;
    [SerializeField] private ChangeCameras changecameras;
    private bool cancreateNewLevel = true;
    Rigidbody _rb;
    float _PickerZpos;

    public bool Stop;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        touchcontroller = GetComponent<TouchController>();
    }

    void FixedUpdate()
    {
        if (!Stop)
        {
            var x = (speed * Time.fixedDeltaTime);
            //transform.Translate(new Vector3(x, 0, 0));
            var PickerPos = transform.position + new Vector3(x, 0, 0);


            PickerPos.z += touchcontroller.difX;
            PickerPos.z = Mathf.Clamp(PickerPos.z, -1.4f, 1.4f);

            _rb.MovePosition(PickerPos);
        }
        else
        {
            _rb.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Checkpoint")
        {
            Debug.Log("girdi");
            StartCoroutine(col.GetComponent<CheckPointController>().CheckLetPickerMove());
            CheckPointEvent.Raise();
            Stop = true;
        }

        if (col.tag == "Finish")
        {
            levelAsset.CurrrentLevel += 1;
            LevelEndEvent.Raise();

            Debug.Log("fiiinnnn");
            Stop = true;
        }

        if (col.CompareTag("LevelEnd") && cancreateNewLevel)
        {
            changecameras.ChangeCameraLevelEnd();
            nextlevelEvent.Raise();
            cancreateNewLevel = false;
            StartCoroutine(PrepareFornewlevel());
        }

        if (col.CompareTag("LevelStart"))
        {
            changecameras.ChangeCameraLevelStart();
        }
    }

    public void MoveThrough()
    {
        Stop = false;
        float tempspeed = speed;
        speed = 0;
        DOTween.To(() => speed, x => speed = x, tempspeed, 1);
    }

    IEnumerator PrepareFornewlevel()
    {
        yield return new WaitForSeconds(1f);

        cancreateNewLevel = true;
    }
}
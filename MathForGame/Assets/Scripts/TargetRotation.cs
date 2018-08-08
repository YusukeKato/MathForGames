using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TargetRotation : MonoBehaviour {

    public GameObject Target;
    public Text ClickPositionText;
    public float speed = 10;

    void Update()
    {
        if(Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            ClickPositionText.text = string.Format("click:{0}", Input.mousePosition);
            TargetRotateFunc(Input.mousePosition);
        }
    }

    void TargetRotateFunc(Vector3 mp)
    {
        Vector3 sp = Camera.main.WorldToScreenPoint(Target.transform.position);
        Vector3 d = sp - mp;
        float angle = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg - 90f;
        float r = Mathf.LerpAngle(Target.transform.eulerAngles.z, angle, Time.deltaTime * speed);
        Target.transform.eulerAngles = new Vector3(0, 0, r);
    }
}

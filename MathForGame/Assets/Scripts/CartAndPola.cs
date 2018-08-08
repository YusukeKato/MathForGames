using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CartAndPola : MonoBehaviour {

    public GameObject Target;
    public GameObject Origin;
    private int r = 3;
    private float speed = 8;
	
	void Update () {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            //Debug.Log(string.Format("mouse:{0}", Input.mousePosition));
            TargetRotation(Input.mousePosition);
        }
    }

    void TargetRotation(Vector3 mp)
    {
        Vector3 tp = Camera.main.WorldToScreenPoint(Target.transform.position);
        Vector3 op = Camera.main.WorldToScreenPoint(Origin.transform.position);
        Vector3 d1 = tp - op;
        Vector3 d2 = mp - op;
        float angle1 = Mathf.Atan2(d1.y, d1.x);
        float angle2 = Mathf.Atan2(d2.y, d2.x);
        Debug.Log(string.Format("a1:{0}, a2:{0}", angle1, angle2));
        float theta = Mathf.LerpAngle(angle1, angle2, Time.deltaTime * speed);
        Vector3 xyz = new Vector3(Mathf.Cos(theta) * r, Mathf.Sin(theta) * r, 0);
        Target.transform.position = xyz;
    }
}

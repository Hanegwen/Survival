using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreditScroll : MonoBehaviour {

    public AnimationCurve curve;
    public Vector3 PointA, PointB;
    [SerializeField]
    float Time;
    

    // Use this for initialization
    void Start ()
    {
        curve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(500, 0));
        curve.preWrapMode = WrapMode.PingPong;
        curve.postWrapMode = WrapMode.PingPong;

    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.localPosition =  Vector3.Lerp(PointA,PointB,curve.Evaluate(Time));

    }
}

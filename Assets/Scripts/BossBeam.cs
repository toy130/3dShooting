using Mono.Cecil.Cil;
using System.Collections;
using UnityEngine;

public class BossBeam : MonoBehaviour
{
    private float speed = 7f;
    private LineRenderer line;
    [SerializeField] float RayLength = 1000f;

    private Vector3 BeamPosition = Vector3.zero;
    private Vector3 start;
    private Vector3 end;
    enum BeamState {
        Idle,
        Prediction,
        Firing,
    }
    private BeamState previousBeamState = BeamState.Idle;
    private BeamState beamState = BeamState.Idle;
    private int elapsedTime = 0;
    [SerializeField] float BeamSpan = 10f;
    [SerializeField] float FireSpan = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        previousBeamState = beamState;
        elapsedTime++;
        if(elapsedTime == BeamSpan)
        {
            beamState = BeamState.Prediction;
            BeamPosition = new Vector3 {x = Random.Range(-5f, 5f), y = 5f + Random.Range(-5f, 0f), z = 0};
        }
        if(elapsedTime == BeamSpan + FireSpan)
        {
            beamState = BeamState.Firing;
        }
        if(previousBeamState != beamState)
        {
            switch (beamState) {
                case BeamState.Idle:
                    break;
                case BeamState.Prediction:
                    start = transform.position + BeamPosition;
                    break;
                case BeamState.Firing:
                    break;
            }
        }
        switch (beamState)
        {
            case BeamState.Idle:
                break;
            case BeamState.Prediction:
                end = start + transform.forward * RayLength;
                line.SetPosition(0, start);
                line.SetPosition(1, end);
                RayLength = 1000f;
                if (Physics.SphereCast(start, 1,transform.forward,out RaycastHit hit,1000f))
                {
                    RayLength = hit.distance;
                }
                break;
            case BeamState.Firing:
                line.SetPosition(0, start);
                line.SetPosition(1, end);
                RayLength = 1000f;
                if (Physics.Raycast(start, transform.forward, out RaycastHit hit2, RayLength))
                {
                    Debug.Log("hit");
                }
                beamState = BeamState.Idle;
                elapsedTime = 0;
                break;
        }
    }
}

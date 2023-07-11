using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTool : MonoBehaviour
{
    [Header("References")]
    private PlayerMove pm;
    public Transform player;
    public Transform gunTip;
    public LayerMask whatIsGrappleable;
    public LineRenderer lr;

    [Header("Grappling")]
    public float maxGrappleDistance;
    public float grappleDelayTime;

    public float overshootYAxis;
    public Vector3 grapplePoint;

    [Header("Cooldown")]
    public float grapplingCd;
    private float grapplingCdTimer;

    [Header("Input")]
    public KeyCode grappleKey = KeyCode.Mouse1;

    private bool grappling;

    // Start is called before the first frame update
    private void Start()
    {
        pm = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(grappleKey)) StartGrapple();

        // count down timer
        if (grapplingCdTimer > 0) {
            grapplingCdTimer -= Time.deltaTime;
        }
    }

    private void LateUpdate()
    {
        if (grappling) {
            // continuously update line start position to be at gun tip
            lr.SetPosition(0, gunTip.position);
        }
    }

    private void StartGrapple()
    {
        if (grapplingCdTimer > 0) return;

        grappling = true;

        pm.freeze = true;

        RaycastHit hit;
        if (Physics.Raycast(player.position, player.forward, out hit, maxGrappleDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;

            Invoke(nameof(ExecuteGrapple), grappleDelayTime);
        }
        else {
            // set grapple point to max distance
            grapplePoint = player.position + player.forward * maxGrappleDistance;

            Invoke(nameof(StopGrapple), grappleDelayTime);
        }

        lr.enabled = true;
        lr.SetPosition(1, grapplePoint);


    }

    private void ExecuteGrapple()
    {
        pm.freeze = false;

        // calculate lowest point of player
        Vector3 lowestPoint = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);

        // difference of y axis between player and grapple point
        float grapplePointRelativeYPos = grapplePoint.y - lowestPoint.y;
        // add overshoot y axis on top of this
        float highestPointOnArc = grapplePointRelativeYPos + overshootYAxis;

        // if point is below player, just use overshoot y axis without other calcs
        if (grapplePointRelativeYPos < 0) highestPointOnArc = overshootYAxis;

        // passes in grapple point at highest point just calced
        pm.JumpToPosition(grapplePoint, highestPointOnArc);

        Invoke(nameof(StopGrapple), 1f);
    }

    public void StopGrapple()
    {
        pm.freeze = false;

        grappling = false;

        grapplingCdTimer = grapplingCd;

        lr.enabled = false;
    }

}

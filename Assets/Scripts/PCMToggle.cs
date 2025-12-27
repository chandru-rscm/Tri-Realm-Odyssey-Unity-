using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonPath : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 10f;
    public float rotateSpeed = 5f;

    [Header("Waterfall")]
    public Transform waterfallPoint;

    [Header("Mountains")]
    public Transform[] mountainPoints;
    private int mountainIndex = 0;

    [Header("Houses")]
    public Transform[] housePoints;
    private int houseIndex = 0;

    [Header("Ship Circle")]
    public Transform shipCenter;
    public float shipCircleRadius = 20f;
    public int shipCircleLoops = 1;
    public float shipCircleHeight = 10f;
    private float shipAngle = 0f;

    [Header("Castle Hover & Land")]
    public Transform[] castleHoverPoints;
    private int castleIndex = 0;
    public Transform castleLandPoint;

    [Header("King")]
    public Transform kingLookAt;

    private enum State
    {
        ToWaterfall,
        ThroughMountains,
        ThroughHouses,
        CircleShip,
        HoverCastle,
        ToCastleLand,
        MeetKing,
        Done
    }

    private State state = State.ToWaterfall;

    void Update()
    {
        switch (state)
        {
            case State.ToWaterfall:
                MoveToPoint(waterfallPoint, State.ThroughMountains);
                break;

            case State.ThroughMountains:
                MoveAlongPoints(mountainPoints, ref mountainIndex, State.ThroughHouses);
                break;

            case State.ThroughHouses:
                MoveAlongPoints(housePoints, ref houseIndex, State.CircleShip);
                break;

            case State.CircleShip:
                DoShipCircle();
                break;

            case State.HoverCastle:
                MoveAlongPoints(castleHoverPoints, ref castleIndex, State.ToCastleLand);
                break;

            case State.ToCastleLand:
                MoveToPoint(castleLandPoint, State.MeetKing);
                break;

            case State.MeetKing:
                LookAtKing();
                break;

            case State.Done:
                // Chill on the castle
                break;
        }
    }

    // --------- Generic single-point movement ----------
    void MoveToPoint(Transform target, State nextState)
    {
        if (target == null) return;

        Vector3 dir = target.position - transform.position;

        // Reached this point?
        if (dir.magnitude < 0.5f)
        {
            state = nextState;
            return;
        }

        dir.Normalize();
        transform.position += dir * moveSpeed * Time.deltaTime;

        RotateTowards(dir);
    }

    // --------- Move through an array of points ----------
    void MoveAlongPoints(Transform[] points, ref int index, State nextState)
    {
        if (points == null || points.Length == 0)
        {
            state = nextState;
            return;
        }

        Transform target = points[index];
        Vector3 dir = target.position - transform.position;

        if (dir.magnitude < 0.5f)
        {
            index++;

            if (index >= points.Length)
            {
                state = nextState;
            }
            return;
        }

        dir.Normalize();
        transform.position += dir * moveSpeed * Time.deltaTime;

        RotateTowards(dir);
    }

    // --------- Ship circle ----------
    void DoShipCircle()
    {
        if (shipCenter == null)
        {
            state = State.HoverCastle;
            return;
        }

        shipAngle += moveSpeed * Time.deltaTime / shipCircleRadius;

        // Finished required loops?
        if (shipAngle >= Mathf.PI * 2f * shipCircleLoops)
        {
            state = State.HoverCastle;
            return;
        }

        Vector3 offset = new Vector3(
            Mathf.Cos(shipAngle),
            shipCircleHeight / shipCircleRadius,
            Mathf.Sin(shipAngle)
        ) * shipCircleRadius;

        Vector3 targetPos = shipCenter.position + offset;

        // Smooth follow around circle
        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            5f * Time.deltaTime
        );

        // Face forward along the circle
        Vector3 tangent = new Vector3(
            -Mathf.Sin(shipAngle),
            0f,
            Mathf.Cos(shipAngle)
        );

        RotateTowards(tangent);
    }

    // --------- Look at king on the castle ----------
    void LookAtKing()
    {
        if (kingLookAt == null)
        {
            state = State.Done;
            return;
        }

        Vector3 dir = kingLookAt.position - transform.position;
        RotateTowards(dir);

        // After it turns, just stay there
        // (If you want, you can later trigger an animation here)
    }

    // --------- Helper: rotate dragon ----------
    void RotateTowards(Vector3 direction)
    {
        if (direction == Vector3.zero) return;

        Quaternion targetRot = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRot,
            rotateSpeed * Time.deltaTime
        );
    }
}

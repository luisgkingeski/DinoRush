using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    #region References
    #endregion

    #region Variables

    public int size;
    public bool move;
    public Direction direction;


    public int limit = 5;//max movement
    public float xCenter = 0f;
    public float yCenter = 0f;


    #endregion

    #region MonoBehaviour Callbacks

    private void Start()
    {
        xCenter = transform.position.x;
        yCenter = transform.position.y;
    }

    private void Update()
    {
        if (move)
        {
            if(direction == Direction.Vertical)
            {
                transform.position = new Vector3(transform.position.x, yCenter + Mathf.PingPong(Time.time * 2, limit) - limit / 2f, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(xCenter + Mathf.PingPong(Time.time * 2, limit) - limit / 2f, transform.position.y , transform.position.z);
            }            
        }
    }

    #endregion

    #region Private Methods
    #endregion

    #region Public Methods
    #endregion

    #region Enum

    public enum Direction
    {
        Vertical,
        Horizontal
        
    };


    #endregion

}

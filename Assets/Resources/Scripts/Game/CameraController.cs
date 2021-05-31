using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region References

    public Transform player;


    #endregion

    #region Variables
    #endregion

    #region MonoBehaviour Callbacks

    private void Start()
    {
        player = Player.Instance.transform;
    }

    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        if (transform.position.y <= -1.9f)
        {
            transform.position = new Vector3(player.position.x, -1.9f, transform.position.z);
        }


    }


    #endregion

    #region Private Methods
    #endregion

    #region Public Methods
    #endregion
}

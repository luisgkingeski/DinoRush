using UnityEngine;

public class Plataform : MonoBehaviour
{
    #region References

    public GameObject egg;
    private Transform eggsParent;
    #endregion

    #region Variables

    public int size;
    public bool move;
    private float randSpeed;
    public int limit = 5;//max movement
    public float xCenter = 0f;
    public float yCenter = 0f;
    #endregion

    #region MonoBehaviour Callbacks

    private void Start()
    {
        eggsParent = GameObject.Find("EggsParent").transform;
        xCenter = transform.position.x;
        yCenter = transform.position.y;
        randSpeed = Random.Range(0.5f, 3f);

        if (Random.Range(1, 11) > 4 && gameObject.tag != "Final")
        {
            Instantiate(egg, new Vector3(transform.position.x, transform.position.y + 4, transform.position.z), Quaternion.identity, eggsParent);
        }

    }

    private void Update()
    {
        if (move)
        {
            transform.position = new Vector3(transform.position.x, yCenter + Mathf.PingPong(Time.time * randSpeed, limit) - limit / 2f, transform.position.z);
        }
    }

    #endregion

    #region Private Methods
    #endregion




}

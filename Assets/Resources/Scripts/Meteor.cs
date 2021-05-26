using System.Collections;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    #region References

    private Transform player;

    #endregion

    #region Variables

    private float speed;
    private bool targeted = false;

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        player = Player.Instance.transform;
        StartCoroutine(LookAtPlayer());
    }

    void Update()
    {
        if (!targeted)
        {
            Vector3 dir = player.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        speed = MeteorSpawn.Instance.meteorSpeed;
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }


    #endregion

    #region Coroutines

    private IEnumerator LookAtPlayer()
    {
        yield return new WaitForSeconds(2);
        targeted = true;

    }


    #endregion

}

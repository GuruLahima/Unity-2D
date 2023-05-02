using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowScript : MonoBehaviour
{

  public Transform target; // the object to follow
  public float speed = 5f; // the speed at which to follow

  public Vector3 offset; // the offset from the target object

  void Update()
  {
    transform.position = Vector3.Lerp(transform.position, target.position + offset, speed * Time.deltaTime);
  }
}
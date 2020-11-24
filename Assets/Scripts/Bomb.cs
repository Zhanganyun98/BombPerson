using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionPrefab;
    public LayerMask levelMask;
    private bool exploded = false;


    private Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Invoke("Explode", 3);
    }

    void Explode()
    {

        Instantiate(explosionPrefab, transform.position, Quaternion.identity); //1

        StartCoroutine(CreateExplosions(Vector3.forward));
        StartCoroutine(CreateExplosions(Vector3.right));
        StartCoroutine(CreateExplosions(Vector3.back));
        StartCoroutine(CreateExplosions(Vector3.left));

        GetComponent<MeshRenderer>().enabled = false; //2
        exploded = true;

        transform.Find("Collider").gameObject.SetActive(false); //3
        Destroy(gameObject, .3f); //4
       // player.AddBombs();
    }
    

    private IEnumerator CreateExplosions(Vector3 direction)
    {
        if (player.GetComponent<Player>().powerBomb == true)
        {
            for (int i = 0; i < 5; i++)
            {
                RaycastHit hit;
                Physics.Raycast(transform.position + new Vector3(0, .5f, 0), direction, out hit, i, levelMask);

                if (!hit.collider)
                {
                    Instantiate(explosionPrefab, transform.position + (i * direction), explosionPrefab.transform.rotation);
                }
                else
                {
                    break;
                }
                yield return new WaitForSeconds(0.05f);
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                RaycastHit hit;
                Physics.Raycast(transform.position + new Vector3(0, .5f, 0), direction, out hit, i, levelMask);

                if (!hit.collider)
                {
                    Instantiate(explosionPrefab, transform.position + (i * direction), explosionPrefab.transform.rotation);
                }
                else
                {
                    break;
                }
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("一块爆炸1");
        if (exploded==false && other.CompareTag("Explosion"))
        {
            Debug.Log("一块爆炸2");
            CancelInvoke("Explode");
            Explode();
        }

    }

}

using System.Collections;
using TMPro;
using UnityEngine;

public class StyleZone : MonoBehaviour
{
    GameManager gameManager ;
    [SerializeField] private LayerMask _projectileLayer;
    [SerializeField] GameObject _pointTxt;
    CircleCollider2D _styleZone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _styleZone = GetComponent<CircleCollider2D>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((_projectileLayer & (1 << collision.transform.gameObject.layer)) > 0)
        {
            gameManager.AddPoint(15);
            GameObject text = Instantiate(_pointTxt, new Vector3((transform.position.x + Random.Range(0,1)), (transform.position.y + Random.Range(0, 1)),0),transform.rotation);
            StartCoroutine(DestroyTxt(text));
        }
    }

    IEnumerator DestroyTxt(GameObject text)
    {
        text.GetComponentInChildren<TMP_Text>().text = ("+15");
        yield return new WaitForSeconds(1.0f);
        Destroy(text);
    }

    

}

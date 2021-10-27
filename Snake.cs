using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _yon = Vector2.right;

    private List<Transform> _ekle =new List<Transform>();
    public Transform eklePrefab;
    public int initialSize = 4;//oyun baslarken yilanın boyutu

    private void Start()
    {
        /* _ekle = new List<Transform>();
         _ekle.Add(this.transform);*/
        ResetState();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _yon = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _yon = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _yon = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _yon = Vector2.right;
        }
    }
    private void FixedUpdate()
    {
        for (int i = _ekle.Count - 1; i > 0; i--)
        {
            _ekle[i].position = _ekle[i - 1].position; //yilanin boyunu uzatmak icin
        }

        this.transform.position = new Vector3(
           Mathf.Round(this.transform.position.x) + _yon.x,
           Mathf.Round(this.transform.position.y) + _yon.y,
           0.0f);
    }
    private void Ekleme() // kuyruk olusturmak icin
    {
        Transform segment = Instantiate(this.eklePrefab);
        segment.position = _ekle[_ekle.Count - 1].position;

        _ekle.Add(segment);
    }

    private void ResetState()// yilan engele carpınca eski haline geri donuyor
    {
        for (int i = 1; i < _ekle.Count; i++)
        {
            Destroy(_ekle[i].gameObject);
        }
        _ekle.Clear();
        _ekle.Add(this.transform);

        for (int i = 1; i < this.initialSize; i++)
        {
            _ekle.Add(Instantiate(this.eklePrefab));
        }

        this.transform.position = Vector3.zero;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Yem")
        {
            Ekleme();
        }
        if(other.tag == "Engel")
        {
           ResetState();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;



public class Grabed : MonoBehaviour
{
    LineRenderer lineRenderer;
    Vector3 pozVeche;
    int i = 0;
    void Start()
    {     
    }
    private void Update()
    {  
       if (GetComponent<VRTK_InteractableObject>().IsGrabbed())//verific daca obiectul este ridicat
        {
            if (i == 0)
            {//imediat dupa ridicare creez un lineRenderer si i-l atasez
                lineRenderer = gameObject.AddComponent<LineRenderer>();
                lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                lineRenderer.widthMultiplier = 0.2f;

                lineRenderer.startColor = Color.white;
                lineRenderer.endColor = Color.white;

                lineRenderer.positionCount = 10000;
                //setez ca prim punct al lineRenderer-ului pozitia curenta a obiectului
                lineRenderer.SetPosition(0, transform.position);
                i++;
                pozVeche = transform.position;
            }
            else
               if (pozVeche != transform.position)//daca obiectul s-a miscat
            {
                lineRenderer.SetPosition(i, transform.position);//adaug noua pozitie la lista de puncte ale lineRenderer-ului          
                i++;
                pozVeche = transform.position;
            }
        }
    }   

}


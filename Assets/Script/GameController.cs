using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using models;
using TMPro;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class GameController : MonoBehaviour
{
    string lineaLeida = "";
    List<PreguntaMultiple> listaPreguntasMultiples;
    System.Random rnd = new System.Random();

    String respuestaPM;

    public TextMeshProUGUI textPregunta;
    public TextMeshProUGUI textRespuesta1;
    public TextMeshProUGUI textRespuesta2;
    public TextMeshProUGUI textRespuesta3;
    public TextMeshProUGUI textRespuesta4;

    public GameObject panelPregunta;
    public GameObject panelIncorrecta;
    public GameObject panelCorrecta;

    // Start is called before the first frame update
    void Start()
    {
        listaPreguntasMultiples = new List<PreguntaMultiple>();
        LecturaPreguntasMultiples();
        mostrarPreguntasMultiples();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void mostrarPreguntasMultiples()
    {
        int nroPregunta = rnd.Next(1, listaPreguntasMultiples.Count);
        PreguntaMultiple preguntaRND = listaPreguntasMultiples[nroPregunta];

        if (preguntaRND.Dificultad.Equals("facil"))
        {
            textPregunta.text = preguntaRND.Pregunta;
            textRespuesta1.text = preguntaRND.Respuesta1;
            textRespuesta2.text = preguntaRND.Respuesta2;
            textRespuesta3.text = preguntaRND.Respuesta3;
            textRespuesta4.text = listaPreguntasMultiples[nroPregunta].Respuesta4;
            respuestaPM = preguntaRND.RespuestaCorrecta;
            listaPreguntasMultiples.Remove(preguntaRND);
        }
        else
        {
            listaPreguntasMultiples.Remove(preguntaRND);
            mostrarPreguntasMultiples();
        }
        Debug.Log(listaPreguntasMultiples.Count);
    }

    public void ComprobarRespuesta(int indiceRespuesta)
    {
        string respuestaSeleccionada = "";

        switch (indiceRespuesta)
        {
            case 1:
                respuestaSeleccionada = textRespuesta1.text;
                break;
            case 2:
                respuestaSeleccionada = textRespuesta2.text;
                break;
            case 3:
                respuestaSeleccionada = textRespuesta3.text;
                break;
            case 4:
                respuestaSeleccionada = textRespuesta4.text;
                break;
        }

        if (respuestaSeleccionada.Equals(respuestaPM))
        {
            panelCorrecta.SetActive(true);
            panelPregunta.SetActive(false);
        }
        else
        {
            panelIncorrecta.SetActive(true);
            panelPregunta.SetActive(false);
        }
    }

    public void reintentarPregunta()
    {
        panelIncorrecta.SetActive(false);
        panelPregunta.SetActive(true);
    }

    public void siguientePregunta()
    {
        panelCorrecta.SetActive(false);
        mostrarPreguntasMultiples();
        panelPregunta.SetActive(true);
    }

    #region Lectura archivos
    public void LecturaPreguntasMultiples()
    {
        try
        {
            StreamReader sr1 = new StreamReader("Assets/Files/ArchivoPreguntasM.txt");
            while ((lineaLeida = sr1.ReadLine()) != null)
            {
                string[] lineaPartida = lineaLeida.Split("-");
                string pregunta = lineaPartida[0];
                string respuesta1 = lineaPartida[1];
                string respuesta2 = lineaPartida[2];
                string respuesta3 = lineaPartida[3];
                string respuesta4 = lineaPartida[4];
                string respuestaCorrecta= lineaPartida[5];
                string versiculo = lineaPartida[6];
                string dificultad = lineaPartida[7];

                PreguntaMultiple objPM=new PreguntaMultiple(pregunta, respuesta1, respuesta2, respuesta3,
                    respuesta4, respuestaCorrecta, versiculo, dificultad);

                listaPreguntasMultiples.Add(objPM);
            }
            Debug.Log("El tamaño de la lista es: " + listaPreguntasMultiples.Count);
        }
        catch(Exception e) 
        { 
            Debug.Log("ERROR!!!!! "+e.ToString());
        }
        finally
        { Debug.Log("Executing finally block."); }
    }
    #endregion
}
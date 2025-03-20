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
    List<Pregunta> listaPreguntasFaciles;
    List<Pregunta> listaPreguntasDificiles;

    Utilities lectorPreguntas;

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
        lectorPreguntas = new Utilities();
        listaPreguntasFaciles = lectorPreguntas.getPreguntasFaciles();
        listaPreguntasDificiles = lectorPreguntas.getPreguntasDificiles();
        mostrarPreguntasMultiples();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void mostrarPregunta()
    {
        int nroPregunta = rnd.Next(1, listaPreguntasFaciles.Count);
    }

    public void mostrarPreguntasMultiples()
    {
        int nroPregunta = rnd.Next(1, listaPreguntasMultiples.Count);
        PreguntaMultiple preguntaRND = listaPreguntasMultiples[nroPregunta];

        if (preguntaRND.Dificultad.Equals("facil"))
        {
            textPregunta.text = preguntaRND.Enunciado;
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
}
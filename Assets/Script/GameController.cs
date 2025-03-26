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

    string respuestaPregunta = "";
    bool respuestaFalsoVerdadero = false;
    Pregunta preguntaActual;
    int nroPreguntasDificiles;
    int nroPreguntasFaciles;
    int cantidadErrores;
    int cantidadAciertos;
    //Paneles
    public GameObject panelPreguntaMultiple;
    public GameObject panelPreguntaAbierta;
    public GameObject panelPreguntaFalsoVerdadero;
    public GameObject panelIncorrecta;
    public GameObject panelCorrecta;
    public GameObject panelFinal;

    //Componentes preguntas multiples
    public TextMeshProUGUI textPreguntaMultiple;
    public TextMeshProUGUI textRespuesta1;
    public TextMeshProUGUI textRespuesta2;
    public TextMeshProUGUI textRespuesta3;
    public TextMeshProUGUI textRespuesta4;

    //Componentes preguntas falso verdadero
    public TextMeshProUGUI textPreguntaFalsoVerdadero;

    //Componentes preguntas abiertas
    public TextMeshProUGUI textPreguntaAbierta;
    public TextMeshProUGUI textRespuestaAbierta;

    public TextMeshProUGUI textCantidadErrores;
    public TextMeshProUGUI textCantidadAciertos;

    // Start is called before the first frame update
    void Start()
    {
        lectorPreguntas = new Utilities();
        listaPreguntasFaciles = lectorPreguntas.getPreguntasFaciles();
        listaPreguntasDificiles = lectorPreguntas.getPreguntasDificiles();
        nroPreguntasFaciles = listaPreguntasFaciles.Count;
        nroPreguntasDificiles = listaPreguntasFaciles.Count;

        mostrarPreguntas();
        cantidadAciertos = 0;
        cantidadErrores = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void mostrarPreguntas()
    {
        textRespuestaAbierta.text = "Mostrar Respuesta";

        if (nroPreguntasFaciles > 1)
        {
            int nroPreguntaFacil = rnd.Next(1, listaPreguntasFaciles.Count);
            Pregunta preguntaRND = listaPreguntasFaciles[nroPreguntaFacil];
            gestorPreguntas(preguntaRND);
            listaPreguntasFaciles.Remove(listaPreguntasFaciles[nroPreguntaFacil]);
            nroPreguntasFaciles--;
        }
        else if(nroPreguntasDificiles > 1)
        {
            int nroPreguntaDificil = rnd.Next(1, listaPreguntasDificiles.Count);
            Pregunta preguntaRND = listaPreguntasDificiles[nroPreguntaDificil];
            gestorPreguntas(preguntaRND);
            listaPreguntasDificiles.Remove(listaPreguntasDificiles[nroPreguntaDificil]);
            nroPreguntasDificiles--;
        }
        else
        {
            ocultarPreguntas();
            panelFinal.SetActive(true);
        }

        Debug.Log("La cantidad de preguntas faciles es: " + listaPreguntasFaciles.Count);
        Debug.Log("La cantidad de preguntas dificiles es: " + listaPreguntasDificiles.Count);
    }

    private void gestorPreguntas(Pregunta preguntaRND)
    {
        if (preguntaRND.GetType().Equals(typeof(PreguntaMultiple)))
        {
            preguntaActual = preguntaRND;
            PreguntaMultiple preguntaMultiple = preguntaRND as PreguntaMultiple;
            respuestaPregunta = preguntaMultiple.RespuestaCorrecta;

            panelPreguntaMultiple.SetActive(true);
            panelPreguntaAbierta.SetActive(false);
            panelPreguntaFalsoVerdadero.SetActive(false);

            textPreguntaMultiple.text = preguntaMultiple.Enunciado;
            textRespuesta1.text = preguntaMultiple.Respuesta1;
            textRespuesta2.text = preguntaMultiple.Respuesta2;
            textRespuesta3.text = preguntaMultiple.Respuesta3;
            textRespuesta4.text = preguntaMultiple.Respuesta4;
        }
        else if (preguntaRND.GetType().Equals(typeof(PreguntaFalsoVerdadero)))
        {
            preguntaActual = preguntaRND;
            PreguntaFalsoVerdadero preguntaFalsoVerdadero = preguntaRND as PreguntaFalsoVerdadero;
            respuestaFalsoVerdadero = preguntaFalsoVerdadero.Respuesta;

            panelPreguntaMultiple.SetActive(false);
            panelPreguntaAbierta.SetActive(false);
            panelPreguntaFalsoVerdadero.SetActive(true);

            textPreguntaFalsoVerdadero.text = preguntaFalsoVerdadero.Enunciado;
        }
        else
        {
            preguntaActual = preguntaRND;
            PreguntaAbierta preguntaAbierta = preguntaRND as PreguntaAbierta;
            respuestaPregunta = preguntaAbierta.Respuesta;

            panelPreguntaMultiple.SetActive(false);
            panelPreguntaAbierta.SetActive(true);
            panelPreguntaFalsoVerdadero.SetActive(false);

            textPreguntaAbierta.text = preguntaAbierta.Enunciado;
        }
    }

    public void ComprobarRespuestaMultiple(int indiceRespuesta)
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

        if (preguntaActual.VerificarRespuesta(respuestaSeleccionada))
        {
            cantidadAciertos++;
            panelCorrecta.SetActive(true);
            ocultarPreguntas();
        }
        else
        {
            cantidadErrores++;
            panelIncorrecta.SetActive(true);
            ocultarPreguntas();
        }
    }

    public void ComprobarRespuestaFalsoVerdadero(int indiceRespuesta)
    {
        bool respuestaSeleccionada = true;

        switch (indiceRespuesta)
        {
            case 1:
                respuestaSeleccionada = false;
                break;
            case 2:
                respuestaSeleccionada = true;
                break;
        }

        if (preguntaActual.VerificarRespuesta(respuestaSeleccionada))
        {
            cantidadAciertos++;
            panelCorrecta.SetActive(true);
            ocultarPreguntas();
        }
        else
        {
            cantidadErrores++;
            panelIncorrecta.SetActive(true);
            ocultarPreguntas();
        }
    }

    public void MostrarRespuestaAbierta()
    {
        textRespuestaAbierta.text = respuestaPregunta;
    }

    public void reintentarPregunta()
    {
        if (preguntaActual.GetType().Equals(typeof(PreguntaMultiple)))
        {
            panelIncorrecta.SetActive(false);
            panelPreguntaMultiple.SetActive(true);
        }
        else
        {
            panelIncorrecta.SetActive(false);
            panelPreguntaFalsoVerdadero.SetActive(true);
        }
    }

    public void siguientePregunta()
    {
        panelCorrecta.SetActive(false);
        mostrarPreguntas();
    }

    public void ocultarPreguntas()
    {
        panelPreguntaAbierta.SetActive(false);
        panelPreguntaFalsoVerdadero.SetActive(false);
        panelPreguntaMultiple.SetActive(false);
    }
}
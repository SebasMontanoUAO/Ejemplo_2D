using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace models
{
    public class Utilities
    {
        string lineaLeida = "";
        List<Pregunta> listaPreguntasFaciles  = new List<Pregunta>();
        List<Pregunta> listaPreguntasDificiles = new List<Pregunta>();

        public Utilities()
        { }

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
                    string respuestaCorrecta = lineaPartida[5];
                    string versiculo = lineaPartida[6];
                    string dificultad = lineaPartida[7];

                    PreguntaMultiple objPM = new PreguntaMultiple(pregunta, respuesta1, respuesta2, respuesta3,
                        respuesta4, respuestaCorrecta, versiculo, dificultad);

                    if (objPM.Dificultad.Equals("facil"))
                    {
                        listaPreguntasFaciles.Add(objPM);
                    }
                    else
                    {
                        listaPreguntasDificiles.Add(objPM);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("ERROR!!!!! " + e.ToString());
            }
            finally
            { Debug.Log("Executing finally block."); }
        }

        public void LecturaPreguntasFalsoVerdadero()
        {
            try
            {
                StreamReader sr1 = new StreamReader("Assets/Files/preguntasFalso_Verdadero.txt");
                while ((lineaLeida = sr1.ReadLine()) != null)
                {
                    string[] lineaPartida = lineaLeida.Split("-");
                    string enunciado = lineaPartida[0];
                    bool respuesta = Boolean.Parse(lineaPartida[1]);
                    string versiculo = lineaPartida[2];
                    string dificultad = lineaPartida[3];

                    PreguntaFalsoVerdadero objPFV = new PreguntaFalsoVerdadero(enunciado, respuesta, versiculo, dificultad);

                    if (objPFV.Dificultad.Equals("facil"))
                    {
                        listaPreguntasFaciles.Add(objPFV);
                    }
                    else
                    {
                        listaPreguntasDificiles.Add(objPFV);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("ERROR!!!!! " + e.ToString());
            }
            finally
            { Debug.Log("Executing finally block."); }
        }

        public void LecturaPreguntasAbiertas()
        {
            try
            {
                StreamReader sr1 = new StreamReader("Assets/Files/ArchivoPreguntasAbiertas.txt");
                while ((lineaLeida = sr1.ReadLine()) != null)
                {
                    string[] lineaPartida = lineaLeida.Split("-");
                    string enunciado = lineaPartida[0];
                    string versiculo = lineaPartida[1];
                    string dificultad = lineaPartida[2];

                    PreguntaAbierta objPFV = new PreguntaAbierta(enunciado, versiculo, dificultad);

                    if (objPFV.Dificultad.Equals("facil"))
                    {
                        listaPreguntasFaciles.Add(objPFV);
                    }
                    else
                    {
                        listaPreguntasDificiles.Add(objPFV);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("ERROR!!!!! " + e.ToString());
            }
            finally
            { Debug.Log("Executing finally block."); }
        }

        public List<Pregunta> getPreguntasFaciles()
        {
            return listaPreguntasFaciles;
        }

        public List<Pregunta> getPreguntasDificiles()
        {
            return listaPreguntasDificiles;
        }
    }
}
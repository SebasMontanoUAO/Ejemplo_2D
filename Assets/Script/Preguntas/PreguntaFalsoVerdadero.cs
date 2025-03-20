using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace models
{
    public class PreguntaFalsoVerdadero : Pregunta
    {
        private bool respuesta;

        public PreguntaFalsoVerdadero(string enunciado, bool respuesta, string versiculo, string dificultad) : base(enunciado, versiculo, dificultad) 
        {
            this.respuesta = respuesta;
        }

        public override bool VerificarRespuesta(object respuestaUsuario)
        {
            if (respuesta.Equals(respuestaUsuario))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Respuesta { get => respuesta; set => respuesta = value; }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace models
{
    public class PreguntaAbierta : Pregunta
    {
        private string respuesta;

        public PreguntaAbierta(string enunciado, string respuesta, string versiculo, string dificultad) : base(enunciado, versiculo, dificultad)
        {
            this.respuesta = respuesta;
        }

        public override bool VerificarRespuesta(object respuestaUsuario)
        {
            return true;
        }

        public string Respuesta { get => respuesta; set => respuesta = value; }
    }
}

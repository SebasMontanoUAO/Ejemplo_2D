using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace models
{
    public class PreguntaAbierta : Pregunta
    {
        public PreguntaAbierta(string enunciado, string versiculo, string dificultad) : base(enunciado, versiculo, dificultad) { }

        public override bool VerificarRespuesta(object respuestaUsuario)
        {
            return true;
        }
    }
}

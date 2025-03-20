using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace models
{
    public abstract class Pregunta
    {
        protected string enunciado;
        protected string versiculo;
        protected string dificultad;

        public Pregunta(string enunciado, string versiculo, string dificultad)
        {
            this.enunciado = enunciado;
            this.versiculo = versiculo;
            this.dificultad = dificultad;
        }

        public abstract bool VerificarRespuesta(object respuestaUsuario);

        public string Enunciado { get => enunciado; set => enunciado = value; }
        public string Versiculo { get => versiculo; set => versiculo = value; }
        public string Dificultad { get => dificultad; set => dificultad = value; }
    }
}

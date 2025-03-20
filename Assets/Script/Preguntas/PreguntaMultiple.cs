using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace models
{
    public class PreguntaMultiple : Pregunta
    {
        private string respuesta1;
        private string respuesta2;
        private string respuesta3;
        private string respuesta4;
        private string respuestaCorrecta;

        public PreguntaMultiple(string enunciado, string respuesta1, string respuesta2, string respuesta3, string respuesta4, string respuestaCorrecta, string versiculo, string dificultad) : base(enunciado, versiculo, dificultad)
        {
            this.respuesta1 = respuesta1;
            this.respuesta2 = respuesta2;
            this.respuesta3 = respuesta3;
            this.respuesta4 = respuesta4;
            this.respuestaCorrecta = respuestaCorrecta;
        }


        public override bool VerificarRespuesta(object respuestaUsuario)
        {
            if (respuestaUsuario.ToString().Equals(respuestaCorrecta))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Respuesta1 { get => respuesta1; set => respuesta1 = value; }
        public string Respuesta2 { get => respuesta2; set => respuesta2 = value; }
        public string Respuesta3 { get => respuesta3; set => respuesta3 = value; }
        public string Respuesta4 { get => respuesta4; set => respuesta4 = value; }
        public string RespuestaCorrecta { get => respuestaCorrecta; set => respuestaCorrecta = value; }
    }
}
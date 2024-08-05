using System;

namespace EduTime.Domain.ValueObjects
{
    public class DiaSemana
    {
        public string Valor { get; private set; }

        public DiaSemana(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new ArgumentException("El día de la semana no puede estar vacío.", nameof(valor));
            }

            Valor = valor;
        }

        public override string ToString()
        {
            return Valor;
        }
    }
}

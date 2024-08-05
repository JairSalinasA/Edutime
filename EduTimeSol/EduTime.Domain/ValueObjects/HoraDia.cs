using System;

namespace EduTime.Domain.ValueObjects
{
    public class HoraDia
    {
        public TimeSpan Hora { get; private set; }

        public HoraDia(TimeSpan hora)
        {
            Hora = hora;
        }

        public override string ToString()
        {
            return Hora.ToString(@"hh\:mm");
        }
    }
}

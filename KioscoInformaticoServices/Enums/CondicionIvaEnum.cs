using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioscoInformaticoServices.Enums
{
    public enum CondicionIvaEnum
    {
        No_definido,
        Responsable_inscripto,
        Responsable_no_inscripto,
        Exento,
        No_responsable,
        Consumidor_final,
        Monotributista,
        Sujeto_no_categorizado
    }
}

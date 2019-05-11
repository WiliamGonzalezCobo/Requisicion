using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace G_H_WEB.LOGICA_IU
{
    public static class ESTADO
    {

        public static string OBTENER_ESTILO(string _ESTADO)
        {
            switch (_ESTADO)
            {
                case "Registrado":
                    return "td-estado pausado";

                case "Verificado BP":
                    return "td-estado aprobado";

                case "Documentos Aprobados":
                    return "td-estado espera";

                case "Finalizado":
                    return "td-estado finalizado";

                default:
                    return "";
            }

        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UTILS
{
   public static class MAP
    {
        public static List<T> MapperList<T, T1>(this List<T1> table)
            where T : class, new()
            where T1 : class, new()
        {
            try
            {
                List<T> list = new List<T>();
                foreach (var row in table)
                {
                    // Instancia un objecto del tipo que recibe en T
                    T obj = new T();
                    // Recorre las propiedades del objeto obj
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            string nameOfColumn = "";
                            // Obtiene el nombre de las propiedades del objecto
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            // Le inserta el valor a la propiedad, 1 objeto, 2 valor, 3 tipo de la propiedad

                            foreach (var tipoDato in prop.CustomAttributes)
                            {
                                if (tipoDato.AttributeType.Name == "ColumnAttribute")
                                {
                                    nameOfColumn = tipoDato.NamedArguments[0].TypedValue.Value.ToString();
                                    break;
                                }
                            }
                            propertyInfo.SetValue(obj, Convert.ChangeType(row.GetType().GetProperty(nameOfColumn).GetValue(row), propertyInfo.PropertyType), null);
                            //row[prop.Name]
                        }
                        catch { continue; }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DefinexAttributeOrnek
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class ZorunluAlanAttribute : Attribute
    {
        public static bool Dogrula(object dogrulanacakEntity)
        {
            Type dogrulamacakTur = dogrulanacakEntity.GetType();
            FieldInfo[] dogrulanacakTurAlanlari = dogrulamacakTur.GetFields(
                                                  BindingFlags.Public |
                                                  BindingFlags.Instance);
            foreach (FieldInfo dogrulanacakTurAlani in dogrulanacakTurAlanlari)
            {
                object[] zorunluAlanOznitelikleri = dogrulanacakTurAlani.GetCustomAttributes(typeof(ZorunluAlanAttribute), true);
                if (zorunluAlanOznitelikleri.Length != 0)
                {
                    string alanDegeri = dogrulanacakTurAlani.GetValue(dogrulanacakEntity) as string;
                    if (string.IsNullOrEmpty(alanDegeri))
                    {
                        return false;
                    }
                }

            }
            return true;
        }
    }
}

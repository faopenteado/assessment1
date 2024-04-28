using System.Collections;

namespace Eventim.ExpensesAPI.Utils
{

    static class EnumExtentions
    {
        public static List<T> CloneValue<T>(this List<T> container)
        {            
            return container.Select(x => (T)x).ToList();
        }
    }
}

﻿namespace RestTodo.Extenstions
{
    public static class InputChecker
    {
        public static bool IsAnyPropertyNull(this object o)
        {
            var properties = o.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.GetValue(o) == null)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsAnyStringPropertyEmpty(this object o)
        {
            var properties = o.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.PropertyType.Name == "String" && (string)property.GetValue(o) == string.Empty)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

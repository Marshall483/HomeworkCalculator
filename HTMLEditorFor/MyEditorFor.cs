using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Html;

namespace EditorFor.Services
{
    public static class MyEditorFor
    {
        private static readonly Dictionary<Type, string> TypesRequiredInput = 
            new Dictionary<Type, string>()
        {
            {typeof(int), "System.Int32"},
            {typeof(long), "System.Int64"},
            {typeof(string), "System.String"},
        };
        
        private static readonly Dictionary<Type, string> TypesRequiredCheckBox = 
            new Dictionary<Type, string>()
            {
                {typeof(bool), "System.Boolean"}
            };

        public static Dictionary<Type, string> TypesRequiredSelect 
            = new Dictionary<Type, string>()
            {
                {typeof(Enum), "System.Enum"}
            };

        public static IHtmlContent EditorFor(object data)
        {
            var content = new HtmlContentBuilder();
            
            Type currentType = data.GetType();
            PropertyInfo[] prInfo = currentType.GetProperties();
            
            if (TypeRequiredInputField(currentType))
                content.AppendHtml( GenereteInput(currentType, data));
            else if (TypeRequiredCheckBox(currentType))
                content.AppendHtml(GenereteCheckBox(currentType, data));
            else if (TypeRequiredSelect(currentType))
                content.AppendHtml(GenerateSelect(currentType, data));
            
            return content;
        }

        private static string GenerateSelect(Type currentType, object instance)
        {
            throw new NotImplementedException();
        }

        private static string GenereteCheckBox(Type type, object instance)
        {
            return @"<input type='checkbox' " + 
                   @$"name='{TypesRequiredCheckBox[type]}' " +
                   @$"value='{(bool) instance}' " +
                   @$"{IsChecked(instance)}>";
        }
    
        private static string GenereteInput(Type type, object instance)
        {
            return $"<input class='text-box single-line' "+
                   $"type='{TypesRequiredInput[type]}' " +
                   $"value='{GetTypeValue(type, instance)}' " +
                   $">";
        }

        private static string IsChecked(object instance) =>
            ((bool) instance).Equals(true) ? " checked" : "";
        
        private static string GetTypeValue(Type type, object instance)
        {
            if (type.Equals(typeof(string)))
                return (string) instance;
            if (type.Equals(typeof(int)))
                return ((int) instance).ToString();
            if (type.Equals(typeof(long)))
                return ((long) instance).ToString();
            return "Not Supported Type";
        }

        public static bool TypeRequiredInputField(Type type) =>
            TypesRequiredInput.Keys.Contains(type);
        
        public static bool TypeRequiredCheckBox(Type type) =>
            TypesRequiredCheckBox.Keys.Contains(type);
        
        public static bool TypeRequiredSelect(Type type) =>
            TypesRequiredSelect.Keys.Contains(type);
    }
}
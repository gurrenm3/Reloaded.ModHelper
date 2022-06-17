using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A JsonConverter which is used to properly deserialize json for <see cref="ModSetting"/>.
    /// </summary>
    public class ModSettingConverter : JsonConverter
    {
        public override bool CanRead => true;
        public override bool CanWrite => false;

        private IModLogger logger;
        public ModSettingConverter()
        {

        }

        public ModSettingConverter(IModLogger logger)
        {
            this.logger = logger;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ModSetting);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);

            // Get which type of mod setting this is.
            string typeName = token[nameof(ModSetting.type)].ToString();
            var settingType = Type.GetType(typeName);

            // Create mod setting.
            ModSetting modSetting = (ModSetting)Activator.CreateInstance(settingType);

            // get all properties and fields, ignoring duplicates.
            HashSet<MemberInfo> allValues = new HashSet<MemberInfo>();
            var fields = settingType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (var field in fields)
            {
                if (!allValues.Any(value => value.Name == field.Name))
                    allValues.Add(field);
            }

            var properties = settingType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (var property in properties)
            {
                if (!allValues.Any(value => value.Name == property.Name))
                    allValues.Add(property);
            }


            // Set values of the created mod setting to the values from json.
            foreach (var item in allValues)
            {
                if (token[item.Name] == null)
                    continue;

                if (item is FieldInfo field)
                {
                    var value = Convert.ChangeType(token[item.Name], field.FieldType);
                    field.SetValue(modSetting, value);
                }
                else if (item is PropertyInfo property && property.SetMethod != null)
                {
                    var value = Convert.ChangeType(token[item.Name], property.PropertyType);
                    property.SetValue(modSetting, value);
                }
            }

            return modSetting;
        }



        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

        }
    }
}

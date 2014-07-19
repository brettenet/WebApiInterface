using System;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using WebApiInterface.Models;

namespace WebApiInterface
{
    public class IocCustomCreationConverter<T> : CustomCreationConverter<T>
    {
        public override T Create(Type objectType)
        {
            return (T)ServiceLocator.Current.GetInstance(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            T obj = Create(objectType);
            serializer.Populate(reader, obj);
            return obj;
        }
    }

    public class FooCustomConverter : CustomCreationConverter<IFoo>
    {
        public override IFoo Create(Type objectType)
        {
            return new Foo();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            IFoo obj = Create(objectType);
            serializer.Populate(reader, obj);
            return obj;
        }
    }
}
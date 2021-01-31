using MongoDB.Bson.Serialization.Conventions;
using System;
using MongoDB.Bson.IO;
using MongoDB.Bson;

namespace StartOnion.Repository.MongoDB
{
    // Prevent _t object
    // https://codingcanvas.com/storing-polymorphic-classes-in-mongodb-using-c/

    public class ContentTypeDiscriminatorConvention : IDiscriminatorConvention
    {
        public string ElementName => "_t";

        public Type GetActualType(IBsonReader bsonReader, Type nominalType)
        {
            var bookmark = bsonReader.GetBookmark();
            bsonReader.ReadStartDocument();
            string typeValue;
            if (bsonReader.FindElement(ElementName))
                typeValue = bsonReader.ReadString();
            else
                throw new NotSupportedException();

            bsonReader.ReturnToBookmark(bookmark);
            return Type.GetType(typeValue);
        }

        public BsonValue GetDiscriminator(Type nominalType, Type actualType) => actualType.Name;
    }
}

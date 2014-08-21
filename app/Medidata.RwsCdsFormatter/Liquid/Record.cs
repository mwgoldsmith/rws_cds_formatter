using System;
using System.Collections.Generic;
using DotLiquid;

namespace Medidata.RwsCdsFormatter.Liquid
{
    public class Record : ILiquidizable
    {
        public bool IsFirst { get; set; }
        public bool IsLast { get; set; }

        public IDictionary<string, string> AttributesCollection { get; protected set; }

        public Record(IDictionary<String, String> attributesCollection) {
            AttributesCollection = attributesCollection;
        }

        public virtual IDictionary<String, String> GetAttributes() {
            return AttributesCollection;
        }

        public override bool Equals(object obj) {
            var record = obj as Record;
            return record != null && record.AttributesCollection.DictionaryEquals(AttributesCollection);
        }

        public override int GetHashCode() {
            return AttributesCollection.GetHashCode();
        }

        public virtual object ToLiquid() {
            return new RecordDrop(this);
        }
    }
}

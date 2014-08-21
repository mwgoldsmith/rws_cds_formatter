using System;
using System.Collections.Generic;
using DotLiquid;

namespace Medidata.RwsCdsFormatter.Liquid
{
    /// <summary>
    /// RecordDrop wraps the record object in a liquidizable object
    /// </summary>
    public class RecordDrop : Drop
    {
        private readonly Record _record;

        public bool First {
            get { return _record.IsFirst; }
        }

        public bool Last {
            get { return _record.IsLast; }
        }

        public IDictionary<string, string> Attributes {
            get { return _record.GetAttributes(); }
        }

        public RecordDrop() {}

        public RecordDrop(Record record) {
            _record = record;
        }

        public override object BeforeMethod(string key) {
            return Attributes.Keys.Contains(key) ? Attributes[key] : String.Empty;
        }
    }
}
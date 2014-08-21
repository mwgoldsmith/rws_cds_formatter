using System;
using DotLiquid;

namespace Medidata.RwsCdsFormatter.Liquid
{
    public class ConfigurableDatasetRequest : Drop
    {
        public Guid Guid { get; set; }
        public DateTime Date { get; set; }

        public string Id {
            get { return Guid.ToString(); }
        }

        public override object ToLiquid() {
            return this;
        }
    }
}

using DotLiquid;

namespace Medidata.RwsCdsFormatter.Liquid
{
    public class ConfigurableDatasetRecordset : Drop
    {
        public string Name { get; set; }

        public override object ToLiquid() {
            return this;
        }
    }
}

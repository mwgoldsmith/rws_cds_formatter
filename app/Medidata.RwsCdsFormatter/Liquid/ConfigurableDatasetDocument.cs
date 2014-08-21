using DotLiquid;

namespace Medidata.RwsCdsFormatter.Liquid
{
    public class ConfigurableDatasetDocument : Drop
    {
        public string Section { get; set; }

        public override object ToLiquid() {
            return this;
        }
    }
}
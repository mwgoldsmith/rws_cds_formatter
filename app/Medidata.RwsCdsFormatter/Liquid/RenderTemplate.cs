using System.Text;
using DotLiquid;

namespace Medidata.RwsCdsFormatter.Liquid
{
    public class RenderTemplate
    {
        public RenderTemplate(Template t, StringBuilder o, ILiquidizable doc, ILiquidizable req) {
            Template = t;
            Odm = o;
            Document = doc as ConfigurableDatasetDocument;
            Request = req as ConfigurableDatasetRequest;
        }

        public Template Template { get; set; }
        public StringBuilder Odm { get; set; }
        public ConfigurableDatasetDocument Document { get; set; }
        public ConfigurableDatasetRequest Request { get; set; }
        public ConfigurableDatasetRecordset Recordset { get; set; }
        public Record PreviousRecord { get; set; }
        public Record CurrentRecord { get; set; }
        public Record NextRecord { get; set; }
    }
}

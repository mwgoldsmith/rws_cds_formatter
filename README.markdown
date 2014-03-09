### RWS Configurable Dataset Formatter

Provided the CSV output from a SP for a Configurable Dataset, this utility will properly format it as XML using the specified row template.

The purpose of this tool is to provide the ability to retrieve the result of an RWS call for a dataset where the source data is offline. For example, when a backup Rave database is restored for the purpose of retrieving data, the result set can be saved as a csv file and parsed using this tool - as opposed to making potentially resource intensive calls to the live Rave URL.


Much credit goes to [Taiyib](https://github.com/tashraf), who wrote the [Liquid Template Test](https://github.com/mdsol/bikeshed/tree/master/windows/LiquidTemplateTest).

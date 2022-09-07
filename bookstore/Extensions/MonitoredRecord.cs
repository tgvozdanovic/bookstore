using System.ComponentModel.Composition;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;

namespace Bookstore.Extensions
{
    [Export(typeof(IConceptInfo))]
    [ConceptKeyword("MonitoredRecord")]
    public class PhoneNumberInfo : ShortStringPropertyInfo
    {
    }
}
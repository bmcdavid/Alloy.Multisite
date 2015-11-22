using EPiServer.Core;

namespace Alloy.Multisite.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}

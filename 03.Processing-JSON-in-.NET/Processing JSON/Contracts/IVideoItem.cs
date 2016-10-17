using Processing_JSON.Models;

namespace Processing_JSON.Contracts
{
    public interface IVideoItem
    {
        string Title { get; set; }

        Link Link { get; set; }

        string Id { get; set; }
    }
}
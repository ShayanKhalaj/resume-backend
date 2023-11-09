namespace MyWebSiteBackend.application.common
{
    public interface IComplexObjectResult<TResults,TErrors>
    {
        TResults Results { get; set; }
        TErrors Errors { get; set; }
    }
}

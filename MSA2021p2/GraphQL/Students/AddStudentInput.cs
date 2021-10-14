namespace MSA2021p2.GraphQL.Students
{
    public record AddStudentInput
    (
        string Name,
        string GitHub,
        string? ImageURL
    )
    {
        public string ImageURI { get; internal set; }
    }
}

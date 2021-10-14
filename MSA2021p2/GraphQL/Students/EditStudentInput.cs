namespace MSA2021p2.GraphQL.Students
{
    public record EditStudentInput
    (
        string StudentId,
        string? Name,
        string? GitHub,
        string? ImageURI
    );

}

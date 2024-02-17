namespace FreelaDev.MsProjects.Core.Primitives;

/// <summary>
/// Represents an error
/// </summary>
public record Error
{
    public static Error None => new Error(string.Empty, string.Empty);
    
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }
    public string Code { get; set; }
    public string Message { get; set; }
}

/// <summary>
/// Represents the set of domain errors.
/// </summary>
public class DomainErrors
{
    public static class User
    {
        public static Error UserClientAndFreelancerMustNotBeEqual = new("User.ClientFreelancerMustNotBeEqual",
            "The client and freelancer specified must not be the same.");
        public static Error UserNotFound = new("User.NotFound", "The user was not found.");
        public static Error WrongCredentials = new("User.WrongCredentials", "The credentials informed are invalid.");
        public static Error EmailNotUnique => new("User.EmailNotUnique", "This e-mail is already taken.");
        public static Error SkillsIsEmpty => new("User.SkillsIsEmpty", "The skill list informed is empty.");
    }

    public static class Project
    {
        public static Error ProjectAlreadyStarted = new("Project.AlreadyStarted", "The project is already started.");
        public static Error ProjectAlreadyFinished = new("Project.AlreadyFinished", "The project is already finished.");
        public static Error ProjectNotFound = new("Project.NotFound", "The project was not found");
    }
}
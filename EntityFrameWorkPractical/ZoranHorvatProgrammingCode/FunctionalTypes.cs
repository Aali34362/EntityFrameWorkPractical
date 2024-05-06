namespace EntityFrameWorkPractical.ZoranHorvatProgrammingCode;

public record BooksType(string Title, NameType[] Authors);
internal record FullNameType(string FirstName, string LastName) : NameType;
public abstract record NameType;
internal record MononymType(string Name) : NameType;

public static class Books
{
    public static BooksType? Create(string title, params NameType[] authors) =>
        string.IsNullOrWhiteSpace(title) ? null : new(title, authors);
}

public static class Name
{
    public static NameType? Create(string firstName, string lastName) =>
        string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ? null 
        : new FullNameType(firstName, lastName);
    public static NameType? Create(string mononym) =>
        string.IsNullOrWhiteSpace(mononym) ? null : new MononymType(mononym);
    public static NameType[]? CreateMany(params NameType?[] names) =>
        names.Any(name => name is null) ? null : (NameType[]?)names!;
    /*
     * : (NameType[]?)names!; -> If none of the names is null, 
     * it returns the names array casted to NameType[] 
     * using the null-forgiving operator (!).
     * The null-forgiving operator tells the compiler to assume that 
     * the expression to its left is not null, even if the compiler
     * cannot guarantee it.
     */
    public static R Match<R>(this NameType name, Func<string, string, R> fullName, Func<string, R> mononym) =>
        name switch
        {
            FullNameType fn => fullName(fn.FirstName, fn.LastName),
            MononymType mono => mononym(mono.Name),
            _ => throw new InvalidOperationException("Unexception name type")
        };
}



public static class FunctionalTypes
{
    public static void DoOptional<T>(this T? obj, Action<T> action)
    {
        if (obj is not null) action(obj);
    }
    public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
    {
        foreach (T obj in sequence) action(obj);
    }
    public static R? BindOptional<T, R>(this T? obj, Func<T, R?> map)
        where T : class
        where R : class =>
        obj is null ? null : map(obj);

    public static R? MapOptional<T, R>(this T? obj, Func<T, R> map)
        where T : class
        where R : class =>
        obj is null ? null : map(obj);
}

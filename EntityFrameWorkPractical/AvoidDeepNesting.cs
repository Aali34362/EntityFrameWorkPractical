using System.Collections.Immutable;

namespace EntityFrameWorkPractical;

public class AvoidDeepNesting
{
    public Book? TryFindBook(IEnumerable<Book> books, string hint)
    {
        if (string.IsNullOrWhiteSpace(hint))
        {
            return null;
        }
        else
        {
            hint = hint.Trim();
            Book? best = null;
            foreach (var book in books)
            {
                if (book.Title.Contains(hint, StringComparison.OrdinalIgnoreCase))
                {
                    if (best is null)
                    {
                        best = book;
                    }
                }
                foreach (var author in book.Authors)
                {
                    if (author.FirstName.Contains(hint, StringComparison.OrdinalIgnoreCase) ||
                        author.LastName.Contains(hint, StringComparison.OrdinalIgnoreCase))
                    {
                        if (best is null)
                        {
                            best = book;
                        }
                    }
                }
            }
            return best;
        }
    }
    public Book? TryFindBookFirstChange(IEnumerable<Book> books, string hint)
    {
        if (string.IsNullOrWhiteSpace(hint))
        {
            return null;
        }
        else
        {
            hint = hint.Trim();
            Book? best = null;
            foreach (var book in books)
            {
                if (book.Title.Contains(hint, StringComparison.OrdinalIgnoreCase))
                {
                    best ??= book;
                }
                foreach (var author in book.Authors)
                {
                    if (author.FirstName.Contains(hint, StringComparison.OrdinalIgnoreCase) ||
                        author.LastName.Contains(hint, StringComparison.OrdinalIgnoreCase))
                    {
                        best ??= book;
                    }
                }
            }
            return best;
        }
    }
    public Book? TryFindBookSecondChange(IEnumerable<Book> books, string hint)
    {
        if (string.IsNullOrWhiteSpace(hint))
        {
            return null;
        }
        else
        {
            hint = hint.Trim();
            foreach (var book in books)
            {
                if (book.Title.Contains(hint, StringComparison.OrdinalIgnoreCase))
                {
                    return book;
                }
                foreach (var author in book.Authors)
                {
                    if (author.FirstName.Contains(hint, StringComparison.OrdinalIgnoreCase) ||
                        author.LastName.Contains(hint, StringComparison.OrdinalIgnoreCase))
                    {
                        return book;
                    }
                }
            }
            return null;
        }
    }
    public Book? TryFindBookThirdChange(IEnumerable<Book> books, string hint)
    {
        if (string.IsNullOrWhiteSpace(hint))
        {
            return null;
        }
        else
        {
            hint = hint.Trim();
            foreach (var book in books)
            {
                if (IsMatch(hint, book.Title))
                {
                    return book;
                }
                foreach (var author in book.Authors)
                {
                    if (IsMatch(hint, author.FirstName) || IsMatch(hint, author.LastName))
                    {
                        return book;
                    }
                }
            }
            return null;
        }
    }
    public Book? TryFindBookForthChange(IEnumerable<Book> books, string hint)
    {
        if (string.IsNullOrWhiteSpace(hint))
        {
            return null;
        }
        else
        {
            hint = hint.Trim();
            foreach (var book in books)
            {
                if (IsMatch(hint, book.Title))
                {
                    return book;
                }
                if (book.Authors.Any(author => IsAuthorMatch(hint, author)))
                    return book;
            }
            return null;
        }
    }
    public Book? TryFindBookFifthChange(IEnumerable<Book> books, string hint)
    {
        if (string.IsNullOrWhiteSpace(hint))
        {
            return null;
        }
        else
        {
            hint = hint.Trim();
            foreach (var book in books)
            {
                if (IsMatch(hint, book.Title) || IsAnyAuthorMatch(hint, book.Authors))
                    return book;
            }
            return null;
        }
    }
    public Book? TryFindBookSixthChange(IEnumerable<Book> books, string hint)
    {
        if (string.IsNullOrWhiteSpace(hint))
        {
            return null;
        }
        else
        {
            return books.FirstOrDefault(book => IsBookMatch(hint.Trim(), book));
        }
    }
    public Book? TryFindBookSeventhChange(IEnumerable<Book> books, string hint)
    {
        if (string.IsNullOrWhiteSpace(hint)) return null;
        return books.FirstOrDefault(book => IsBookMatch(hint.Trim(), book));
    }
    public Book? TryFindBookEighthChange(IEnumerable<Book> books, string hint)
    {
        return string.IsNullOrWhiteSpace(hint) ? null :
         books.FirstOrDefault(book => IsBookMatch(hint.Trim(), book));
    }
    public Book? TryFindBookFinal(IEnumerable<Book> books, string hint) =>
        string.IsNullOrWhiteSpace(hint) ? null :
         books.FirstOrDefault(book => IsBookMatch(hint.Trim(), book));
    
    private bool IsBookMatch(string hint, Book book) =>
        IsMatch(hint, book.Title) || IsAnyAuthorMatch(hint, book.Authors);
    private bool IsAnyAuthorMatch(string hint, IEnumerable<Author> authors) =>
        authors.Any(authors => IsAuthorMatch(hint, authors));
    private bool IsAuthorMatch(string hint, Author author) =>
    IsMatch(hint, author.FirstName) || IsMatch(hint, author.LastName);
    private bool IsMatch(string hint, string value) =>
    value.Contains(hint, StringComparison.OrdinalIgnoreCase);
}


public record Author(string FirstName, string LastName);
public record Book(string Title, ImmutableList<Author> Authors);

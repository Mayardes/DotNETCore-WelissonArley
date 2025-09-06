namespace MyBookOfRecipes.Domain.Pagination
{
    public class Paged
    {
        public int Size { get; set;} = 10;
        public int Page { get; set;} = 0;   
    }
}

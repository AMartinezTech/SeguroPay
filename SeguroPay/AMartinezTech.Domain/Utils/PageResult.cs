namespace AMartinezTech.Core.Utils;

public class PageResult<T>
{ 
    public int TotalRecords { get; set; }
    public int TotalPages { get; set; }
    public IReadOnlyList<T> Data { get; set; }

    public PageResult(int totalRecords, int pageSize, IReadOnlyList<T> data)
    {
        TotalRecords = totalRecords;
        TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize); ;
        Data = data;
    }
}

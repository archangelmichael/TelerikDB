namespace _01.UsingEFOnNorthwind
{
    using EntityFrameworkNorthwindModel;

    public class AdvancedEmployee : Employee
    {
        // EntitySet<T> is not available in EF 5/6 versions.

        public string Region
        {
            get
            {
                return this.Region;
            }
        }
    }
}

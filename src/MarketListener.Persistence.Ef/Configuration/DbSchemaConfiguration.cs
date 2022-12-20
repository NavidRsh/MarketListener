namespace MarketListener.Persistence.Ef.Configurations;

public abstract class DbSchemaConfiguration<TEntity> where TEntity : class
{
    public const string Prefix = "Tbl_";
    public const string Suffix = "s";
    public static string TableName = typeof(TEntity).Name + Suffix;
    public static string TableNameWithPrefix = Prefix + typeof(TEntity).Name;
    public static string TableNameWithPrefixAndSuffix = Prefix + typeof(TEntity).Name + Suffix;
}
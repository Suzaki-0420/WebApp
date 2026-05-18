namespace WebApp_Exercise.Applications.Adapters;

public interface IRestorer<TDomain, TTarget>
{
    TDomain Restore(TTarget target);
}
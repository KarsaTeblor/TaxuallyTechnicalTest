namespace Taxually.TechnicalTest.Model
{
    public class ServiceResult<TResult>
    {
        public TResult Result { get; set; }
        public ErrorStatusCode Error { get; set; }
        public bool HasError => Error != ErrorStatusCode.None;
    }
}

namespace WebApi.Middleware
{
    public abstract class AHandler<T> where T : class
    {
        private AHandler<T> next;

        public AHandler<T> LinkWith(AHandler<T> next)
        {
            this.next = next;

            return next;
        }

        public abstract bool Check(T model);

        protected bool CheckNext(T model)
        {
            if(next == null)
                return true;

            return next.Check(model);
        }
    }
}
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

        public abstract bool Check(T userPassword);

        protected bool CheckNext(T userPassword)
        {
            if(next == null)
                return true;

            return next.Check(userPassword);
        }
    }
}
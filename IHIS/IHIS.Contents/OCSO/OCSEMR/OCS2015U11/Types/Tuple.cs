namespace EmrDocker.Types
{
    public class Tuple<T1, T2>
    {
        private T1 v1;
        private T2 v2;

        public Tuple()
        {
        }

        public Tuple(T1 v1, T2 v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public T1 V1
        {
            get
            {
                return v1;
            }
            set
            {
                v1 = value;
            }
        }

        public T2 V2
        {
            get
            {
                return v2;
            }
            set
            {
                v2 = value;
            }
        }
    }
}
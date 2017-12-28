namespace EmrDocker.Types
{
    public class Triple<T1, T2, T3>
    {
        private T1 v1;
        private T2 v2;
        private T3 v3;

        /**
         * 
         */
        public Triple()
        {
        }

        public Triple(T1 v1, T2 v2, T3 v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
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

        public T3 V3
        {
            get
            {
                return v3;
            }
            set
            {
                v3 = value;
            }
        }
    }
}
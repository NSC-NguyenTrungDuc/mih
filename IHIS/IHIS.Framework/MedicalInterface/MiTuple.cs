namespace MedicalInterface
{
    public class MiTuple<T1, T2>
    {
        private T1 _v1;
        private T2 _v2;

        public MiTuple()
        {
        }

        public MiTuple(T1 v1, T2 v2)
        {
            _v1 = v1;
            _v2 = v2;
        }

        public T1 V1
        {
            get { return _v1; }
            set { _v1 = value; }
        }

        public T2 V2
        {
            get { return _v2; }
            set { _v2 = value; }
        }
    }
}
namespace IHIS.OCSO.Meta
{
    public class CustomMarkSchema
    {
        private int position;

        private UserData userData;

        public CustomMarkSchema()
        {
        }

        public CustomMarkSchema(int position, UserData userData)
        {
            this.position = position;
            this.userData = userData;
        }

        public int Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public UserData UserData
        {
            get
            {
                return userData;
            }
            set
            {
                userData = value;
            }
        }
    }
}
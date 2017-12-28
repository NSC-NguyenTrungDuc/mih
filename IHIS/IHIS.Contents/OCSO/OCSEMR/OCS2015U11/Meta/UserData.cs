namespace IHIS.OCSO.Meta
{
    public abstract class UserData
    {
        private CustomMarkType type;

        private string checksum;

        public UserData(CustomMarkType type, string checksum)
        {
            this.type = type;
            this.checksum = checksum;
        }

        public CustomMarkType Type
        {
            get
            {
                return type;
            }
            set
            {
                this.type = value;
            }
        }



        public string Checksum
        {
            get
            {
                return checksum;
            }
            set
            {
                this.checksum = value;
            }
        }
    }
}
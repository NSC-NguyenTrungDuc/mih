using IHIS.OCSO.Meta;

namespace EmrDocker.Meta
{
    public abstract class BookmarkMarker : UserData
    {
        public BookmarkMarker(CustomMarkType type, string checksum) : base(type, checksum)
        {
        }

        public BookmarkMarker(CustomMarkType type, string checksum, long commentId, int position)
            : this(type, checksum)
        {
            _commentId = commentId;
            _position = position;
        }

        private int _position;

        private long _commentId;

        public long CommentId
        {
            get { return _commentId; }
        }

        public int Position
        {
            get { return _position; }
        }
    }

    public class StartBookmarkMarker : BookmarkMarker
    {
        public StartBookmarkMarker(CustomMarkType type, string checksum) : base(type, checksum)
        {
        }

        public StartBookmarkMarker(CustomMarkType type, string checksum, long comment, int position)
            : base(type, checksum, comment, position)
        {
        }
    }

    public class EndBookmarkMarker : BookmarkMarker
    {
        public EndBookmarkMarker(CustomMarkType type, string checksum)
            : base(type, checksum)
        {
        }
        public EndBookmarkMarker(CustomMarkType type, string checksum, long comment, int position)
            : base(type, checksum, comment, position)
        {
        }
    }

    public class ParagraphMarker : UserData
    {
        public ParagraphMarker()
            : base(CustomMarkType.ParagraphMarker, "")
        {
        }
    }
}

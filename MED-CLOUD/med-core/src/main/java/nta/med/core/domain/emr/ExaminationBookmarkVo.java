package nta.med.core.domain.emr;

/**
 * @author dainguyen.
 */
public class ExaminationBookmarkVo {
    private String title;
    private String comment;
    private String userId;

    public ExaminationBookmarkVo() {
    }

    public ExaminationBookmarkVo(String title, String comment, String userId) {
        this.title = title;
        this.comment = comment;
        this.userId = userId;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getComment() {
        return comment;
    }

    public void setComment(String comment) {
        this.comment = comment;
    }

    public String getUserId() {
        return userId;
    }

    public void setUserId(String userId) {
        this.userId = userId;
    }
}

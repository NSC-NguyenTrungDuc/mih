package nta.med.core.domain.emr;

import java.util.ArrayList;
import java.util.List;

/**
 * @author dainguyen.
 */
public class ExaminationTagVo {
    private int order;
    private String tagCode;
    private String tagName;
    private byte type;
    private String createdDate;
    private String content;
    private List<ExaminationBookmarkVo> bookmarks;

    public ExaminationTagVo() {
        bookmarks = new ArrayList<>();
    }

    public ExaminationTagVo(int order, String tagCode, String tagName, byte type, String createdDate, String content) {
        this.order = order;
        this.tagCode = tagCode;
        this.tagName = tagName;
        this.type = type;
        this.createdDate = createdDate;
        this.content = content;
        bookmarks = new ArrayList<>();
    }

    public ExaminationTagVo(int order, String tagCode, String tagName, byte type, String createdDate, String content, List<ExaminationBookmarkVo> bookmarks) {
        this.order = order;
        this.tagCode = tagCode;
        this.tagName = tagName;
        this.type = type;
        this.createdDate = createdDate;
        this.content = content;
        this.bookmarks = bookmarks;
    }

    public int getOrder() {
        return order;
    }

    public void setOrder(int order) {
        this.order = order;
    }

    public String getTagCode() {
        return tagCode;
    }

    public void setTagCode(String tagCode) {
        this.tagCode = tagCode;
    }

    public String getTagName() {
        return tagName;
    }

    public void setTagName(String tagName) {
        this.tagName = tagName;
    }

    public byte getType() {
        return type;
    }

    public void setType(byte type) {
        this.type = type;
    }

    public String getCreatedDate() {
        return createdDate;
    }

    public void setCreatedDate(String createdDate) {
        this.createdDate = createdDate;
    }

    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }

    public List<ExaminationBookmarkVo> getBookmarks() {
        return bookmarks;
    }

    public void setBookmarks(List<ExaminationBookmarkVo> bookmarks) {
        this.bookmarks = bookmarks;
    }
}

package nta.med.ext.phr.model;


/**
 * @author DEV-TiepNM
 */
public class MessageResponse<T> {
    T content;
    String message;
    String status;
    public  MessageResponse()
    {

    }
    public MessageResponse(MessageResponseBuilder messageResponseBuilder) {
        this.content = (T)messageResponseBuilder.content;
        this.message = messageResponseBuilder.message;
        this.status = messageResponseBuilder.status;
    }

    public T getContent() {
        return content;
    }

    public void setContent(T content) {
        this.content = content;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String code) {
        this.status = code;
    }

    public static class  MessageResponseBuilder<T>
    {
        T content;
        String message;
        String status;
        public MessageResponseBuilder(String message, String status)
        {
            this.message = message;
            this.status = status;
        }
        public MessageResponseBuilder setContent(T content) {
            this.content = content;
            return this;
        }

        public MessageResponseBuilder setMessage(String message) {
            this.message = message;
            return this;
        }

        public MessageResponseBuilder setStatus(String status) {
            this.status = status;
            return this;
        }
        public MessageResponse build()
        {
            return new MessageResponse(this);
        }
    }
}

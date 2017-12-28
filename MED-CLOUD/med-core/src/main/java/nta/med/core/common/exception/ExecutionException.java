package nta.med.core.common.exception;

import com.google.protobuf.Message;

/**
 * @author dainguyen.
 */
public class ExecutionException extends RuntimeException {

    private Message cookie;

    public ExecutionException() {
    }


    public ExecutionException(String message, Throwable cause) {
        super(message, cause);
    }

    public ExecutionException(Message cookie) {
        this.cookie = cookie;
    }

    public ExecutionException(String message, Message cookie) {
        super(message);
        this.cookie = cookie;
    }

    public ExecutionException(String message, Throwable cause, Message cookie) {
        super(message, cause);
        this.cookie = cookie;
    }

    public Message getCookie() {
        return cookie;
    }

    public void setCookie(Message cookie) {
        this.cookie = cookie;
    }
}

package nta.sfd.info;

import java.io.Serializable;

import org.springframework.http.HttpStatus;

/**
 * This class is used to build response in ajax call.
 *
 * @author DinhNX
 * @CrtDate Aug 14, 2014
 */
public class AjaxResponse implements Serializable {
	private static final long serialVersionUID = -5876523879694245247L;
	
	private final Integer status;
	private final String message;
	private final Object data;
	
	/**
	 * Instantiates a new ajax response.
	 *
	 * @param builder the builder
	 */
	private AjaxResponse(AjaxResponseBuilder builder) {
		this.status = builder.status;
		this.message = builder.message;
		this.data = builder.data;
	}
	
	/**
	 * Gets the status.
	 *
	 * @return the status
	 */
	public Integer getStatus() {
		return status;
	}
	
	/**
	 * Gets the message.
	 *
	 * @return the message
	 */
	public String getMessage() {
		return message;
	}
	
	/**
	 * Gets the data.
	 *
	 * @return the data
	 */
	public Object getData() {
		return data;
	}
	
	/**
	 * The builder to build ajax response.
	 *
	 * @author DinhNX
	 * @CrtDate Aug 14, 2014
	 */
	public static class AjaxResponseBuilder {
		
		private Integer status;
		private String message;
		private Object data;
		
		/**
		 * Set status to build ajax response.
		 *
		 * @param status the status
		 * @return the ajax response builder
		 */
		public AjaxResponseBuilder status(HttpStatus status) {
			if (status == null) {
				this.status = 0;
			}
			else {
				this.status = status.value();
			}
			return this;
		}
		
		/**
		 * Set message to build ajax response.
		 *
		 * @param message the message
		 * @return the ajax response builder
		 */
		public AjaxResponseBuilder message(String message) {
			this.message = message;
			return this;
		}
		
		/**
		 * Set data to build ajax response.
		 *
		 * @param data the data
		 * @return the ajax response builder
		 */
		public AjaxResponseBuilder data(Object data) {
			this.data = data;
			return this;
		}
		
		/**
		 * Builds the ajax response.
		 *
		 * @return the ajax response
		 */
		public AjaxResponse build() {
			return new AjaxResponse(this);
		}
	}
}

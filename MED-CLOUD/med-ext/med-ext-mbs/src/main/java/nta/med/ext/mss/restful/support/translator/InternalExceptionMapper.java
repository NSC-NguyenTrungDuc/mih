package nta.med.ext.mss.restful.support.translator;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import javax.ws.rs.ext.ExceptionMapper;
import javax.ws.rs.ext.Provider;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import nta.med.ext.mss.glossary.Message;
import nta.med.ext.mss.model.MessageResponse;

/**
 * @author dainguyen.
 */
@Provider
public class InternalExceptionMapper implements ExceptionMapper<Exception> {

	private static final Log LOGGER = LogFactory.getLog(InternalExceptionMapper.class);

	@Override
	public Response toResponse(Exception e) {
		MessageResponse response = new MessageResponse();
		response.setStatus(Message.FAIL.getValue());
		response.setMessage(Message.MESSAGE_REQUEST_INPUT_FAIL.getValue());

		if(e instanceof javax.ws.rs.NotFoundException || e instanceof org.glassfish.jersey.server.ParamException){
			if(e instanceof org.glassfish.jersey.server.ParamException){
				LOGGER.error("Input param was not valid !!!");
			}

			LOGGER.warn(e.getMessage());
			return Response.status(404).entity(response).type(MediaType.APPLICATION_JSON).build();
		}

		if(e instanceof javax.ws.rs.NotAllowedException){
			LOGGER.warn(e.getMessage());
			return Response.status(405).entity(response).type(MediaType.APPLICATION_JSON).build();
		}

		LOGGER.warn(e.getMessage(), e);

		if (e instanceof com.fasterxml.jackson.databind.JsonMappingException
				|| e instanceof com.fasterxml.jackson.core.JsonParseException) {
			return Response.status(400).entity(response).type(MediaType.APPLICATION_JSON).build();
		}

		return Response.status(500).entity(response).type(MediaType.APPLICATION_JSON).build();

	}
}

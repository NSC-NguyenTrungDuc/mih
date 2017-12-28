package nta.med.ext.phr.support.translator;



import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import javax.ws.rs.ext.ExceptionMapper;
import javax.ws.rs.ext.Provider;

import nta.med.ext.phr.exception.EntityNotFoundException;
import nta.med.ext.phr.glossary.Message;
import nta.med.ext.phr.model.MessageResponse;

/**
 * @author dainguyen
 */

@Provider
public class EntityNotFoundMapper implements ExceptionMapper<EntityNotFoundException> {

    public Response toResponse(EntityNotFoundException ex) {

        MessageResponse response = new MessageResponse();
        response.setStatus(Message.FAIL.getValue());
        response.setMessage(Message.MESSAGE_ENTITY_NOT_FOUND_FAIL.getValue());

        return Response.status(404).entity(response).type(MediaType.APPLICATION_JSON).build();
    }
}

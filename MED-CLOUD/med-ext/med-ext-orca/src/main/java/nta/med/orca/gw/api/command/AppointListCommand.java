package nta.med.orca.gw.api.command;

import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.Entity;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import org.glassfish.jersey.internal.util.Base64;
import org.springframework.stereotype.Component;
import org.springframework.util.StringUtils;

import nta.med.orca.gw.api.contracts.service.AppointListRequest;
import nta.med.orca.gw.api.contracts.service.AppointListResponse;
import nta.med.orca.gw.api.contracts.wrapper.AppointListWrapper;

@Component("appointListCommand")
public class AppointListCommand extends AbstractCommand<AppointListRequest, AppointListResponse> {

	@Override
	public AppointListResponse execute(AppointListRequest request) throws Exception {
		Client client = ClientBuilder.newClient().register(json).register(xml);
		String requestBody = "";
		if(StringUtils.isEmpty(request.getPhysicianCode())){
			requestBody = "<data><appointlstreq type=\"record\"><Appointment_Date type=\"string\">" + request.getAppointmentDate() + "</Appointment_Date></appointlstreq></data>";
		} else {
			requestBody = "<data><appointlstreq type=\"record\"><Appointment_Date type=\"string\">" + request.getAppointmentDate() + "</Appointment_Date><Physician_Code type=\"string\">" + request.getPhysicianCode() + "</Physician_Code></appointlstreq></data>";
		}
        
        String strUri = "http://" + request.getOrcaEnvInfo().getOrcaIp() + ":" + request.getOrcaEnvInfo().getOrcaPort() + "/api01rv2/appointlstv2?class=01";
        Response response = client
        		.target(strUri)
        		.request(MediaType.APPLICATION_XML_TYPE)
                .header("Authorization", "Basic " + Base64.encodeAsString(String.format("%s:%s", request.getOrcaEnvInfo().getOrcaUser(), request.getOrcaEnvInfo().getOrcaPwd()).getBytes()))
                .post(Entity.entity(requestBody, MediaType.APPLICATION_XML_TYPE));
        if(Response.Status.Family.SUCCESSFUL.equals(Response.Status.Family.familyOf(response.getStatus())) && response.hasEntity()){
        	AppointListWrapper wrapper = response.readEntity(AppointListWrapper.class);
        	return wrapper == null ? null : wrapper.getResponse();
        } else {
            String responseText = response.readEntity(String.class);
            throw new Exception(response.getStatus() + ": there was an error on the server. \n" + responseText);
        }
	}

}

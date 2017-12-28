package nta.med.ext.cms.restful.controller;

import javax.annotation.Resource;
import javax.validation.Valid;
import javax.validation.constraints.NotNull;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import org.springframework.stereotype.Component;
import org.springframework.util.StringUtils;

import nta.med.core.common.annotation.TokenIgnore;
import nta.med.core.utils.EncryptionUtils;
import nta.med.ext.cms.config.Configuration;
import nta.med.ext.cms.glossary.Message;
import nta.med.ext.cms.model.KcckUserModel;
import nta.med.ext.cms.model.MessageResponse;
import nta.med.ext.cms.model.cms.LoginResponseModel;
import nta.med.ext.cms.service.HospitalService;

@Path("/kcck")
@Component
public class SecurityRestController {

	@Resource
	private HospitalService hospitalService;

	@Resource
	private Configuration configuration;
	
	public SecurityRestController(){
		
	}
	
	@TokenIgnore
	@POST
	@Path("/login")
	@Produces(MediaType.APPLICATION_JSON)
	public Response checkUserLogin(@Valid @NotNull KcckUserModel model) throws Exception {
		
		String hospCode = EncryptionUtils.decrypt(model.getHospCode(), configuration.getSecretKey(), 
		EncryptionUtils.ENCRYPT_ALGORITHM_AES, EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);
		if(StringUtils.isEmpty(hospCode)){
			// set result
			MessageResponse<String> messageResponse = new MessageResponse.MessageResponseBuilder<String>(
					Message.HOSP_CODE_INVALID.getValue(), Message.FAIL.getValue()).build();

			return Response.ok().entity(messageResponse).build();
		}
		model.setHospCode(hospCode);
		
		LoginResponseModel rp = hospitalService.checkLogin(model);
		String responseStatus = rp == null ? Message.FAIL.getValue() : Message.SUCCESS.getValue();
		String responseMessage = rp == null ? Message.MESSAGE_FAIL.getValue() : Message.MESSAGE_SUCCESS.getValue();
		
		MessageResponse<LoginResponseModel> messageResponse = new MessageResponse.MessageResponseBuilder<LoginResponseModel>(responseMessage, responseStatus).setContent(rp).build();
		return Response.ok().entity(messageResponse).build();
	}
}

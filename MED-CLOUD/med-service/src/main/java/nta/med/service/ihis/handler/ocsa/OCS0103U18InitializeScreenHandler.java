package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.dao.medi.cpl.Cpl0108Repository;
import nta.med.data.dao.medi.ocs.Ocs0101Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U17LayHangwiGubunInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U18MakeJaeryoGubunTabListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.helper.OrderBizHelper;
import nta.med.service.ihis.proto.CommonModelProto.GetMainGwaDoctorCodeInfo;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U18InitializeScreenRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U18InitializeScreenResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U18InitializeScreenHandler
	extends ScreenHandler<OcsaServiceProto.OCS0103U18InitializeScreenRequest, OcsaServiceProto.OCS0103U18InitializeScreenResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U18InitializeScreenHandler.class);                                    
	@Resource                                                                                                       
	private Cpl0108Repository cpl0108Repository;                                                                    
	@Resource
	private Ocs0101Repository ocs0101Repository;
	@Resource
	private Ocs0132Repository ocs0132Repository;
	@Resource
	private Bas0270Repository bas0270Repository;
	
	@Override          
	@Transactional(readOnly = true)
	public OCS0103U18InitializeScreenResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U18InitializeScreenRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0103U18InitializeScreenResponse.Builder response = OcsaServiceProto.OCS0103U18InitializeScreenResponse.newBuilder();
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		if(!StringUtils.isEmpty(request.getMOrderMode()) && request.getMOrderMode().equals("1")){
			String name = OrderBizHelper.getLoadColumnCodeName(hospCode, language, request.getColCodeName());
			if(!StringUtils.isEmpty(name)){
				response.setName(name);
			}
			GetMainGwaDoctorCodeInfo inputInfo = request.getGwaDoctorCode();
			if(inputInfo != null){
				String doctorCode = bas0270Repository.getMainGwaDoctorCodeInfo(hospCode, inputInfo.getMemb());
				if(!StringUtils.isEmpty(doctorCode)){
					response.setMainDoctorCode(doctorCode);
				}
			}
		}
		List<OCS0103U17LayHangwiGubunInfo> list = ocs0101Repository.getOCS0103U17LayHangwiGubunListItem(hospCode, request.getUserId(),"N","09", getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(list)){
			for(OCS0103U17LayHangwiGubunInfo item : list){
				OcsaModelProto.OCS0103U17LayHangwiGubunInfo.Builder info = OcsaModelProto.OCS0103U17LayHangwiGubunInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayHangwiGubunInfo(info);
			}
		}
			
		List<OCS0103U18MakeJaeryoGubunTabListItemInfo> listResult = ocs0132Repository.getOCS0103U18InitializeScreenMakeJaeryoGubunTabListItem(hospCode, request.getInputTab(), language);
		LOGGER.info("RESPONSE :" + response.build().toString());     
		if(!CollectionUtils.isEmpty(listResult)){
			for(OCS0103U18MakeJaeryoGubunTabListItemInfo item : listResult){
				OcsaModelProto.OCS0103U18MakeJaeryoGubunTabListItemInfo.Builder info = OcsaModelProto.OCS0103U18MakeJaeryoGubunTabListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addMakeJaeryoGubunInfo(info);
			}
		}
		
		return response.build();
	}

}
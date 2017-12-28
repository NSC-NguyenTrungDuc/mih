package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.bass.LoadGrdBAS0260U01Info;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.Bass0260U00DepartmentRequest;
import nta.med.service.ihis.proto.BassServiceProto.Bass0260U00DepartmentResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class Bass0260U00DepartmentHandler extends ScreenHandler<BassServiceProto.Bass0260U00DepartmentRequest, BassServiceProto.Bass0260U00DepartmentResponse> {                             
	
	private static final Log LOGGER = LogFactory.getLog(Bass0260U00DepartmentHandler.class);                                        
	
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;   
	
	@Resource                                                                                                       
	private Adm0000Repository adm0000Repository;
	                                                                  
	@Override        
	@Transactional(readOnly = true)
	public Bass0260U00DepartmentResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
		Bass0260U00DepartmentRequest request) throws Exception {
		BassServiceProto.Bass0260U00DepartmentResponse.Builder response = BassServiceProto.Bass0260U00DepartmentResponse.newBuilder();
		
		String gwaName =  request.getGwaName();
		String language = getLanguage(vertx, sessionId);
		String hospCode = getHospitalCode(vertx, sessionId);
		
		if(!StringUtils.isEmpty(gwaName) && Language.JAPANESE.toString().equalsIgnoreCase(language))
		{
			gwaName = adm0000Repository.callFnAdmConvertKanaFull(hospCode, gwaName);
		}
		
		List<LoadGrdBAS0260U01Info> bas0260DepartmentInfos = bas0260Repository.getBas0260ListGetDepartment(language, request.getBuseoGubun(), gwaName, "1");
		if(!CollectionUtils.isEmpty(bas0260DepartmentInfos)){
			for(LoadGrdBAS0260U01Info item : bas0260DepartmentInfos){
				BassModelProto.Bass0260U00DepartmentInfo.Builder info = BassModelProto.Bass0260U00DepartmentInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addItemInfo(info);
			}
		}
		return response.build();
	}
}

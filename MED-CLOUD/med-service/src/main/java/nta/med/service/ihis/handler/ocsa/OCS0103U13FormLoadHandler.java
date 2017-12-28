package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.dao.medi.ocs.Ocs0142Repository;
import nta.med.data.dao.medi.ocs.Ocs0150Repository;
import nta.med.data.dao.medi.ocs.Ocs1024Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U13LaySpecimenTreeListInfo;
import nta.med.data.model.ihis.system.LoadOftenUsedTabResponseInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U13FormLoadRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U13FormLoadResponse;

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
public class OCS0103U13FormLoadHandler
	extends ScreenHandler<OcsaServiceProto.OCS0103U13FormLoadRequest, OcsaServiceProto.OCS0103U13FormLoadResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0103U13FormLoadHandler.class);                                        
	@Resource                                                                                                       
	private Ocs0150Repository ocs0150Repository;   
	@Resource
	private Bas0270Repository bas0270Repository;
	@Resource
	private Ocs0142Repository ocs0142Repository;
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;    
	@Resource
	private Ocs1024Repository oOcs1024Repository;
	@Override                         
	@Transactional(readOnly = true)
	public OCS0103U13FormLoadResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0103U13FormLoadRequest request)
			throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0103U13FormLoadResponse.Builder response = OcsaServiceProto.OCS0103U13FormLoadResponse.newBuilder();                      
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		//  optional GetUserOptionInfo user_opt_info = 1;
		String  userOpt=ocs0150Repository.getOcsOrderBizGetUserOptionInfo(hospCode,request.getUserOptInfo().getDoctor(),
			request.getUserOptInfo().getGwa(),request.getUserOptInfo().getKeyword(),request.getUserOptInfo().getIoGubun());
		if(!StringUtils.isEmpty(userOpt)){
			response.setUserOptResult(userOpt);
		}
		// Load columnCodeName + GetMainGwaDoctorCodeInfo
		if(request.getMOrderMode().equals("1")){
			String codeName = bas0270Repository.getLoadColumnCodeNameInfoCaseGwaDoctor(hospCode,
					request.getColCodeNameInfo().getArg1(), request.getColCodeNameInfo().getArg2(), request.getColCodeNameInfo().getArg3());
			if(StringUtils.isEmpty(codeName)){
				String mainDoctorCode = bas0270Repository.getMainGwaDoctorCodeInfo(hospCode, request.getGwaDoctorCodeInfo().getMemb());
				if(!StringUtils.isEmpty(mainDoctorCode)){
					response.setMainDoctorCode(mainDoctorCode);
				}
			}
			if(!StringUtils.isEmpty(codeName)){
				response.setCodeName(codeName);	
			}	
		}
		// LoadOftenUsedTabRequestInfo response
		List<LoadOftenUsedTabResponseInfo> listUserTab=null;
		if(!request.getUsedTabInfo().getInputTab().equals("07")){
			listUserTab=ocs0142Repository.getLoadOftenUsedTabInfo(hospCode, language,
					request.getUsedTabInfo().getMemb(), request.getUsedTabInfo().getInputTab());
		}else{
			listUserTab =ocs0142Repository.getLoadOftenUsedTabInfoElse(hospCode, language,request.getUsedTabInfo().getMemb());
		}
		if(!CollectionUtils.isEmpty(listUserTab)){
			for(LoadOftenUsedTabResponseInfo item : listUserTab){
				CommonModelProto.LoadOftenUsedTabResponseInfo.Builder info = CommonModelProto.LoadOftenUsedTabResponseInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLoadOfterUsedTabInfo(info);
			}
			
		}
		   // SpecimenTreeResponse response
		List<OCS0103U13LaySpecimenTreeListInfo> listGrdSpecTree =ocs0103Repository.getOCS0103U13LaySpecimenTreeListInfo(hospCode, language, request.getUser());
		if(!CollectionUtils.isEmpty(listGrdSpecTree)){
			for(OCS0103U13LaySpecimenTreeListInfo item : listGrdSpecTree){
				OcsaModelProto.OCS0103U13LaySpecimenTreeListInfo.Builder info = OcsaModelProto.OCS0103U13LaySpecimenTreeListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdSpecTreeItem(info);
			}
		}
		return response.build();
	}
}
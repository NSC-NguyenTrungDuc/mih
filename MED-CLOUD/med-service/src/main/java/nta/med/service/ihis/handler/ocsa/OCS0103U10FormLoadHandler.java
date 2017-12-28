package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.glossary.OrderMode;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.dao.medi.drg.Drg9043Repository;
import nta.med.data.dao.medi.ocs.Ocs0142Repository;
import nta.med.data.dao.medi.ocs.Ocs0150Repository;
import nta.med.data.dao.medi.ocs.Ocs1024Repository;
import nta.med.data.model.ihis.system.LoadOftenUsedTabResponseInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U10FormLoadRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U10FormLoadResponse;

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
public class OCS0103U10FormLoadHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U10FormLoadRequest, OcsaServiceProto.OCS0103U10FormLoadResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U10FormLoadHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0150Repository ocs0150Repository;                                                                      
	@Resource
	private Drg9043Repository drg9043Repository;
	@Resource
	private Ocs0142Repository ocs0142Repository;
	@Resource
	private Ocs1024Repository ocs1024Repository;
	@Resource
	private Bas0270Repository bas0270Repository;
	@Override               
	@Transactional(readOnly = true)
	public OCS0103U10FormLoadResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0103U10FormLoadRequest request)
			throws Exception {   
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		
  	   	OcsaServiceProto.OCS0103U10FormLoadResponse.Builder response = OcsaServiceProto.OCS0103U10FormLoadResponse.newBuilder();                      
		//  optional GetUserOptionInfo general_disp_yn = 1;
			String  userGeneral=ocs0150Repository.getOcsOrderBizGetUserOptionInfo(hospCode,request.getGeneralDispYn().getDoctor(),
						request.getGeneralDispYn().getGwa(),request.getGeneralDispYn().getKeyword(),request.getGeneralDispYn().getIoGubun());
			if(!StringUtils.isEmpty(userGeneral)){
				response.setGeneralDispYn(userGeneral);
			}	
		//  optional GetUserOptionInfo sentou_search_yn = 2;
			String  userSentou=ocs0150Repository.getOcsOrderBizGetUserOptionInfo(hospCode,request.getSentouSearchYn().getDoctor(),
						request.getSentouSearchYn().getGwa(),request.getSentouSearchYn().getKeyword(),request.getSentouSearchYn().getIoGubun());
			if(!StringUtils.isEmpty(userSentou)){
				response.setSentouSearchYn(userSentou);
			}
			//is_check_drg_time
			if(request.getIsCheckDrgTime()){
				//String currentTime = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss").format(new Date()); 
				String currentTime = DateUtil.getCurrentHH24MI(); 
				String checkDrgTime=drg9043Repository.checkDrgsDRG5100P01GetTimer(currentTime, hospCode);
				if(!StringUtils.isEmpty(checkDrgTime)){
					response.setCheckDrgTime(checkDrgTime);
				}
			}
			//if (this.mOrderMode == OrderVariables.OrderMode.InpOrder)
			if(request.getOrderMode().equals(OrderMode.InpOrder.getValue())){ 
				String brougDrgYn=ocs1024Repository.callFnOcsIsBroughtDrgYn(hospCode,request.getBunho(),
						CommonUtils.parseInteger(request.getPkinp1001()),request.getInputTab());
				if(!StringUtils.isEmpty(brougDrgYn)){
					response.setBroughtDrgYn(brougDrgYn);
				}
			}
							
			// if (this.mOrderMode == OrderVariables.OrderMode.SetOrder)
			if(request.getOrderMode().equals(OrderMode.SetOrder.getValue())){
				String codeName = bas0270Repository.getLoadColumnCodeNameInfoCaseGwaDoctor(hospCode,
						request.getCodeNameInfo().getArg1(), request.getCodeNameInfo().getArg2(), request.getCodeNameInfo().getArg3());
				if(StringUtils.isEmpty(codeName)){
					String mainDoctorCode = bas0270Repository.getMainGwaDoctorCodeInfo(hospCode, request.getGwaDoctorCodeInfo().getMemb());
					if(!StringUtils.isEmpty(mainDoctorCode)){
						response.setMainDoctorCode(mainDoctorCode);
					}
				}
				if(!StringUtils.isEmpty(codeName)){
					response.setName(codeName);
				}	
			}
			// mOrderBiz.LoadOftenUsedTabInfo LoadOftenUsedTabRequestInfo
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
					response.addUsedTabResponseInfo(info);
				}
				
			}
		return response.build();	
	}
}
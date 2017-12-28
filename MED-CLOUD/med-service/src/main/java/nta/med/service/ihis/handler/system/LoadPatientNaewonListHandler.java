package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.system.LoadPatientNaewonListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.LoadPatientNaewonListRequest;
import nta.med.service.ihis.proto.SystemServiceProto.LoadPatientNaewonListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class LoadPatientNaewonListHandler
	extends ScreenHandler<SystemServiceProto.LoadPatientNaewonListRequest, SystemServiceProto.LoadPatientNaewonListResponse> {                     
	@Resource                                                                                                       
	private Out1001Repository  out1001Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public LoadPatientNaewonListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			LoadPatientNaewonListRequest request) throws Exception {                                                                  
  	   	SystemServiceProto.LoadPatientNaewonListResponse.Builder response = SystemServiceProto.LoadPatientNaewonListResponse.newBuilder();                      
		List<LoadPatientNaewonListInfo> listResult = out1001Repository.getLoadPatientNaewonListItem(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
						request.getApproveDoctor(),request.getDoctorModeYn(),request.getIoGubun(),request.getPkKeyOut(),request.getBunho(),
						request.getNaewonDate(),request.getGwa(),request.getDoctor(),request.getJaewonFlag(),request.getPkKeyInp(),request.getIsEnableIpwonReser());
		if(!CollectionUtils.isEmpty(listResult)){
			for(LoadPatientNaewonListInfo item : listResult){
				CommonModelProto.LoadPatientNaewonListInfo.Builder info = CommonModelProto.LoadPatientNaewonListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if(item.getJubsuNo() != null){
					info.setJubsuNo(String.format("%.0f", item.getJubsuNo()));
				}
				if(item.getPkKey() != null){
					info.setPkKey(String.format("%.0f", item.getPkKey()));
				}
				response.addNaewonListItem(info);
			}
		}
		return response.build(); 
	}                                                                                                                                                   
}
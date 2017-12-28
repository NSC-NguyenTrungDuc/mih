package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inj.Inj0101Repository;
import nta.med.data.dao.medi.inj.Inj0102Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.injs.InjsINJ1001FormJusaBedLayPatientItemInfo;
import nta.med.data.model.ihis.injs.InjsINJ1001U01FormJusaBedLayHosilItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")    
public class InjsINJ1001FormJusaBedLayGroupedHandler extends ScreenHandler<InjsServiceProto.INJ1001FormJusaBedLayGroupedRequest, InjsServiceProto.INJ1001FormJusaBedLayGroupedResponse> {
	private static final Log LOGGER = LogFactory.getLog(InjsINJ1001FormJusaBedLayGroupedHandler.class);                                        
	@Resource
	private Inj0101Repository inj0101Repository;
	@Resource
	private Out0101Repository out0101Repository;
	@Resource
	private Inj0102Repository inj0102Repository;

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ1001FormJusaBedLayGroupedResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ1001FormJusaBedLayGroupedRequest request) throws Exception {
		InjsServiceProto.INJ1001FormJusaBedLayGroupedResponse.Builder response = InjsServiceProto.INJ1001FormJusaBedLayGroupedResponse.newBuilder();
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		// get INJ1001U01FormJusaBedLayHosilListResponse
		List<InjsINJ1001U01FormJusaBedLayHosilItemInfo> getLayPatientList = inj0101Repository.getInjsINJ1001U01FormJusaBedLayHosilItemInfo(hospitalCode, language);
		if(!CollectionUtils.isEmpty(getLayPatientList)){
			for(InjsINJ1001U01FormJusaBedLayHosilItemInfo item : getLayPatientList){
				InjsModelProto.INJ1001U01FormJusaBedLayHosilItemInfo .Builder info = InjsModelProto.INJ1001U01FormJusaBedLayHosilItemInfo .newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addBedLayHosilItem(info);
			}
		}
		//get INJ1001FormJusaBedLayPatientListResponse
		List<InjsINJ1001FormJusaBedLayPatientItemInfo> getInjsINJ1001FormJusaBedLayPatientItemInfo= out0101Repository.getInjsINJ1001FormJusaBedLayPatientItemInfo(hospitalCode, language);
		if(!CollectionUtils.isEmpty(getInjsINJ1001FormJusaBedLayPatientItemInfo)){
			for(InjsINJ1001FormJusaBedLayPatientItemInfo item : getInjsINJ1001FormJusaBedLayPatientItemInfo){
				InjsModelProto.INJ1001FormJusaBedLayPatientItemInfo.Builder info= InjsModelProto.INJ1001FormJusaBedLayPatientItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayPatientItem(info);
			}
		}
		//get INJ1001U01FormJusaBedLayPatientResponse
		List<String> getCodeName = inj0102Repository.getINJ1001U01FormJusaBedLayPatientRequest(hospitalCode, request.getCodeName(), language);
        if(!CollectionUtils.isEmpty(getCodeName)){
        	for(String item : getCodeName){
        		response.addCodeName(item);
        	}
        }
		return response.build();
	}  
}

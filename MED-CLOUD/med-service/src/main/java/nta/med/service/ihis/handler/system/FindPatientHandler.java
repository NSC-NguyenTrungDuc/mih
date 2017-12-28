package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.system.FindPatientInfo;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.FindPatientFromRequest;
import nta.med.service.ihis.proto.SystemServiceProto.FindPatientFromResponse;

@Service
@Scope("prototype")
public class FindPatientHandler
	extends ScreenHandler<SystemServiceProto.FindPatientFromRequest, SystemServiceProto.FindPatientFromResponse>{
	@Resource
	private Out0101Repository out0101Repository;
	
	@Override
	@Transactional(readOnly = true)
	public FindPatientFromResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, FindPatientFromRequest request)
			throws Exception {
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		String suname2 = request.getPatientName2();
		if(getLanguage(vertx, sessionId).equals(Language.JAPANESE.toString().toUpperCase())){
			suname2 = CommonUtils.convertToHalfWidthKana(suname2);
		}
        List<FindPatientInfo> listFindPatientInfo = out0101Repository.getFindPatientInfo(getHospitalCode(vertx, sessionId),
        		getLanguage(vertx, sessionId), suname2, request.getSex(), request.getBirth(), request.getTel(), request.getType(), startNum, CommonUtils.parseInteger(offset));
        SystemServiceProto.FindPatientFromResponse.Builder response = SystemServiceProto.FindPatientFromResponse.newBuilder();
        if (listFindPatientInfo != null && !listFindPatientInfo.isEmpty()) {
            for (FindPatientInfo obj : listFindPatientInfo) {
            	SystemModelProto.FindPatientInfo.Builder builder = SystemModelProto.FindPatientInfo.newBuilder();
                BeanUtils.copyProperties(obj, builder, getLanguage(vertx, sessionId));
                response.addPatientInfoItem(builder);
            }
        }
        return response.build();    
	}
}

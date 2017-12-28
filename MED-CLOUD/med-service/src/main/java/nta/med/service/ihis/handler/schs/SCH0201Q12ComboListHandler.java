package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.sch.Sch0109Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201Q12ComboListRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201Q12ComboListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SCH0201Q12ComboListHandler
	extends ScreenHandler<SchsServiceProto.SCH0201Q12ComboListRequest, SchsServiceProto.SCH0201Q12ComboListResponse> {
	@Resource
	private Bas0260Repository bas0260Repository;
	@Resource
	private Sch0109Repository sch0109Repository;
	@Override
	@Transactional(readOnly=true)
	public SCH0201Q12ComboListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, SCH0201Q12ComboListRequest request)
			throws Exception {
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
	     List<ComboListItemInfo> listResult = sch0109Repository.getSCH0201Q12CboAppointmentList(hospCode, language);
	     SchsServiceProto.SCH0201Q12ComboListResponse.Builder  response =  SchsServiceProto.SCH0201Q12ComboListResponse.newBuilder();
	     if(listResult != null && !listResult.isEmpty()){
	    	 for(ComboListItemInfo item : listResult){
	    		 CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
	    		 if (!StringUtils.isEmpty(item.getCode())) {
                		info.setCode(item.getCode());
                	}
                	if (item.getCodeName() != null) {
                		info.setCodeName(item.getCodeName());
                	}
                	response.addCboGumsa(info);
	    	 }
	     }
	     List<ComboListItemInfo> listGwa = bas0260Repository.getSCH0201Q12CboDepartmentList(hospCode, language);
	     if(listGwa != null && !listGwa.isEmpty()){
	    	 for(ComboListItemInfo item : listGwa){
	    		 CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
	    		 if (!StringUtils.isEmpty(item.getCode())) {
                		info.setCode(item.getCode());
                	}
                	if (item.getCodeName() != null) {
                		info.setCodeName(item.getCodeName());
                	}
                	response.addCboGwa(info);
	    	 }
	     }
		 return response.build(); 
	}
}

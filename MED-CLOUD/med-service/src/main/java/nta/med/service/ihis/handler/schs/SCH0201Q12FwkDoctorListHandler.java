package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201Q12FwkDoctorListRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201Q12FwkDoctorListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SCH0201Q12FwkDoctorListHandler
	extends ScreenHandler<SchsServiceProto.SCH0201Q12FwkDoctorListRequest, SchsServiceProto.SCH0201Q12FwkDoctorListResponse> {
	@Resource
	private Sch0201Repository sch0201Repository;
	@Override
	@Transactional(readOnly=true)
	public SCH0201Q12FwkDoctorListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH0201Q12FwkDoctorListRequest request) throws Exception {
	     SchsServiceProto.SCH0201Q12FwkDoctorListResponse.Builder  response =  SchsServiceProto.SCH0201Q12FwkDoctorListResponse.newBuilder();
	     List<ComboListItemInfo> listResult = sch0201Repository.getSCH0201Q12FwkDoctorList(getHospitalCode(vertx, sessionId), request.getGwa(), request.getFind1());
	     if (listResult != null && !listResult.isEmpty()) {
	    	 for (ComboListItemInfo item : listResult) {
	    		 CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
	    		 if (!StringUtils.isEmpty(item.getCode())) {
                		info.setCode(item.getCode());
                	}
                	if (item.getCodeName() != null) {
                		info.setCodeName(item.getCodeName());
                	}
                	response.addFwkDoctorItem(info);
	    	 }
	     }
	     return response.build();
	}
}

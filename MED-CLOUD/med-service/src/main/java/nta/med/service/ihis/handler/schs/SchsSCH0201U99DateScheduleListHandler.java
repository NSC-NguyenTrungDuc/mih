package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.schs.SchsSCH0201U99DateScheduleItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99DateScheduleListRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99DateScheduleListResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SchsSCH0201U99DateScheduleListHandler
	extends ScreenHandler<SchsServiceProto.SchsSCH0201U99DateScheduleListRequest, SchsServiceProto.SchsSCH0201U99DateScheduleListResponse>{
	@Resource
	private Sch0201Repository sch0201Repository;
	@Override
	@Transactional(readOnly=true)
	public SchsSCH0201U99DateScheduleListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SchsSCH0201U99DateScheduleListRequest request) throws Exception {
	     SchsServiceProto.SchsSCH0201U99DateScheduleListResponse.Builder  response =  SchsServiceProto.SchsSCH0201U99DateScheduleListResponse.newBuilder();
	     String hospCode = getHospitalCode(vertx, sessionId);
	     if(!StringUtils.isEmpty(request.getOutHospLink())){
	    	 hospCode = request.getOutHospLink();
	     }
    	 List<SchsSCH0201U99DateScheduleItemInfo> listResult = sch0201Repository.getSchsSCH0201U99DateScheduleListInfo(hospCode, request.getFJundalTable(),
	    		 request.getFJundalPart(), request.getFHangmogCode(), request.getFStartDate());
	     if(listResult != null && !listResult.isEmpty()){
	    	 for(SchsSCH0201U99DateScheduleItemInfo item : listResult){
	    		SchsModelProto.SchsSCH0201U99DateScheduleItemInfo.Builder info = SchsModelProto.SchsSCH0201U99DateScheduleItemInfo.newBuilder();
	    		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
	    		response.addDateScheduleItem(info);
	    	 }
	     }
	     return response.build();
	}
}

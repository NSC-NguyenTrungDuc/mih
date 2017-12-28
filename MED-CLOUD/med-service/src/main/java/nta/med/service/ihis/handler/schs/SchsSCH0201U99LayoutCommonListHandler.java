package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.schs.SchsSCH0201U99LayoutCommonListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99LayoutCommonListRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99LayoutCommonListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class SchsSCH0201U99LayoutCommonListHandler
	extends ScreenHandler<SchsServiceProto.SchsSCH0201U99LayoutCommonListRequest, SchsServiceProto.SchsSCH0201U99LayoutCommonListResponse> {
	@Resource
	private Bas0270Repository bas0270Repository;
	@Override
	@Transactional(readOnly=true)
	public SchsSCH0201U99LayoutCommonListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SchsSCH0201U99LayoutCommonListRequest request) throws Exception {
	     SchsServiceProto.SchsSCH0201U99LayoutCommonListResponse.Builder  response =  SchsServiceProto.SchsSCH0201U99LayoutCommonListResponse.newBuilder();
	     List<SchsSCH0201U99LayoutCommonListInfo> listResult = bas0270Repository.getSchsSCH0201U99LayoutCommonListInfo(getHospitalCode(vertx, sessionId), request.getDoctor(),
	    		 request.getFGwa());
	     if(listResult != null && !listResult.isEmpty()){
	    	 for(SchsSCH0201U99LayoutCommonListInfo item : listResult){
	    		 SchsModelProto.SchsSCH0201U99LayoutCommonListInfo.Builder info = SchsModelProto.SchsSCH0201U99LayoutCommonListInfo.newBuilder();
	    		 if (!StringUtils.isEmpty(item.getDoctorName())) {
	    				info.setDoctorName(item.getDoctorName());
	    			}
	    			if (!StringUtils.isEmpty(item.getReserYn())) {
	    				info.setReserYn(item.getReserYn());
	    			}
	    			response.addCommonList(info);
	    	 }
	     }
	     return response.build();
	}
}

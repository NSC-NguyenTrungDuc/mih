package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.schs.SchsSCH0201Q02ReserList02ItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q02ReserList02Request;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q02ReserList02Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SchsSCH0201Q02ReserList02Handler
	extends ScreenHandler<SchsServiceProto.SchsSCH0201Q02ReserList02Request, SchsServiceProto.SchsSCH0201Q02ReserList02Response> {
	@Resource
	private Sch0201Repository sch0201Repository;
	@Override
	@Transactional(readOnly=true)
	public SchsSCH0201Q02ReserList02Response handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SchsSCH0201Q02ReserList02Request request) throws Exception {
		List<SchsSCH0201Q02ReserList02ItemInfo> listResult = sch0201Repository.getSchsSCH0201Q02ReserList02ItemInfo(getHospitalCode(vertx, sessionId),request.getFromDate(),
	    		request.getToDate(),request.getGwa());
	     SchsServiceProto.SchsSCH0201Q02ReserList02Response.Builder response =  SchsServiceProto.SchsSCH0201Q02ReserList02Response.newBuilder();
	     if(listResult != null && !listResult.isEmpty()){
	    	 for(SchsSCH0201Q02ReserList02ItemInfo item : listResult){
	    		SchsModelProto.SchsSCH0201Q02ReserList02ItemInfo.Builder info = SchsModelProto.SchsSCH0201Q02ReserList02ItemInfo.newBuilder();
	    		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
    			response.addReserList02Item(info);
	    	 }
	     }
	     return response.build();
	}
}

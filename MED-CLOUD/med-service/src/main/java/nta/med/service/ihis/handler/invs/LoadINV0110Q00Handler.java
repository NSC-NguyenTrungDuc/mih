package nta.med.service.ihis.handler.invs;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inv.Inv0110Repository;
import nta.med.data.model.ihis.invs.LoadINV0110Q00Info;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.LoadINV0110Q00Request;
import nta.med.service.ihis.proto.InvsServiceProto.LoadINV0110Q00Response;

@Service
@Scope("prototype")
public class LoadINV0110Q00Handler extends ScreenHandler<InvsServiceProto.LoadINV0110Q00Request, InvsServiceProto.LoadINV0110Q00Response>{

	@Resource
    private Inv0110Repository inv0110Repository;
	
	@Override
	@Transactional(readOnly = true)
	public LoadINV0110Q00Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			LoadINV0110Q00Request request) throws Exception {
		
		InvsServiceProto.LoadINV0110Q00Response.Builder response = InvsServiceProto.LoadINV0110Q00Response.newBuilder();
		String offset = request.getOffSet();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
        
		List<LoadINV0110Q00Info> itemList = inv0110Repository.getINV0110Q00Info(getHospitalCode(vertx, sessionId),
				request.getJaeryoNameInx(), getLanguage(vertx, sessionId), startNum, CommonUtils.parseInteger(offset));
		
		if(!CollectionUtils.isEmpty(itemList)){
			for (LoadINV0110Q00Info item : itemList) {
				InvsModelProto.LoadINV0110Q00Info.Builder info = InvsModelProto.LoadINV0110Q00Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListItem(info);
			}
		}
		
		return response.build();
	}
}

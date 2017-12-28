package nta.med.service.ihis.handler.inps;

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
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.inps.INP3003U00grdINP1001PastInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP3003U00grdINP1001PastRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP3003U00grdINP1001PastResponse;

@Service
@Scope("prototype")
public class INP3003U00grdINP1001PastHandler extends ScreenHandler<InpsServiceProto.INP3003U00grdINP1001PastRequest , InpsServiceProto.INP3003U00grdINP1001PastResponse >{
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP3003U00grdINP1001PastResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP3003U00grdINP1001PastRequest request) throws Exception {
		InpsServiceProto.INP3003U00grdINP1001PastResponse.Builder response = InpsServiceProto.INP3003U00grdINP1001PastResponse.newBuilder();
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
        List<INP3003U00grdINP1001PastInfo> grdPasts = inp1001Repository.getINP3003U00grdINP1001PastInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
        		request.getBunho(), startNum, CommonUtils.parseInteger(offset));
        if(!CollectionUtils.isEmpty(grdPasts)){
			for(INP3003U00grdINP1001PastInfo item : grdPasts){
				InpsModelProto.INP3003U00grdINP1001PastInfo.Builder info = InpsModelProto.INP3003U00grdINP1001PastInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdMasterItem(info);
			}
		}
		return response.build();
	}

}

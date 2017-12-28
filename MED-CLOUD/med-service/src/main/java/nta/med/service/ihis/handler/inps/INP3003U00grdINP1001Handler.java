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
import nta.med.data.model.ihis.inps.INP3003U00grdINP1001Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP3003U00grdINP1001Request;
import nta.med.service.ihis.proto.InpsServiceProto.INP3003U00grdINP1001Response;

@Service
@Scope("prototype")
public class INP3003U00grdINP1001Handler extends ScreenHandler<InpsServiceProto.INP3003U00grdINP1001Request , InpsServiceProto.INP3003U00grdINP1001Response >{
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP3003U00grdINP1001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP3003U00grdINP1001Request request) throws Exception {
		InpsServiceProto.INP3003U00grdINP1001Response.Builder response = InpsServiceProto.INP3003U00grdINP1001Response.newBuilder();
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
        Double pkinp1001 = CommonUtils.parseDouble(request.getPkinp1001());
		List<INP3003U00grdINP1001Info> grds = inp1001Repository.getINP3003U00grdINP1001Info(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				pkinp1001, startNum, CommonUtils.parseInteger(offset));
		if(!CollectionUtils.isEmpty(grds)){
			for(INP3003U00grdINP1001Info item : grds){
				InpsModelProto.INP3003U00grdINP1001Info.Builder info = InpsModelProto.INP3003U00grdINP1001Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdMasterItem(info);
			}
		}
		return response.build();
	}

}

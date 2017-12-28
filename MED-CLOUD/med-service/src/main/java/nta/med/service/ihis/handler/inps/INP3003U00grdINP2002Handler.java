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
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.inps.INP3003U00grdINP2002Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP3003U00grdINP2002Request;
import nta.med.service.ihis.proto.InpsServiceProto.INP3003U00grdINP2002Response;

@Service
@Scope("prototype")
public class INP3003U00grdINP2002Handler extends ScreenHandler<InpsServiceProto.INP3003U00grdINP2002Request , InpsServiceProto.INP3003U00grdINP2002Response >{
	@Resource
	private OutsangRepository outsangRepository;
	
	@Override
	@Transactional(readOnly=true)
	public INP3003U00grdINP2002Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP3003U00grdINP2002Request request) throws Exception {
		InpsServiceProto.INP3003U00grdINP2002Response.Builder response = InpsServiceProto.INP3003U00grdINP2002Response.newBuilder();
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		List<INP3003U00grdINP2002Info> grds = outsangRepository.getINP3003U00grdINP2002Info(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				request.getBunho(), request.getGwa(), startNum, CommonUtils.parseInteger(offset));
		if(!CollectionUtils.isEmpty(grds)){
			for(INP3003U00grdINP2002Info item : grds){
				InpsModelProto.INP3003U00grdINP2002Info.Builder info = InpsModelProto.INP3003U00grdINP2002Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdMasterItem(info);
			}
		}
		return response.build();
	}

}

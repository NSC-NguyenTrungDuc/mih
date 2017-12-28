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
import nta.med.data.model.ihis.inps.INP1001U01LayInp1002Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01LayInp1002Request;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01LayInp1002Response;

@Service
@Scope("prototype")
public class INP1001U01LayInp1002Handler extends ScreenHandler<InpsServiceProto.INP1001U01LayInp1002Request, InpsServiceProto.INP1001U01LayInp1002Response>{

	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public INP1001U01LayInp1002Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01LayInp1002Request request) throws Exception {
		
		InpsServiceProto.INP1001U01LayInp1002Response.Builder response = InpsServiceProto.INP1001U01LayInp1002Response.newBuilder();
		Double fkInp1001 = CommonUtils.parseDouble(request.getFkinp1001());
		List<INP1001U01LayInp1002Info> lstInfo = inp1001Repository.getINP1001U01LayInp1002Info(getHospitalCode(vertx, sessionId), fkInp1001);
		
		if(CollectionUtils.isEmpty(lstInfo)){
			return response.build();
		}
		
		for (INP1001U01LayInp1002Info info : lstInfo) {
			InpsModelProto.INP1001U01LayInp1002Info.Builder protoInfo = InpsModelProto.INP1001U01LayInp1002Info.newBuilder();
			BeanUtils.copyProperties(info, protoInfo, getLanguage(vertx, sessionId));
			response.addLayList(protoInfo);
		}
		
		return response.build();
	}

}

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
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.inps.INP1003U01fbxInp1003Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U01fbxInp1003Request;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U01fbxInp1003Response;

@Service
@Scope("prototype")
public class INP1003U01fbxInp1003Handler extends ScreenHandler<InpsServiceProto.INP1003U01fbxInp1003Request, InpsServiceProto.INP1003U01fbxInp1003Response>{
	@Resource
	private Bas0270Repository bas0270Repository;

	@Override
	@Transactional(readOnly=true)
	public INP1003U01fbxInp1003Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003U01fbxInp1003Request request) throws Exception {
		InpsServiceProto.INP1003U01fbxInp1003Response.Builder response = InpsServiceProto.INP1003U01fbxInp1003Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<INP1003U01fbxInp1003Info> listInfo = bas0270Repository.getINP1003U01fbxInp1003Info(hospCode, request.getFind(), request.getBuseoYmd(), 
											request.getGwa(), request.getDoctorYmd(), request.getNameControl());
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		for (INP1003U01fbxInp1003Info info : listInfo) {
			InpsModelProto.INP1003U01fbxInp1003Info.Builder infoProto = InpsModelProto.INP1003U01fbxInp1003Info.newBuilder();
			BeanUtils.copyProperties(info, infoProto, language);
			response.addFbxInp1003(infoProto);
		}
	
		return response.build();
	}
}
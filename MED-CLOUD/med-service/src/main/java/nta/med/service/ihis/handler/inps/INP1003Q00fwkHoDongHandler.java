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
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01GetDepartmentInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003Q00fwkHoDongRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003Q00fwkHoDongResponse;

@Service
@Scope("prototype")
public class INP1003Q00fwkHoDongHandler extends ScreenHandler<InpsServiceProto.INP1003Q00fwkHoDongRequest, InpsServiceProto.INP1003Q00fwkHoDongResponse>{
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP1003Q00fwkHoDongResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003Q00fwkHoDongRequest request) throws Exception {
		InpsServiceProto.INP1003Q00fwkHoDongResponse.Builder response = InpsServiceProto.INP1003Q00fwkHoDongResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NuroOUT1001U01GetDepartmentInfo> listInfo = bas0260Repository.getNuroOUT1001U01GetDepartmentInfo(language, hospCode, request.getBuseoYmd()
							, "2",  request.getFind1());
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		for (NuroOUT1001U01GetDepartmentInfo info : listInfo) {
			InpsModelProto.INP1003Q00fwkHoDongInfo.Builder infoProto = InpsModelProto.INP1003Q00fwkHoDongInfo.newBuilder();
			BeanUtils.copyProperties(info, infoProto, language);
			response.addFwkItem(infoProto);
		}
		
		return response.build();
	}
}

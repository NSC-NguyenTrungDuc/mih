package nta.med.service.ihis.handler.inps;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.out.Out0102;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0102Repository;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01LayLastCheckDateRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class INP1001U01LayLastCheckDateHandler
		extends ScreenHandler<InpsServiceProto.INP1001U01LayLastCheckDateRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Out0102Repository out0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01LayLastCheckDateRequest request) throws Exception {
		
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		response.setResult("");
		
		Date fDate = DateUtil.toDate(request.getDate() ,DateUtil.PATTERN_YYMMDD);
		List<Out0102> lstOut0102 = out0102Repository.findByHospCodeBunhoGubunFDate(getHospitalCode(vertx, sessionId), request.getBunho(), request.getGubun(), fDate);
		if(!CollectionUtils.isEmpty(lstOut0102)){
			for (Out0102 out0102 : lstOut0102) {
				if(out0102.getLastCheckDate() != null){
					response.setResult(DateUtil.toString(out0102.getLastCheckDate(), DateUtil.PATTERN_YYMMDD));
				}
			}
		}
		
		return response.build();
	}

}

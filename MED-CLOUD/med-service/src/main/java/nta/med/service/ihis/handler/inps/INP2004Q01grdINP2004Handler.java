package nta.med.service.ihis.handler.inps;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp2004Repository;
import nta.med.data.model.ihis.inps.INP2004Q01grdINP2004Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP2004Q01grdINP2004Request;
import nta.med.service.ihis.proto.InpsServiceProto.INP2004Q01grdINP2004Response;

@Service
@Scope("prototype")
public class INP2004Q01grdINP2004Handler extends
		ScreenHandler<InpsServiceProto.INP2004Q01grdINP2004Request, InpsServiceProto.INP2004Q01grdINP2004Response> {

	@Resource
	private Inp2004Repository inp2004Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP2004Q01grdINP2004Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP2004Q01grdINP2004Request request) throws Exception {
		InpsServiceProto.INP2004Q01grdINP2004Response.Builder response = InpsServiceProto.INP2004Q01grdINP2004Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Date fromDate = DateUtil.toDate(request.getFromDate(),DateUtil.PATTERN_YYMMDD);
		Date toDate = DateUtil.toDate(request.getToDate(),DateUtil.PATTERN_YYMMDD);
		
		List<INP2004Q01grdINP2004Info> listInfo = inp2004Repository.getListINP2004Q01grdINP2004Info(hospCode, fromDate, toDate);
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		for (INP2004Q01grdINP2004Info info : listInfo) {
			InpsModelProto.INP2004Q01grdINP2004Info.Builder infoProto = InpsModelProto.INP2004Q01grdINP2004Info.newBuilder();
			BeanUtils.copyProperties(info, infoProto, language);
			response.addGrdMasterItem(infoProto);
		}
		
		return response.build();
	}

}

package nta.med.service.ihis.handler.inps;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.inps.INPORDERTRANSSelectListSQL0AfterTransInfo;
import nta.med.data.model.ihis.inps.INPORDERTRANSSelectListSQL0BeforeTransInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSSelectListSQL0Request;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSSelectListSQL0Response;

@Service
@Scope("prototype")
public class INPORDERTRANSSelectListSQL0Handler extends
		ScreenHandler<InpsServiceProto.INPORDERTRANSSelectListSQL0Request, InpsServiceProto.INPORDERTRANSSelectListSQL0Response> {

	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	public INPORDERTRANSSelectListSQL0Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INPORDERTRANSSelectListSQL0Request request) throws Exception {
		
		InpsServiceProto.INPORDERTRANSSelectListSQL0Response.Builder response = InpsServiceProto.INPORDERTRANSSelectListSQL0Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String sendYn = request.getMSendYn();
		String bunho = request.getBunho();
		Date orderFromDate = DateUtil.toDate(request.getOrderFromDate(), DateUtil.PATTERN_YYMMDD);
		Date orderToDate = DateUtil.toDate(request.getOrderToDate(), DateUtil.PATTERN_YYMMDD);
		
		if("N".equals(sendYn)){
			List<INPORDERTRANSSelectListSQL0BeforeTransInfo> lstBeforeTransInfo = inp1001Repository.getINPORDERTRANSSelectListSQL0BeforeTransInfo(hospCode, language, bunho, orderFromDate, orderToDate);
			if(!CollectionUtils.isEmpty(lstBeforeTransInfo)){
				for (INPORDERTRANSSelectListSQL0BeforeTransInfo info : lstBeforeTransInfo) {
					InpsModelProto.INPORDERTRANSSelectListSQL0Info.Builder pInfo = InpsModelProto.INPORDERTRANSSelectListSQL0Info.newBuilder();
					BeanUtils.copyProperties(info, pInfo, language);
					response.addGrdList(pInfo);
				}
			}
		} 
		else {
			List<INPORDERTRANSSelectListSQL0AfterTransInfo> lstAfterTransInfo = inp1001Repository.getINPORDERTRANSSelectListSQL0AfterTransInfo(hospCode, language, bunho, orderFromDate, orderToDate);
			for (INPORDERTRANSSelectListSQL0AfterTransInfo info : lstAfterTransInfo) {
				InpsModelProto.INPORDERTRANSSelectListSQL0Info.Builder pInfo = InpsModelProto.INPORDERTRANSSelectListSQL0Info.newBuilder();
				BeanUtils.copyProperties(info, pInfo, language);
				response.addGrdList(pInfo);
			}
		}
		
		
		return response.build();
	}

}

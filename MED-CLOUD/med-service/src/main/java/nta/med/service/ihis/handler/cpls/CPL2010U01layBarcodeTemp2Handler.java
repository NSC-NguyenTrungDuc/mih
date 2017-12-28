package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CPL2010U01layBarcodeTempInfo2;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U01layBarcodeTemp2Request;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U01layBarcodeTemp2Response;

@Service
@Scope("prototype")
public class CPL2010U01layBarcodeTemp2Handler extends
		ScreenHandler<CplsServiceProto.CPL2010U01layBarcodeTemp2Request, CplsServiceProto.CPL2010U01layBarcodeTemp2Response> {

	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL2010U01layBarcodeTemp2Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CPL2010U01layBarcodeTemp2Request request) throws Exception {
		CplsServiceProto.CPL2010U01layBarcodeTemp2Response.Builder response = CplsServiceProto.CPL2010U01layBarcodeTemp2Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<CPL2010U01layBarcodeTempInfo2> items = cpl2010Repository.getCPL2010U01layBarcodeTempInfo2(hospCode, language, request.getSpecimenSer());
		if(!CollectionUtils.isEmpty(items)){
			for (CPL2010U01layBarcodeTempInfo2 item : items) {
				CplsModelProto.CPL2010U01layBarcodeTempInfo.Builder info = CplsModelProto.CPL2010U01layBarcodeTempInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addLayItem(info);
			}
		}
		
		return response.build();
	}

}

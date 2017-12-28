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
import nta.med.data.model.ihis.cpls.CPL2010U01CHANGETIMEgrdSpecimenInfo;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U01CHANGETIMEgrdSpecimenRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U01CHANGETIMEgrdSpecimenResponse;

@Service
@Scope("prototype")
public class CPL2010U01CHANGETIMEgrdSpecimenHandler extends
		ScreenHandler<CplsServiceProto.CPL2010U01CHANGETIMEgrdSpecimenRequest, CplsServiceProto.CPL2010U01CHANGETIMEgrdSpecimenResponse> {

	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL2010U01CHANGETIMEgrdSpecimenResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, CPL2010U01CHANGETIMEgrdSpecimenRequest request) throws Exception {
		CPL2010U01CHANGETIMEgrdSpecimenResponse.Builder response = CPL2010U01CHANGETIMEgrdSpecimenResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<CPL2010U01CHANGETIMEgrdSpecimenInfo> infos = cpl2010Repository.getCPL2010U01CHANGETIMEgrdSpecimenInfo(hospCode
				, request.getOrderDate()
				, request.getBunho()
				, request.getGwa()
				, request.getDoctor());
		
		if(!CollectionUtils.isEmpty(infos)){
			for (CPL2010U01CHANGETIMEgrdSpecimenInfo info : infos) {
				CplsModelProto.CPL2010U01CHANGETIMEgrdSpecimenInfo.Builder pInfo = CplsModelProto.CPL2010U01CHANGETIMEgrdSpecimenInfo.newBuilder();
				BeanUtils.copyProperties(info, pInfo, language);
				response.addGrdMasterItem(pInfo);
			}
		}
		
		return response.build();
	}

}

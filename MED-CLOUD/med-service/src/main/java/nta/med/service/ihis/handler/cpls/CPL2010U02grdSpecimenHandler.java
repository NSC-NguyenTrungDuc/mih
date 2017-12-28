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
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CPL2010U02grdSpecimenInfo;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U02grdSpecimenRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U02grdSpecimenResponse;

@Service
@Scope("prototype")
public class CPL2010U02grdSpecimenHandler extends
		ScreenHandler<CplsServiceProto.CPL2010U02grdSpecimenRequest, CplsServiceProto.CPL2010U02grdSpecimenResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL2010U02grdSpecimenResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CPL2010U02grdSpecimenRequest request) throws Exception {
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);   
		CplsServiceProto.CPL2010U02grdSpecimenResponse.Builder response = CplsServiceProto.CPL2010U02grdSpecimenResponse.newBuilder();
		List<CPL2010U02grdSpecimenInfo> list = cpl2010Repository.getCPL2010U02grdSpecimenInfo(getHospitalCode(vertx, sessionId), 
															getLanguage(vertx, sessionId), 
															request.getJubsuYn(), 
															request.getBunho(), 
															request.getFromDate(), 
															request.getToDate(), 
															request.getHoDong(), 
															startNum, 
															CommonUtils.parseInteger(offset));
		if (!CollectionUtils.isEmpty(list)) {
			for (CPL2010U02grdSpecimenInfo item : list) {
				CplsModelProto.CPL2010U02grdSpecimenInfo.Builder info = CplsModelProto.CPL2010U02grdSpecimenInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdMasterItem(info);
			}
		}
		return response.build();
	}

}

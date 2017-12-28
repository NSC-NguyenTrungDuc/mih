package nta.med.service.ihis.handler.cpls;


import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.service.ihis.proto.CplsModelProto.CPL2010U02grdSpecimenInfo;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U02SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class CPL2010U02SaveLayoutHandler
		extends ScreenHandler<CplsServiceProto.CPL2010U02SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	@Resource
	private Cpl0109Repository cpl0109Repository;

	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CPL2010U02SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		if (CollectionUtils.isEmpty(request.getGrdspecimenList())) {
			response.setResult(false);
			return response.build();
		}
		
		for (CPL2010U02grdSpecimenInfo item : request.getGrdspecimenList()) {
			if (DataRowState.ADDED.getValue().equals(item.getDataRowState())){
				// Do nothing
			} else if (DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
				if ("N".equals(request.getCbojubsu())) {
					if ("Y".equals(item.getCheckYn())) {
						if (cpl2010Repository.updateCPL3010U00QueryLaySpecimenReadUpdate(DateUtil.toDate(item.getGumJubsuDate(), DateUtil.PATTERN_YYMMDD), item.getGumJubsuTime(), request.getCbxactor(), hospCode, item.getSpecimenSer())< 0) {
							response.setMsg("MSG_001");
							response.setResult(false);
							return response.build();
						}
						String result = cpl0109Repository.getCPL2010U02SaveLayoutRequest(hospCode, "20", item.getSpecimenCode());
						if (StringUtils.isEmpty(result)) {
							String ioFlag = cpl2010Repository.callCPL2010U00PrCplPartJubsu(hospCode, item.getSpecimenSer(), item.getSpecimenCode(), DateUtil.toDate(item.getGumJubsuDate(), DateUtil.PATTERN_YYMMDD), item.getGumJubsuTime(), request.getCbxactor(), userId);
							if (StringUtils.isEmpty(ioFlag)) {
								response.setMsg("MSG_002");
								response.setResult(false);
								return response.build();
							}
						}
					}
				}
				
				if ("Y".equals(request.getCbojubsu())) {
					if ("N".equals(item.getCheckYn())) {
						String ioFlag = "";
						if (cpl2010Repository.updateCPL3010U00QueryLaySpecimenReadUpdateExt(null, null, null, hospCode, item.getSpecimenSer()) < 0) {
							response.setResult(false);
							return response.build();
						}
						cpl2010Repository.callPrCplPartJubsuCancel(request.getCbxactor(), item.getSpecimenSer(), null, "1", hospCode, ioFlag);
					}
				}
			} else if (DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
				// Do nothing
			} else {
				// Do nothing
			}
		}
		response.setResult(true);		
		return response.build();
	}

}

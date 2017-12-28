package nta.med.service.ihis.handler.cpls;

import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.service.ihis.proto.CplsModelProto.CPL2010U01CHANGETIMEgrdSpecimenInfo;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U01CHANGETIMESAveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class CPL2010U01CHANGETIMESAveLayoutHandler extends
		ScreenHandler<CplsServiceProto.CPL2010U01CHANGETIMESAveLayoutRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(CPL2010U01CHANGETIMESAveLayoutHandler.class);
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CPL2010U01CHANGETIMESAveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		response.setResult(false);
		if (CollectionUtils.isEmpty(request.getGrdspecimenList()))
			return response.build();
		for (CPL2010U01CHANGETIMEgrdSpecimenInfo item : request.getGrdspecimenList()) {
			if (DataRowState.ADDED.getValue().equals(item.getDataRowState())){
				// Do nothing
			} else if (DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
				if (cpl2010Repository.updateCPL2010U00ChangeTimeUpdateCPL2010(getUserId(vertx, sessionId), new Date(), item.getOrderTime(), getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(item.getPkcpl2010())) > 0)
					response.setResult(true);
			} else if (DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
				// Do nothing
			} else {
				// Do nothing
			}
		}
		return response.build();
	}

}

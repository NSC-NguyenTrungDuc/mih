package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0130Repository;
import nta.med.data.dao.medi.ocs.Ocs0304Repository;
import nta.med.data.model.ihis.ocsa.OcsaOCS0304U00GrdOCS0305ListInfo;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0304Q00grdOCS0305Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0304Q00grdOCS0305Response;

@Service
@Scope("prototype")
public class OCS0304Q00grdOCS0305Handler extends ScreenHandler<OcsaServiceProto.OCS0304Q00grdOCS0305Request, OcsaServiceProto.OCS0304Q00grdOCS0305Response>{
	private static final Log LOGGER = LogFactory.getLog(OCS0304Q00grdOCS0305Handler.class);
	@Resource
	private Ocs0304Repository ocs0304Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS0304Q00grdOCS0305Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS0304Q00grdOCS0305Request request) throws Exception {
		String hospCode = request.getHospCode();
		if (StringUtils.isEmpty(hospCode))
			hospCode = getHospitalCode(vertx, sessionId);
		OcsaServiceProto.OCS0304Q00grdOCS0305Response.Builder response = OcsaServiceProto.OCS0304Q00grdOCS0305Response.newBuilder();
		List<OcsaOCS0304U00GrdOCS0305ListInfo> list = ocs0304Repository.getOcsaOCS0304U00GrdOCS0305ListInfoext(hospCode, request.getMemb());
		if (!CollectionUtils.isEmpty(list)) {
			for (OcsaOCS0304U00GrdOCS0305ListInfo item : list) {
				OcsaModelProto.OCS0304Q00grdOCS0305Info.Builder info = OcsaModelProto.OCS0304Q00grdOCS0305Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				info.setPkSeq(CommonUtils.parseString(item.getPkSeq()));
				info.setDirectGubunName(StringUtils.isEmpty(item.getNurGrName()) ? "" : item.getNurGrName());
				info.setDirectCodeName(StringUtils.isEmpty(item.getNurMdName()) ? "" : item.getNurMdName());
				response.addGrdMasterItem(info);
			}
		}
		return response.build();
	}

}

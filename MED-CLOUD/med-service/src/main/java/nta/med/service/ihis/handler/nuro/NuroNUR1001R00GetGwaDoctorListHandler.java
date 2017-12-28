package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroNUR1001R00GetGwaDoctorListHandler extends ScreenHandler<NuroServiceProto.NuroNUR1001R00GetGwaDoctorListRequest, NuroServiceProto.NuroNUR1001R00GetGwaDoctorListResponse> {
	private static final Log logger = LogFactory.getLog(NuroNUR1001R00GetGwaDoctorListHandler.class);

	@Resource
	private Bas0270Repository bas0270Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroNUR1001R00GetGwaDoctorListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroNUR1001R00GetGwaDoctorListRequest request) throws Exception {
		NuroServiceProto.NuroNUR1001R00GetGwaDoctorListResponse.Builder response = NuroServiceProto.NuroNUR1001R00GetGwaDoctorListResponse.newBuilder();
		List<ComboListItemInfo> listCboAvgTime = bas0270Repository.getNuroNUR1001R00GetGwaDoctorList(getHospitalCode(vertx, sessionId), request.getGwa(), request.getMonth());
		if (listCboAvgTime != null && !listCboAvgTime.isEmpty()) {
			for (ComboListItemInfo obj : listCboAvgTime) {
				CommonModelProto.ComboListItemInfo.Builder builder = CommonModelProto.ComboListItemInfo.newBuilder();
				if (!StringUtils.isEmpty(obj.getCode())) {
					builder.setCode(obj.getCode());
				}
				if (!StringUtils.isEmpty(obj.getCodeName())) {
					builder.setCodeName(obj.getCodeName());
				}
				response.addGwaDoctorItem(builder);
			}
		}
		return response.build();
	}
}

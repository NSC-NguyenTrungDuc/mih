package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur1016Repository;
import nta.med.data.model.ihis.nuri.NuriManageAllergyListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuriManageAllergyListHandler extends ScreenHandler<NuriServiceProto.NuriNUR1016U00ManageAllergyListRequest, NuriServiceProto.NuriNUR1016U00ManageAllergyListResponse> {
	private static final Log LOG = LogFactory.getLog(NuriManageAllergyListHandler.class);

	@Resource
	private Nur1016Repository nur1016Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NuriNUR1016U00ManageAllergyListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NuriNUR1016U00ManageAllergyListRequest request) throws Exception {
		NuriServiceProto.NuriNUR1016U00ManageAllergyListResponse.Builder response = NuriServiceProto.NuriNUR1016U00ManageAllergyListResponse.newBuilder();
		List<NuriManageAllergyListItemInfo> listObject = nur1016Repository.getNuriManageAllergyListItemInfo(getHospitalCode(vertx, sessionId), request.getBunho());
		if (listObject != null && !listObject.isEmpty()) {
			for (NuriManageAllergyListItemInfo obj : listObject) {
				NuriModelProto.NuriNUR1016U00ManageAllergyListItemInfo.Builder itemBuilder = NuriModelProto.NuriNUR1016U00ManageAllergyListItemInfo.newBuilder();
				if (!StringUtils.isEmpty(obj.getPknur1016())) {
					itemBuilder.setPknur1016(obj.getPknur1016().toString());
				}
				if (!StringUtils.isEmpty(obj.getBunho())) {
					itemBuilder.setBunho(obj.getBunho());
				}
				if (!StringUtils.isEmpty(obj.getAllergyGubun())) {
					itemBuilder.setAllergyGubun(obj.getAllergyGubun());
				}
				if (!StringUtils.isEmpty(obj.getAllergyInfo())) {
					itemBuilder.setAllergyInfo(obj.getAllergyInfo());
				}
				if (!StringUtils.isEmpty(obj.getStartDate())) {
					itemBuilder.setStartDate(obj.getStartDate().toString());
				}
				if (!StringUtils.isEmpty(obj.getEndDate())) {
					itemBuilder.setEndDate(obj.getEndDate().toString());
				}
				if (!StringUtils.isEmpty(obj.getEndSayu())) {
					itemBuilder.setEndSayu(obj.getEndSayu());
				}
				if (!StringUtils.isEmpty(obj.getInputText())) {
					itemBuilder.setInputText(obj.getInputText());
				}
				response.addManageAllergyListItem(itemBuilder);
			}
		}
		return response.build();
	}
}

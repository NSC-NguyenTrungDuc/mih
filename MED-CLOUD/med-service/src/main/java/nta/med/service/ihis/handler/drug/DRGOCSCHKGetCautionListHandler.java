package nta.med.service.ihis.handler.drug;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.drg.Drg0130Repository;
import nta.med.data.model.ihis.drug.DrugComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.DrugServiceProto;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class DRGOCSCHKGetCautionListHandler extends ScreenHandler<DrugServiceProto.DRGOCSCHKGetCautionListRequest, DrugServiceProto.DRGOCSCHKGetCautionListResponse> {
	private static final Log LOG = LogFactory.getLog(DRGOCSCHKGetCautionListHandler.class);
	@Resource
	private Drg0130Repository drg0130Repository;

	@Override
	@Transactional(readOnly = true)
	public DrugServiceProto.DRGOCSCHKGetCautionListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			DrugServiceProto.DRGOCSCHKGetCautionListRequest request) throws Exception {
		 DrugServiceProto.DRGOCSCHKGetCautionListResponse.Builder response = DrugServiceProto.DRGOCSCHKGetCautionListResponse.newBuilder();
		 List<DrugComboListItemInfo> listObject = drg0130Repository.getDRGOCSCHKGetCautionList(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
         if(!CollectionUtils.isEmpty(listObject)) {
         	for(DrugComboListItemInfo item : listObject) {
         		CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
         		if (!StringUtils.isEmpty(item.getCode())) {
         			info.setCode(item.getCode());
         		}
         		if (!StringUtils.isEmpty(item.getCodeName())) {
         			info.setCodeName(item.getCodeName());
         		}

         		response.addListItem(info);
         	}
         }
		return response.build();
	}
}

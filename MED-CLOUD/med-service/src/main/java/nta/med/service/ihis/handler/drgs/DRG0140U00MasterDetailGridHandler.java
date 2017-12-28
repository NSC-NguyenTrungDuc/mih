package nta.med.service.ihis.handler.drgs;

import nta.med.core.domain.drg.Drg0140;
import nta.med.core.domain.drg.Drg0141;
import nta.med.data.dao.medi.drg.Drg0140Repository;
import nta.med.data.dao.medi.drg.Drg0141Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service
@Scope("prototype")
public class DRG0140U00MasterDetailGridHandler extends ScreenHandler<DrgsServiceProto.DRG0140U00MasterDetailGridRequest, DrgsServiceProto.DRG0140U00MasterDetailGridResponse> {
	private static final Log LOG = LogFactory.getLog(DRG0140U00MasterDetailGridHandler.class);
	@Resource
	private Drg0140Repository drg0140Repository;
	@Resource
	private Drg0141Repository drg0141Repository;

	@Override
	@Transactional(readOnly = true)
	public DrgsServiceProto.DRG0140U00MasterDetailGridResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0140U00MasterDetailGridRequest request) throws Exception {
		DrgsServiceProto.DRG0140U00MasterDetailGridResponse.Builder response = DrgsServiceProto.DRG0140U00MasterDetailGridResponse.newBuilder();
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String languge =  getLanguage(vertx, sessionId);
		List<Drg0140> listDrg0140 = drg0140Repository.findByCode(hospitalCode, request.getCode(), languge);
		if(!CollectionUtils.isEmpty(listDrg0140)) {
			for(Drg0140 item : listDrg0140) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				if (!StringUtils.isEmpty(item.getCode())) {
					info.setCode(item.getCode());
				}
				if (!StringUtils.isEmpty(item.getCodeName())) {
					info.setCodeName(item.getCodeName());
				}
				response.addGrdMaster(info);
			}
		}
		List<Drg0141> listDrg0141 = drg0141Repository.getByCode(hospitalCode, request.getCode(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listDrg0141)) {
			for(Drg0141 item : listDrg0141) {
				CommonModelProto.TripleListItemInfo.Builder info = CommonModelProto.TripleListItemInfo.newBuilder();
				if (!StringUtils.isEmpty(item.getCode())) {
					info.setItem1(item.getCode());
				}
				if (!StringUtils.isEmpty(item.getCode1())) {
					info.setItem2(item.getCode1());
				}
				if (!StringUtils.isEmpty(item.getCodeName1())) {
					info.setItem3(item.getCodeName1());
				}
				response.addGrdDetail(info);
			}
		}
		return response.build();
	}
}

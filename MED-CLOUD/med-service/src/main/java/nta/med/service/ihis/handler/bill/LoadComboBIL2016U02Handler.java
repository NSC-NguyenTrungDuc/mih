package nta.med.service.ihis.handler.bill;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.bas.Bas0102;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.service.ihis.proto.BillServiceProto;
import nta.med.service.ihis.proto.BillServiceProto.LoadComboBIL2016U02Request;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class LoadComboBIL2016U02Handler
		extends ScreenHandler<BillServiceProto.LoadComboBIL2016U02Request, SystemServiceProto.ComboResponse> {

	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			LoadComboBIL2016U02Request request) throws Exception {

		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		String codeType = request.hasComboType() ? request.getComboType() : ""; // PAYMENT_TYPE, REVERT_TYPE
		
		List<Bas0102> listBas0102 = bas0102Repository.getByCodeType(getHospitalCode(vertx, sessionId), codeType, getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listBas0102)){
			for (Bas0102 bas0102 : listBas0102) {
				CommonModelProto.ComboListItemInfo info = CommonModelProto.ComboListItemInfo.newBuilder().setCode(bas0102.getCode()).setCodeName(bas0102.getCodeName()).build();
				response.addComboItem(info);
			}
		}

		return response.build();
	}

}

package nta.med.service.ihis.handler.nuts;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.inp.Inp5001Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NutsServiceProto;
import nta.med.service.ihis.proto.NutsServiceProto.NUT9001U00ScreenOpenRequest;
import nta.med.service.ihis.proto.NutsServiceProto.NUT9001U00ScreenOpenResponse;

@Service
@Scope("prototype")
public class NUT9001U00ScreenOpenHandler extends
		ScreenHandler<NutsServiceProto.NUT9001U00ScreenOpenRequest, NutsServiceProto.NUT9001U00ScreenOpenResponse> {

	@Resource
	private Inp5001Repository inp5001Repository;
	
	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUT9001U00ScreenOpenResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUT9001U00ScreenOpenRequest request) throws Exception {
		
		NutsServiceProto.NUT9001U00ScreenOpenResponse.Builder response = NutsServiceProto.NUT9001U00ScreenOpenResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		String isSiksaMagamYn = inp5001Repository.getNutIsSiksaMagamYn(hospCode);
		CommonModelProto.DataStringListItemInfo.Builder info1 = CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue(isSiksaMagamYn);
		response.addDataItems(info1);
		
		List<String> lst1 = ocs0132Repository.getCodeNameByCodeAndCodeType(hospCode, language, "NUT_FINAL_MAGAM_ACTION", "CHANGE_YN");
		CommonModelProto.DataStringListItemInfo.Builder info2 = CommonModelProto.DataStringListItemInfo.newBuilder()
				.setDataValue(CollectionUtils.isEmpty(lst1) ? "" : lst1.get(0));
		response.addDataItems(info2);
		
		List<String> lst2 = ocs0132Repository.getCodeNameByCodeAndCodeType(hospCode, language, "NUT_FINAL_MAGAM_ACTION", "ENABLE_YN");
		CommonModelProto.DataStringListItemInfo.Builder info3 = CommonModelProto.DataStringListItemInfo.newBuilder()
				.setDataValue(CollectionUtils.isEmpty(lst2) ? "" : lst2.get(0));
		response.addDataItems(info3);
		
		return response.build();
	}

}

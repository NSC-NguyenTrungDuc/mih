package nta.med.service.ihis.handler.nuri;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur1123;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur1123Repository;
import nta.med.service.ihis.proto.NuriModelProto.NUR1123U00grdDetailInfo;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class NUR1123U00SaveLayoutHandler extends ScreenHandler<NuriServiceProto.NUR1123U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	
	@Resource                                                                                                       
	private Nur1123Repository nur1123Repository;

	@Override
	@Transactional
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1123U00SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = request.getUserId();
		
		List<NUR1123U00grdDetailInfo> listInfoProto = request.getGrdList();
		for (NUR1123U00grdDetailInfo infoProto : listInfoProto) {
			if (DataRowState.ADDED.getValue().equalsIgnoreCase(infoProto.getRowState())) {
				Nur1123 nur1123 = new Nur1123();
				nur1123.setSysDate(new Date());
				nur1123.setSysId(userId);
				nur1123.setUpdDate(new Date());
				nur1123.setUpdId(userId);
				nur1123.setHospCode(hospCode);
				nur1123.setCodeType(infoProto.getCodeType());
				nur1123.setCode(infoProto.getCode());
				nur1123.setCodeName(infoProto.getCodeName());
				nur1123.setSortKey(CommonUtils.parseDouble(infoProto.getSortKey()));
				
				nur1123Repository.save(nur1123);
			} else if (DataRowState.MODIFIED.getValue().equalsIgnoreCase(infoProto.getRowState())) {
				nur1123Repository.updateNUR1123U00ByHospCodeAndCodeTypeAndCode(userId
						, new Date()
						, infoProto.getCodeType()
						, infoProto.getCode()
						, infoProto.getCodeName()
						, CommonUtils.parseDouble(infoProto.getSortKey())
						, hospCode);
			} else if (DataRowState.DELETED.getValue().equalsIgnoreCase(infoProto.getRowState())) {
				nur1123Repository.deleteByHospCodeAndCodeTypeAndCode(hospCode, infoProto.getCodeType(), infoProto.getCode());
			}
		}
		
		response.setResult(true);
		return response.build();
	}

}

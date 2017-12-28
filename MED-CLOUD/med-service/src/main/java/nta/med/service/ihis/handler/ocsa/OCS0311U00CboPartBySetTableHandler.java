package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00CboPartBySetTableRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00CboPartBySetTableResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;


@Service
@Scope("prototype")
@Transactional
public class OCS0311U00CboPartBySetTableHandler
	extends ScreenHandler<OcsaServiceProto.OCS0311U00CboPartBySetTableRequest, OcsaServiceProto.OCS0311U00CboPartBySetTableResponse>{
	@Resource
	private Ocs0132Repository ocs0132Repository;
	@Override
	@Transactional(readOnly = true)
	public OCS0311U00CboPartBySetTableResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0311U00CboPartBySetTableRequest request) throws Exception {
		 OcsaServiceProto.OCS0311U00CboPartBySetTableResponse.Builder response=OcsaServiceProto.OCS0311U00CboPartBySetTableResponse.newBuilder();
		 List<ComboListItemInfo> listCboPartBySetTable=ocs0132Repository.getOCS0311U00CboPartBySetTable(getHospitalCode(vertx, sessionId),
				 getLanguage(vertx, sessionId),request.getCurrGroupId());
		 if(listCboPartBySetTable !=null && !listCboPartBySetTable.isEmpty()){
			 for(ComboListItemInfo item : listCboPartBySetTable){
				 CommonModelProto.ComboListItemInfo.Builder info= CommonModelProto.ComboListItemInfo.newBuilder();
				 if (!StringUtils.isEmpty(item.getCode())) {
						info.setCode(item.getCode());
					}
					if (!StringUtils.isEmpty(item.getCodeName())) {
						info.setCodeName(item.getCodeName());
					}
					response.addCboPartBySetTable(info);
			 }
		 }
		 return response.build();
	}
}

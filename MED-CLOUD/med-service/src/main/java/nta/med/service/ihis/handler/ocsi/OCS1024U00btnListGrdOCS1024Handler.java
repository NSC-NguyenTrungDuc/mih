package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs1024Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00btnListGrdOCS1024Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00btnListGrdOCS1024Response;

@Service
@Scope("prototype")
public class OCS1024U00btnListGrdOCS1024Handler extends ScreenHandler<OcsiServiceProto.OCS1024U00btnListGrdOCS1024Request , OcsiServiceProto.OCS1024U00btnListGrdOCS1024Response>{
	@Resource
	private Ocs1024Repository ocs1024Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS1024U00btnListGrdOCS1024Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS1024U00btnListGrdOCS1024Request request) throws Exception {
		OcsiServiceProto.OCS1024U00btnListGrdOCS1024Response.Builder response = OcsiServiceProto.OCS1024U00btnListGrdOCS1024Response.newBuilder();
		Double fkInp1001 = CommonUtils.parseDouble(request.getFkinp1001());
		List<ComboListItemInfo> comboList = ocs1024Repository.getOCS1024U00btnListGrdOCS1024(getHospitalCode(vertx, sessionId), request.getHangmogCode(), fkInp1001);
		if(!CollectionUtils.isEmpty(comboList)){
			for(ComboListItemInfo item : comboList){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdItem(info);
			}
		}
		return response.build();
	}

}

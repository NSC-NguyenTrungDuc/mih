package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INPBATCHTRANScbxBuseoRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INPBATCHTRANScbxBuseoResponse;

@Service
@Scope("prototype")
public class INPBATCHTRANScbxBuseoHandler extends ScreenHandler<InpsServiceProto.INPBATCHTRANScbxBuseoRequest, InpsServiceProto.INPBATCHTRANScbxBuseoResponse>{
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INPBATCHTRANScbxBuseoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INPBATCHTRANScbxBuseoRequest request) throws Exception {
		InpsServiceProto.INPBATCHTRANScbxBuseoResponse.Builder response = InpsServiceProto.INPBATCHTRANScbxBuseoResponse.newBuilder();
		List<ComboListItemInfo> list = bas0260Repository.getComboHoDongSystemCombobox(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "2");
		if (!CollectionUtils.isEmpty(list)) {
			for (ComboListItemInfo item : list) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCboItem(info);
			}
		}
		return response.build();
	}

}

package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003Q00MakeHodongComboRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003Q00MakeHodongComboResponse;

@Service
@Scope("prototype")
public class INP1003Q00MakeHodongComboHandler extends ScreenHandler<InpsServiceProto.INP1003Q00MakeHodongComboRequest, InpsServiceProto.INP1003Q00MakeHodongComboResponse>{
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP1003Q00MakeHodongComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003Q00MakeHodongComboRequest request) throws Exception {
		InpsServiceProto.INP1003Q00MakeHodongComboResponse.Builder response = InpsServiceProto.INP1003Q00MakeHodongComboResponse.newBuilder();
		String language = getLanguage(vertx, sessionId);
		
		List<ComboListItemInfo> listInfo = bas0260Repository.getINP1003Q00cboHodong(language, request.getReserDate());
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		for (ComboListItemInfo info : listInfo) {
			CommonModelProto.ComboListItemInfo.Builder infoProto = CommonModelProto.ComboListItemInfo.newBuilder();
			BeanUtils.copyProperties(info, infoProto, language);
			response.addGrdMasterItem(infoProto);
		}
		
		return response.build();
	}

}

package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Acc001Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto.IFS0001U00FindBoxRequest;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;


@Service                                                                                                          
@Scope("prototype")
public class IFS0001U00FindBoxHandler extends ScreenHandler<IFS0001U00FindBoxRequest, ComboResponse> {
	@Resource
	private Acc001Repository acc001Repository;
	
	@Override
	@Transactional(readOnly=true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, IFS0001U00FindBoxRequest request) throws Exception {
		ComboResponse.Builder response = ComboResponse.newBuilder();
		List<ComboListItemInfo> listResult = acc001Repository.getIfs0001U00AccountingSystemInfo(request.getFind1(), getLanguage(vertx, sessionId));
		String language = getLanguage(vertx, sessionId);
		if(!CollectionUtils.isEmpty(listResult)){
			for(ComboListItemInfo item : listResult){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info,language);
				response.addComboItem(info);
			}
		}
		return response.build();
	}

}
